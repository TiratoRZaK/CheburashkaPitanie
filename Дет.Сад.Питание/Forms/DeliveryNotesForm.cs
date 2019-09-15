using DAL.DTO;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class DeliveryNotesForm : Form
    {
        public static Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        public static string generalfile = System.Windows.Forms.Application.StartupPath + "\\Документы\\Шаблоны\\Накладная.docx"; // файл-шаблон
        public static Object fileName = generalfile;
        public static Object missing = System.Type.Missing;
        public static bool checkOpenDoc = false;

        public DeliveryNoteDTO deliveryNote = null;
        public List<ProductDTO> addedProducts;
        public MainForm main;
        public DeliveryNotesForm(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeListBoxes();
            ButAddDeliveryNote_Click(this, new EventArgs());
        }

        void InitializeListBoxes()
        {
            foreach (var item in MainForm.DB.DeliveryNotes.GetAll())
            {
                lBDeliveryNotes.Items.Add(item);
            }
            cBInvoices.DataSource = MainForm.DB.Invoices.GetAll();
        }

        private void DeliveryNotesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
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

        private void ButAddDeliveryNote_Click(object sender, EventArgs e)
        {
            if (pData.Enabled == false)
            {
                pDeliveryNotes.Enabled = false;
                pData.Enabled = true;
                pProducts.Enabled = true;
                butAddDeliveryNote.BackColor = Color.Blue;
                butAddDeliveryNote.Text = "Отменить добавление";
                lBDeliveryNotes.Enabled = false;
                lDeliveryNote.Text = "Новая накладная";
                lDeliveryNote.Enabled = false;
                butSave.Enabled = true;
                deliveryNote = new DeliveryNoteDTO();
                addedProducts = new List<ProductDTO>();
                ReloadedData();
            }
            else
            {
                pDeliveryNotes.Enabled = true;
                pData.Enabled = false;
                pProducts.Enabled = false;
                butAddDeliveryNote.BackColor = Color.LimeGreen;
                butAddDeliveryNote.Text = "Добавить новую накладную";
                lBDeliveryNotes.Enabled = true;
                lDeliveryNote.Enabled = true;
                if ((lBDeliveryNotes.SelectedItem) != null)
                    lDeliveryNote.Text = (lBDeliveryNotes.SelectedItem).ToString();
                else lDeliveryNote.Text = "Не выбрана";
            }
        }

        private void LBDeliveryNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lBDeliveryNotes.SelectedItem != null)
            {
                butOpen.Enabled = true;
                butDirectory.Enabled = true;
                butDel.Enabled = true;
                butBuild.Enabled = true;
                lDeliveryNote.Text = lBDeliveryNotes.Text;
                tBNumber.Text = (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).Number.ToString();
                dTPData.Value = (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).Date;
                tBPriemName.Text = (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).PriemName;
                tBGruzName.Text = (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).GruzName;
                cBInvoices.SelectedItem = MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId);
                dGVProducts.Rows.Clear();
                Stream stream = new FileStream(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString() + "\\Файлы\\" + (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".nakl", FileMode.Open);
                addedProducts = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
                stream.Close();
                ReloadedData();
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (tBNumber.Text.Length != 0 && cBInvoices.SelectedItem != null && dGVProducts.Rows.Count != 0)
            {
                float Total = 0;
                foreach (var item in addedProducts)
                {
                    Total += item.Balance * item.Price;
                    AddProduct(item);
                }
                deliveryNote = new DeliveryNoteDTO
                {
                    Number = int.Parse(tBNumber.Text),
                    Date = dTPData.Value,
                    InvoiceId = (cBInvoices.SelectedItem as InvoiceDTO).Id,
                    PriemName = tBPriemName.Text,
                    GruzName = tBGruzName.Text,
                    FileName = System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get((cBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString() + "\\Файлы\\Накладная №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".nakl"
                };
                MainForm.DB.DeliveryNotes.Create(deliveryNote);
                MainForm.DB.Save();
                string path = System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get((cBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString();
                string subpath = "Файлы\\";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                if (Directory.Exists(path))
                {
                    dirInfo.CreateSubdirectory(subpath);
                    Stream stream = new FileStream(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get((cBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString() + "\\Файлы\\Накладная №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".nakl", FileMode.CreateNew);
                    var serializer = new BinaryFormatter();
                    serializer.Serialize(stream, addedProducts);
                    stream.Close();
                }
                ReloadedDeliveryNotes();
                MessageBox.Show("Накладная успешно сохранена и продукты добавлены на склад");
                ButAddDeliveryNote_Click(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Не все обязательные поля заполнены или список продуктов пуст!", "Ошибка сохранения накладной");
            }
        }

        private void AddProduct(ProductDTO product)
        {
            ProductDTO dbProduct = MainForm.DB.Products.Get(product.Id);
            float newBalance = (dbProduct.Balance + product.Balance);
            dbProduct.Price = (float)Math.Round(((double)((dbProduct.Price * dbProduct.Balance) + (product.Balance * product.Price)) / newBalance), 2);
            dbProduct.Balance = newBalance;
            MainForm.DB.Products.Update(dbProduct);
            MainForm.DB.Save();
            Stream stream = new FileStream((cBInvoices.SelectedItem as InvoiceDTO).FileName, FileMode.Open);
            List<ProductDTO> listInvoiceProducts = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
            ProductDTO productInInvoice = listInvoiceProducts.Single(x => x.Id == product.Id);
            productInInvoice.Balance -= product.Balance;
            listInvoiceProducts.Remove(listInvoiceProducts.Single(x => x.Id == product.Id));
            listInvoiceProducts.Add(productInInvoice);
            stream.Close();

            stream = new FileStream((cBInvoices.SelectedItem as InvoiceDTO).FileName, FileMode.OpenOrCreate);
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, listInvoiceProducts);
            stream.Close();
        }

        private void ReloadedDeliveryNotes()
        {
            lBDeliveryNotes.Items.Clear();
            foreach (var item in MainForm.DB.DeliveryNotes.GetAll())
            {
                lBDeliveryNotes.Items.Add(item);
            }
        }

        private void ButCleanProducts_Click(object sender, EventArgs e)
        {
            dGVProducts.Rows.Clear();
            addedProducts.Clear();
        }

        private void DGVProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
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
            if (lBDeliveryNotes.SelectedItem != null)
            {
                var deliveryNote = MainForm.DB.DeliveryNotes.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).Id);
                if (MessageBox.Show("Вы уверены что хотите удалить накладную №" + deliveryNote.Number.ToString() + "?", "Удаление накладной", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string path = System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get(deliveryNote.InvoiceId).ContractId).ToString() + "\\Файлы\\Накладная №" + deliveryNote.Number.ToString() + " от " + deliveryNote.Date.ToLongDateString() + ".nakl";
                    File.Delete(path);
                }
                MainForm.DB.DeliveryNotes.Delete(deliveryNote.Id);
                MainForm.DB.Save();
                ReloadedDeliveryNotes();
            }
        }

        private void ButBuild_Click(object sender, EventArgs e)
        {
            if (lBDeliveryNotes.SelectedItem != null)
            {
                if (checkOpenDoc)
                {
                    app = new Microsoft.Office.Interop.Word.Application();
                }
                checkOpenDoc = true;
                BuildDocument();
            }
        }

        private void BuildDocument()
        {
            OpenFile();
            ReplaceStrings();
            Document document = app.ActiveDocument;
            Range range = document.Paragraphs[document.Paragraphs.Count].Range;
            int i = 3;
            foreach (ProductDTO product in addedProducts)
            {
                document.Tables[2].Rows.Add();
                i++;
                document.Tables[2].Cell(i,1).Range.Text = (i-3).ToString();
                document.Tables[2].Cell(i,2).Range.Text = product.Name;
                document.Tables[2].Cell(i,4).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                document.Tables[2].Cell(i,10).Range.Text = product.Balance.ToString();
                document.Tables[2].Cell(i,11).Range.Text = product.Price.ToString();
                document.Tables[2].Cell(i,12).Range.Text = Math.Round(product.Balance * product.Price, 2).ToString();
                document.Tables[2].Cell(i,13).Range.Text = "БЕЗ НДС";
                document.Tables[2].Cell(i,15).Range.Text = Math.Round(product.Balance * product.Price, 2).ToString();
            }
            document.Tables[2].Rows.Add();
            i++;
            document.Tables[2].Cell(i,1).Range.Text = "Итого";
            document.Tables[2].Cell(i,11).Range.Text = "X";
            document.Tables[2].Cell(i,12).Range.Text = lSumm.Text;
            document.Tables[2].Cell(i,13).Range.Text = "X";
            document.Tables[2].Cell(i,15).Range.Text = lSumm.Text;

            SaveFile(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString() + "\\" + (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".docx");

        }
        void ReplaceStrings()
        {
            ContractDTO contract = MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId);
            InvoiceDTO invoice = MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId);
            FindReplace("{dateNakl}", dTPData.Value.ToShortDateString());
            FindReplace("{contractName}", contract.ToString());
            FindReplace("{invoiceName}", invoice.ToString());
            FindReplace("{numberNakl}", tBNumber.Text.ToString());
            FindReplace("{nameCompanySeller}", MainForm.DB.Sellers.Get(contract.SellerId).NameCompany);
            FindReplace("{nameCompanyCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).NameCompany);
            FindReplace("{fullNameCompanySeller}", MainForm.DB.Sellers.Get(contract.SellerId).FullNameCompany);
            FindReplace("{fullNameCompanyCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).FullNameCompany);
            FindReplace("{nameSeller}", MainForm.DB.Sellers.Get(contract.SellerId).NameSeller);
            FindReplace("{addressCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).AddressCompany);
            FindReplace("{addressSeller}", MainForm.DB.Sellers.Get(contract.SellerId).AddressCompany);
            FindReplace("{innCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).INN.ToString());
            FindReplace("{innSeller}", MainForm.DB.Sellers.Get(contract.SellerId).INN.ToString());
            FindReplace("{kppCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).KPP.ToString());
            FindReplace("{kppSeller}", MainForm.DB.Sellers.Get(contract.SellerId).KPP.ToString());
            FindReplace("{personalAccountCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).PersonalAccount);
            FindReplace("{corespAccountSeller}", MainForm.DB.Sellers.Get(contract.SellerId).CorrespondentAccount);
            FindReplace("{bikCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).BIK.ToString());
            FindReplace("{bikSeller}", MainForm.DB.Sellers.Get(contract.SellerId).BIK.ToString());
            FindReplace("{bikCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).BIK.ToString());
            FindReplace("{bankCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).Bank);
            FindReplace("{bankSeller}", MainForm.DB.Sellers.Get(contract.SellerId).Bank);
            FindReplace("{bankAccountCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).BankAccount);
            FindReplace("{bankAccountSeller}", MainForm.DB.Sellers.Get(contract.SellerId).BankAccount);
            FindReplace("{priemName}", tBPriemName.Text);
            FindReplace("{gruzName}", tBGruzName.Text);

            string replacedOfWord = ReplaceOfWord(float.Parse(lSumm.Text));
            if (lSumm.Text.Contains(','))
            {
                if (lSumm.Text.Substring(lSumm.Text.IndexOf(',')).Length - 1 == 2)
                {
                    FindReplace("{total}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    FindReplace("{kopeiki}", lSumm.Text.Substring(lSumm.Text.IndexOf(',') + 1));
                }
                else
                {
                    FindReplace("{total}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    FindReplace("{kopeiki}", lSumm.Text.Substring(lSumm.Text.IndexOf(',') + 1) + "0");
                }
            }
            else
            {
                FindReplace("{total}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                FindReplace("{kopeiki}", "00");
            }
        }

        public void OpenDocument(string fileName)
        {
            app = new Microsoft.Office.Interop.Word.Application();
            app.Documents.Open(fileName);
            app.Visible = true;
        }

        public void OpenFile()
        {
            app = new Microsoft.Office.Interop.Word.Application();
            app.Documents.Open(ref fileName);
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
            if (lBDeliveryNotes.SelectedItem != null)
            {
                string pathDir = System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Substring(0, MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Length - 1);
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
        }

        private void ButAddProduct_Click(object sender, EventArgs e)
        {
            AddProductInDeliveryNote addProductInDeliveryNote = new AddProductInDeliveryNote(this, MainForm.DB.Invoices.Get((cBInvoices.SelectedItem as InvoiceDTO).Id).FileName);
            addProductInDeliveryNote.ShowDialog();
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            if(lBDeliveryNotes.SelectedItem != null)
                OpenDocument(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Substring(0, MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Length - 1) + "\\" + (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".docx");
        }

        private void DeliveryNotesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
