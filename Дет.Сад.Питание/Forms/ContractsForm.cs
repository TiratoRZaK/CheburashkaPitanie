using DAL.DTO;
using Servises.WordWorker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Дет.Сад.Питание.Forms
{
    public partial class ContractsForm : Form
    {
        public WordWorker WordWorker = new WordWorker(Application.StartupPath + "\\Документы\\Шаблоны\\Договор.docx");

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
                Stream stream = new FileStream(Application.StartupPath + (lBContracts.SelectedItem as ContractDTO).FileName, FileMode.Open);
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
                        FileName = "\\Документы\\"+"Контракт №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString()+"\\contract.cont",
                        Total = (float)Math.Round(Total, 2)
                    };
                    MainForm.DB.Contracts.Create(contract);
                    MainForm.DB.Save();
                    string path = Application.StartupPath + "\\Документы\\";
                    string subpath = contract.ToString();
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (!dirInfo.Exists)
                    {
                        dirInfo.Create();
                    }
                    if (!Directory.Exists(path + contract.ToString()))
                    {
                        dirInfo.CreateSubdirectory(subpath);
                        Stream stream = new FileStream(Application.StartupPath + "\\Документы\\" + contract.ToString() + "\\contract.cont", FileMode.CreateNew);
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
                    string path = Application.StartupPath + "\\Документы\\"+contr.ToString();
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
            BuildContract();
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
            try
            {
                DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'","ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    lLoad.Visible = true;
                    WordWorker.Load();
                    ReplaceStrings();
                    Word.Range range = WordWorker.doc.Paragraphs[WordWorker.doc.Paragraphs.Count].Range;
                    int i = 1;
                    List<int> mergesRows = new List<int>();
                    foreach (string item in types)
                    {
                        WordWorker.doc.Tables[4].Rows.Add();
                        i++;
                        mergesRows.Add(i);
                        WordWorker.doc.Tables[4].Rows[i].Range.Bold = 0;
                        WordWorker.doc.Tables[4].Rows[i].Height = float.Parse("0,3");
                        WordWorker.doc.Tables[4].Rows[i].Cells[1].Range.Text = item;
                        foreach (ProductDTO product in addedProducts.Where(x => MainForm.DB.Types.Get(x.TypeId).Name == item))
                        {
                            WordWorker.doc.Tables[4].Rows.Add();
                            i++;
                            WordWorker.doc.Tables[4].Cell(i, 1).Range.Text = product.Name;
                            WordWorker.doc.Tables[4].Cell(i, 2).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                            WordWorker.doc.Tables[4].Cell(i, 3).Range.Text = product.Price.ToString();
                            WordWorker.doc.Tables[4].Cell(i, 4).Range.Text = "-";
                            WordWorker.doc.Tables[4].Cell(i, 5).Range.Text = product.Balance.ToString();
                            WordWorker.doc.Tables[4].Cell(i, 6).Range.Text = Math.Round((product.Price * product.Balance), 2).ToString();
                            WordWorker.doc.Tables[4].Cell(i, 7).Range.Text = "0";
                        }
                    }
                    foreach (var item in mergesRows)
                        WordWorker.doc.Tables[4].Rows[item].Cells[1].Merge(WordWorker.doc.Tables[4].Rows[item].Cells[7]);
                    WordWorker.doc.Tables[4].Rows.Add();
                    i++;
                    WordWorker.doc.Tables[4].Rows[i].Range.Bold = 0;
                    WordWorker.doc.Tables[4].Rows[i].Height = float.Parse("0,3");
                    WordWorker.doc.Tables[4].Cell(i, 1).Range.Text = "Итого";
                    WordWorker.doc.Tables[4].Cell(i, 6).Range.Text = lSumm.Text;
                    WordWorker.Save(Application.StartupPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString() + "\\" + (lBContracts.SelectedItem as ContractDTO).ToString() + ".docx");
                    WordWorker.Close();
                    lLoad.Visible = false;
                }
            } catch(Exception ex)
            {
                WordWorker.Close();
                throw new Exception("Во время выполнения произошла ошибка!");
            }
        }

        void ReplaceStrings()
        {
            WordWorker.FindReplace("{date}", dTPData.Value.ToShortDateString());
            WordWorker.FindReplace("{dateEnd}", dTPOkonch.Value.ToShortDateString());
            WordWorker.FindReplace("{typeSpec}", (cBSeller.SelectedItem as SellerDTO).TypeSpec);
            WordWorker.FindReplace("{number}", tBNumber.Text.ToString());
            WordWorker.FindReplace("{address}", "п.Советский");
            WordWorker.FindReplace("{fullNameCompanyCustomer}", (cBCustomer.SelectedItem as CustomerDTO).FullNameCompany);
            WordWorker.FindReplace("{fullNameCompanySeller}", (cBSeller.SelectedItem as SellerDTO).FullNameCompany);
            WordWorker.FindReplace("{nameCustomerSpec}", (cBCustomer.SelectedItem as CustomerDTO).NameCustomerSpec);
            WordWorker.FindReplace("{nameCustomer}", (cBCustomer.SelectedItem as CustomerDTO).NameCustomer);
            WordWorker.FindReplace("{nameSeller}", (cBSeller.SelectedItem as SellerDTO).NameSeller);
            WordWorker.FindReplace("{nameSellerSpec}", (cBSeller.SelectedItem as SellerDTO).NameSellerSpec);
            WordWorker.FindReplace("{addressCustomer}", (cBCustomer.SelectedItem as CustomerDTO).AddressCompany);
            WordWorker.FindReplace("{addressSeller}", (cBSeller.SelectedItem as SellerDTO).AddressCompany);
            WordWorker.FindReplace("{emailSeller}", (cBSeller.SelectedItem as SellerDTO).Email);
            WordWorker.FindReplace("{personalAccountCustomer}", (cBCustomer.SelectedItem as CustomerDTO).PersonalAccount);
            WordWorker.FindReplace("{corespAccountSeller}", (cBSeller.SelectedItem as SellerDTO).CorrespondentAccount);
            WordWorker.FindReplace("{bikCustomer}", (cBCustomer.SelectedItem as CustomerDTO).BIK.ToString());
            WordWorker.FindReplace("{bikSeller}", (cBSeller.SelectedItem as SellerDTO).BIK.ToString());
            WordWorker.FindReplace("{bikCustomer}", (cBCustomer.SelectedItem as CustomerDTO).BIK.ToString());
            WordWorker.FindReplace("{innCustomer}", (cBCustomer.SelectedItem as CustomerDTO).INN.ToString());
            WordWorker.FindReplace("{innSeller}", (cBSeller.SelectedItem as SellerDTO).INN.ToString());
            WordWorker.FindReplace("{kppCustomer}", (cBCustomer.SelectedItem as CustomerDTO).KPP.ToString());
            WordWorker.FindReplace("{kppSeller}", (cBSeller.SelectedItem as SellerDTO).KPP.ToString());
            WordWorker.FindReplace("{bankCustomer}", (cBCustomer.SelectedItem as CustomerDTO).Bank);
            WordWorker.FindReplace("{bankSeller}", (cBSeller.SelectedItem as SellerDTO).Bank);
            WordWorker.FindReplace("{bankAccountCustomer}", (cBCustomer.SelectedItem as CustomerDTO).BankAccount);
            WordWorker.FindReplace("{bankAccountSeller}", (cBSeller.SelectedItem as SellerDTO).BankAccount);
            WordWorker.FindReplace("{phoneSeller}", (cBSeller.SelectedItem as SellerDTO).PhoneNumber);
            WordWorker.FindReplace("{nameResponssable}", tBOtv.Text.ToString());
            WordWorker.FindReplace("{year}", dTPData.Value.Year.ToString());
            WordWorker.FindReplace("{total}", lSumm.Text.ToString());
            string replacedOfWord = WordWorker.ReplaceOfWord(float.Parse(lSumm.Text));
            if (lSumm.Text.Contains(','))
            {
                if (lSumm.Text.Substring(lSumm.Text.IndexOf(',')).Length - 1 == 2)
                {
                    WordWorker.FindReplace("{totalRub}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    WordWorker.FindReplace("{kopeiki}", lSumm.Text.Substring(lSumm.Text.IndexOf(',') + 1));
                }
                else
                {
                    WordWorker.FindReplace("{totalRub}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    WordWorker.FindReplace("{kopeiki}", lSumm.Text.Substring(lSumm.Text.IndexOf(',') + 1) + "0");
                }
            }
            else
            {
                WordWorker.FindReplace("{totalRub}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                WordWorker.FindReplace("{kopeiki}", "00");
            }
        }

        public void OpenDocument(string path)
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                WordWorker.Open(path);
            }
            lLoad.Visible = false;
        }

       

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            if (lBContracts.SelectedItem != null)
            {
                string pathDir = Application.StartupPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString().Substring(0, (lBContracts.SelectedItem as ContractDTO).ToString().Length - 1);
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
            else
            {
                string pathDir = Application.StartupPath + "\\Документы\\";
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    lLoad.Visible = true;
                    WordWorker.Open(Application.StartupPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString().Substring(0, (lBContracts.SelectedItem as ContractDTO).ToString().Length - 1)+"\\"+ (lBContracts.SelectedItem as ContractDTO).ToString()+".docx");
                    lLoad.Visible = false;
                }
            }
            catch (Exception ex)
            {
                WordWorker.Close();
                throw new Exception("Во время выполнения произошла ошибка!");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }
    }
}
