using DAL.DTO;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class ContractsForm : Form
    {
        public static Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        public static string generalfile = System.Windows.Forms.Application.StartupPath+"\\Документы\\Шаблоны\\Договор.docx"; // файл-шаблон
        public static Object fileName = generalfile;
        public static Object missing = System.Type.Missing;
        public static bool checkOpenDoc = false;

        public ContractDTO contract = null;
        public List<ProductDTO> addedProducts;
        public MainForm main;

        public ContractsForm(MainForm main)
        {
            this.main = main;
           
            InitializeComponent();
            InitializeListBoxes();
            ButAddContract_Click(this, EventArgs.Empty);
        }

        void InitializeListBoxes()
        {
            foreach (var item in MainForm.DB.Contracts.GetAll())
            {
                lBContracts.Items.Add(item);
            }
            cBCustomer.DataSource = MainForm.DB.Customers.GetAll();
            cBSeller.DataSource = MainForm.DB.Sellers.GetAll();
        }

        private void ContractsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
        }

        private void ButAddProduct_Click(object sender, EventArgs e)
        {
            AddProductInContract addProductInContract = new AddProductInContract(this);
            addProductInContract.ShowDialog();
        }

        public void ReloadedData()
        {
            dGVProducts.Rows.Clear();
            foreach (var item in addedProducts)
            {
                dGVProducts.Rows.Add(new object[] {
                    item.Name,
                    item.Price.ToString(),
                    item.Balance.ToString(),
                    Math.Round((item.Price * item.Balance),2).ToString(),
                    "Удалить"
                });
                dGVProducts.Rows[dGVProducts.RowCount - 1].Tag = item;
            }
        }

        private void DGVProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                ProductDTO product = (ProductDTO)dGVProducts.CurrentRow.Tag;
                if (MessageBox.Show("Удалить " + product.Name + " ?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    addedProducts.Remove(product);
                }
                ReloadedData();
            }
        }

        private void ButAddContract_Click(object sender, EventArgs e)
        {
            if (pData.Enabled == false)
            {
                pContracts.Enabled = false;
                pData.Enabled = true;
                pProducts.Enabled = true;
                butAddContract.BackColor = Color.Blue;
                butAddContract.Text = "Отменить добавление";
                lBContracts.Enabled = false;
                lContract.Text = "Новый договор";
                lContract.Enabled = false;
                butSave.Enabled = true;
                contract = new ContractDTO();
                addedProducts = new List<ProductDTO>();
                ReloadedData();
            }
            else
            {
                pContracts.Enabled = true;
                pData.Enabled = false;
                pProducts.Enabled = false;
                butAddContract.BackColor = Color.LimeGreen;
                butAddContract.Text = "Добавить новый договор";
                lBContracts.Enabled = true;
                lContract.Enabled = true;
                if ((lBContracts.SelectedItem) != null)
                    lContract.Text = (lBContracts.SelectedItem).ToString();
                else lContract.Text = "Не выбран";
            }
        }

        private void LBContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lBContracts.SelectedItem != null)
            {
                butBuild.Enabled = true;
                butDirectory.Enabled = true;
                butDel.Enabled = true;
                butOpen.Enabled = true;
                lContract.Text = lBContracts.Text;
                tBNumber.Text = (lBContracts.SelectedItem as ContractDTO).Number.ToString();
                tBOtv.Text = (lBContracts.SelectedItem as ContractDTO).ResponsiblePerson;
                if ((lBContracts.SelectedItem as ContractDTO).PeriodInMonths == 3)
                    rBChet.Checked = true;
                else
                    rBPol.Checked = true;
                dTPData.Value = (lBContracts.SelectedItem as ContractDTO).ConclusionDate;
                cBCustomer.SelectedItem = (lBContracts.SelectedItem as ContractDTO).Customer;
                cBSeller.SelectedItem = (lBContracts.SelectedItem as ContractDTO).Seller;
                dGVProducts.Rows.Clear();
                Stream stream = new FileStream(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString() + "\\contract.cont", FileMode.Open);
                addedProducts = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
                stream.Close();
                ReloadedData();
                if (lSumm.Text == "0")
                    MessageBox.Show("Данный договор закрыт!");
                
            }
            
        }

        private void ButSaveAndOpen_Click(object sender, EventArgs e)
        {
            if (tBNumber.Text.Length != 0 && tBOtv.Text.Length != 0 && dGVProducts.Rows.Count != 0 ) {
                if (MainForm.DB.Contracts.GetAll().Where(x => x.Number == int.Parse(tBNumber.Text) && x.ConclusionDate.ToLongDateString() == dTPData.Value.ToLongDateString()).Count() == 0)
                {
                    float Total = 0;
                    foreach (var item in addedProducts)
                    {
                        Total += item.Balance * item.Price;
                    }
                    contract = new ContractDTO
                    {
                        Number = int.Parse(tBNumber.Text),
                        PeriodInMonths = rBChet.Checked ? 3 : 6,
                        ConclusionDate = dTPData.Value,
                        CustomerId = (cBCustomer.SelectedItem as CustomerDTO).Id,
                        SellerId = (cBSeller.SelectedItem as SellerDTO).Id,
                        ResponsiblePerson = tBOtv.Text,
                        FileName = System.Windows.Forms.Application.StartupPath + "\\Документы\\Контракт №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString()+"\\contract.cont",
                        Total = (float)Math.Round(Total, 2)
                    };
                    MainForm.DB.Contracts.Create(contract);
                    MainForm.DB.Save();
                    string path = System.Windows.Forms.Application.StartupPath + "\\Документы\\";
                    string subpath = contract.ToString();
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (!dirInfo.Exists)
                    {
                        dirInfo.Create();
                    }
                    if (!Directory.Exists(path + contract.ToString()))
                    {
                        dirInfo.CreateSubdirectory(subpath);
                        Stream stream = new FileStream(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + contract.ToString() + "\\contract.cont", FileMode.CreateNew);
                        var serializer = new BinaryFormatter();
                        serializer.Serialize(stream, addedProducts);
                        stream.Close();
                    }
                    ReloadedContracts();
                    MessageBox.Show("Договор успешно сохранён");
                    ButAddContract_Click(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Договор с таким номером и датой заключения уже существует!");
                }
            }
            else
            {
                MessageBox.Show("Не все обязательные поля заполнены или список продуктов пуст!", "Ошибка сохранения договора");
            }
        }

        private void ReloadedContracts()
        {
            lBContracts.Items.Clear();
            foreach (var item in MainForm.DB.Contracts.GetAll())
            {
                lBContracts.Items.Add(item);
            }
        }

        private void ButCleanProducts_Click(object sender, EventArgs e)
        {
            dGVProducts.Rows.Clear();
            addedProducts.Clear();
        }

        private void DGVProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(dGVProducts.Rows.Count != 0)
            {
                float Total = 0;
                foreach (var item in addedProducts)
                {
                    Total += item.Balance * item.Price;
                }
               lSumm.Text = Math.Round(Total,2).ToString();
            }
        }

        private void DGVProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dGVProducts.Rows.Count != 0)
            {
                float Total = 0;
                foreach (var item in addedProducts)
                {
                    Total += item.Balance * item.Price;
                }
                lSumm.Text = Math.Round(Total, 2).ToString();
            }
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            if (lBContracts.SelectedItem != null)
            {
                var contr = MainForm.DB.Contracts.Get((lBContracts.SelectedItem as ContractDTO).Id);
                if (MessageBox.Show("Вы уверены что хотите удалить договор №" + contr.Number.ToString() + "?", "Удаление договора", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string path = System.Windows.Forms.Application.StartupPath + "\\Документы\\"+contr.ToString();
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (dirInfo.Exists)
                    {
                        dirInfo.Delete(true);
                    }
                }
                MainForm.DB.Contracts.Delete(contr.Id);
                MainForm.DB.Save();
                ReloadedContracts();
            }
        }

        private void ButBuild_Click(object sender, EventArgs e)
        {
            if (lBContracts.SelectedItem != null)
            {
                if(checkOpenDoc)
                {
                    app = new Microsoft.Office.Interop.Word.Application();
                }
                checkOpenDoc = true;
                BuildContract();
            }
        }

        void BuildContract()
        {
            List<string> types = new List<string>();
            foreach (var item in addedProducts)
            {
                var type = MainForm.DB.Types.Get(item.TypeId).Name;
                if (!types.Contains(type))
                {
                    types.Add(type);
                }
            }

            OpenFile();
            ReplaceStrings();
            Document document = app.ActiveDocument;
            Range range = document.Paragraphs[document.Paragraphs.Count].Range;
            int i = 1;
            List<int> mergesRows = new List<int>();
            foreach (string item in types)
            {
                document.Tables[4].Rows.Add();
                i++;
                mergesRows.Add(i);
                document.Tables[4].Rows[i].Range.Bold = 0;
                document.Tables[4].Rows[i].Height = float.Parse("0,3");
                document.Tables[4].Rows[i].Cells[1].Range.Text = item;
                foreach (ProductDTO product in addedProducts.Where(x => MainForm.DB.Types.Get(x.TypeId).Name == item))
                {
                    document.Tables[4].Rows.Add();
                    i++;
                    document.Tables[4].Cell(i, 1).Range.Text = product.Name;
                    document.Tables[4].Cell(i, 2).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                    document.Tables[4].Cell(i, 3).Range.Text = product.Price.ToString();
                    document.Tables[4].Cell(i, 4).Range.Text = "-";
                    document.Tables[4].Cell(i, 5).Range.Text = product.Balance.ToString();
                    document.Tables[4].Cell(i, 6).Range.Text = Math.Round((product.Price * product.Balance),2).ToString();
                    document.Tables[4].Cell(i, 7).Range.Text = "0";
                }
            }
            foreach(var item in mergesRows)
               document.Tables[4].Rows[item].Cells[1].Merge(document.Tables[4].Rows[item].Cells[7]);
            document.Tables[4].Rows.Add();
            i++;
            document.Tables[4].Rows[i].Range.Bold = 0;
            document.Tables[4].Rows[i].Height = float.Parse("0,3");
            document.Tables[4].Cell(i, 1).Range.Text = "Итого";
            document.Tables[4].Cell(i, 6).Range.Text = lSumm.Text;

            SaveFile(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString() + "\\"+ (lBContracts.SelectedItem as ContractDTO).ToString() + ".docx");
        }

        void ReplaceStrings()
        {
            FindReplace("{date}", dTPData.Value.ToShortDateString());
            FindReplace("{dateEnd}", dTPOkonch.Value.ToShortDateString());
            FindReplace("{typeSpec}", (cBSeller.SelectedItem as SellerDTO).TypeSpec);
            FindReplace("{number}", tBNumber.Text.ToString());
            FindReplace("{address}", "п.Советский");
            FindReplace("{fullNameCompanyCustomer}", (cBCustomer.SelectedItem as CustomerDTO).FullNameCompany);
            FindReplace("{fullNameCompanySeller}", (cBSeller.SelectedItem as SellerDTO).FullNameCompany);
            FindReplace("{nameCustomerSpec}", (cBCustomer.SelectedItem as CustomerDTO).NameCustomerSpec);
            FindReplace("{nameCustomer}", (cBCustomer.SelectedItem as CustomerDTO).NameCustomer);
            FindReplace("{nameSeller}", (cBSeller.SelectedItem as SellerDTO).NameSeller);
            FindReplace("{nameSellerSpec}", (cBSeller.SelectedItem as SellerDTO).NameSellerSpec);
            FindReplace("{addressCustomer}", (cBCustomer.SelectedItem as CustomerDTO).AddressCompany);
            FindReplace("{addressSeller}", (cBSeller.SelectedItem as SellerDTO).AddressCompany);
            FindReplace("{emailSeller}", (cBSeller.SelectedItem as SellerDTO).Email);
            FindReplace("{personalAccountCustomer}", (cBCustomer.SelectedItem as CustomerDTO).PersonalAccount);
            FindReplace("{corespAccountSeller}", (cBSeller.SelectedItem as SellerDTO).CorrespondentAccount);
            FindReplace("{bikCustomer}", (cBCustomer.SelectedItem as CustomerDTO).BIK.ToString());
            FindReplace("{bikSeller}", (cBSeller.SelectedItem as SellerDTO).BIK.ToString());
            FindReplace("{bikCustomer}", (cBCustomer.SelectedItem as CustomerDTO).BIK.ToString());
            FindReplace("{innCustomer}", (cBCustomer.SelectedItem as CustomerDTO).INN.ToString());
            FindReplace("{innSeller}", (cBSeller.SelectedItem as SellerDTO).INN.ToString());
            FindReplace("{kppCustomer}", (cBCustomer.SelectedItem as CustomerDTO).KPP.ToString());
            FindReplace("{kppSeller}", (cBSeller.SelectedItem as SellerDTO).KPP.ToString());
            FindReplace("{bankCustomer}", (cBCustomer.SelectedItem as CustomerDTO).Bank);
            FindReplace("{bankSeller}", (cBSeller.SelectedItem as SellerDTO).Bank);
            FindReplace("{bankAccountCustomer}", (cBCustomer.SelectedItem as CustomerDTO).BankAccount);
            FindReplace("{bankAccountSeller}", (cBSeller.SelectedItem as SellerDTO).BankAccount);
            FindReplace("{phoneSeller}", (cBSeller.SelectedItem as SellerDTO).PhoneNumber);
            FindReplace("{nameResponssable}", tBOtv.Text.ToString());
            FindReplace("{year}", dTPData.Value.Year.ToString());
            FindReplace("{total}", lSumm.Text.ToString());
            string replacedOfWord = ReplaceOfWord(float.Parse(lSumm.Text));
            if (lSumm.Text.Contains(','))
            {
                if (lSumm.Text.Substring(lSumm.Text.IndexOf(',')).Length - 1 == 2)
                {
                    FindReplace("{totalRub}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    FindReplace("{kopeiki}", lSumm.Text.Substring(lSumm.Text.IndexOf(',') + 1));
                }
                else
                {
                    FindReplace("{totalRub}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    FindReplace("{kopeiki}", lSumm.Text.Substring(lSumm.Text.IndexOf(',') + 1) + "0");
                }
            }
            else
            {
                FindReplace("{totalRub}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                FindReplace("{kopeiki}", "00");
            }
        }
        
        public void OpenFile()
        {
            app = new Microsoft.Office.Interop.Word.Application();
            app.Documents.Open(ref fileName);
            app.Visible = true;
        }

        public void OpenDocument(string fileName)
        {
            app = new Microsoft.Office.Interop.Word.Application();
            app.Documents.Open(fileName);
            app.Visible = true;
        }

        string ReplaceOfWord(float total)
        {
            return RusNumber.Str((int)total);
        }

        public void SaveFile(string fileName)
        {
            app.ActiveDocument.SaveAs(fileName);
        }

        public void FindReplace(string str_old, string str_new)
        {
            Find find = app.Selection.Find;

            find.Text = str_old; // текст поиска
            find.Replacement.Text = str_new; // текст замены

            find.Execute(FindText: System.Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                        MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true, Wrap: WdFindWrap.wdFindContinue,
                        Format: false, ReplaceWith: missing, Replace: WdReplace.wdReplaceAll);
        }

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            if (lBContracts.SelectedItem != null)
            {
                string pathDir = System.Windows.Forms.Application.StartupPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString().Substring(0, (lBContracts.SelectedItem as ContractDTO).ToString().Length - 1);
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
            else
            {
                string pathDir = System.Windows.Forms.Application.StartupPath + "\\Документы\\";
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            OpenDocument(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString().Substring(0, (lBContracts.SelectedItem as ContractDTO).ToString().Length - 1)+"\\"+ (lBContracts.SelectedItem as ContractDTO).ToString()+".docx");
        }
    }
    public class RusNumber
    {
        //Наименования сотен
        private static string[] hunds =
        {
            "", "сто ", "двести ", "триста ", "четыреста ",
            "пятьсот ", "шестьсот ", "семьсот ", "восемьсот ", "девятьсот "
        };
        //Наименования десятков
        private static string[] tens =
        {
            "", "десять ", "двадцать ", "тридцать ", "сорок ", "пятьдесят ",
            "шестьдесят ", "семьдесят ", "восемьдесят ", "девяносто "
        };
        /// <summary>
        /// Перевод в строку числа с учётом падежного окончания относящегося к числу существительного
        /// </summary>
        /// <param name="val">Число</param>
        /// <param name="male">Род существительного, которое относится к числу</param>
        /// <param name="one">Форма существительного в единственном числе</param>
        /// <param name="two">Форма существительного от двух до четырёх</param>
        /// <param name="five">Форма существительного от пяти и больше</param>
        /// <returns></returns>
        public static string Str(int val, bool male, string one, string two, string five)
        {
            string[] frac20 =
            {
                "", "один ", "два ", "три ", "четыре ", "пять ", "шесть ",
                "семь ", "восемь ", "девять ", "десять ", "одиннадцать ",
                "двенадцать ", "тринадцать ", "четырнадцать ", "пятнадцать ",
                "шестнадцать ", "семнадцать ", "восемнадцать ", "девятнадцать "
            };

            int num = val % 1000;
            if (0 == num) return "";
            if (num < 0) throw new ArgumentOutOfRangeException("val", "Параметр не может быть отрицательным");
            if (!male)
            {
                frac20[1] = "одна ";
                frac20[2] = "две ";
            }

            StringBuilder r = new StringBuilder(hunds[num / 100]);

            if (num % 100 < 20)
            {
                r.Append(frac20[num % 100]);
            }
            else
            {
                r.Append(tens[num % 100 / 10]);
                r.Append(frac20[num % 10]);
            }

            r.Append(Case(num, one, two, five));

            if (r.Length != 0) r.Append(" ");
            return r.ToString();
        }
        /// <summary>
        /// Выбор правильного падежного окончания сущесвительного
        /// </summary>
        /// <param name="val">Число</param>
        /// <param name="one">Форма существительного в единственном числе</param>
        /// <param name="two">Форма существительного от двух до четырёх</param>
        /// <param name="five">Форма существительного от пяти и больше</param>
        /// <returns>Возвращает существительное с падежным окончанием, которое соответсвует числу</returns>
        public static string Case(int val, string one, string two, string five)
        {
            int t = (val % 100 > 20) ? val % 10 : val % 20;

            switch (t)
            {
                case 1: return one;
                case 2: case 3: case 4: return two;
                default: return five;
            }
        }
        /// <summary>
        /// Перевод целого числа в строку
        /// </summary>
        /// <param name="val">Число</param>
        /// <returns>Возвращает строковую запись числа</returns>
        public static string Str(int val)
        {
            int n = (int)val;

            StringBuilder r = new StringBuilder();

            if (0 == n) r.Append("0 ");
            if (n % 1000 != 0)
                r.Append(RusNumber.Str(n, true, "", "", ""));

            n /= 1000;

            r.Insert(0, RusNumber.Str(n, false, "тысяча", "тысячи", "тысяч"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "миллион", "миллиона", "миллионов"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "миллиард", "миллиарда", "миллиардов"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "триллион", "триллиона", "триллионов"));
            n /= 1000;

            r.Insert(0, RusNumber.Str(n, true, "триллиард", "триллиарда", "триллиардов"));

            //Делаем первую букву заглавной
            r[0] = char.ToUpper(r[0]);

            return r.ToString();
        }
    }
}
