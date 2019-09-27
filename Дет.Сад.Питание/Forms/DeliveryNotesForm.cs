using DAL.DTO;
using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Servises.WordWorker;

namespace Дет.Сад.Питание.Forms
{
    public partial class DeliveryNotesForm : Form
    {
        public WordWorker WordWorker = new WordWorker(Application.StartupPath + "\\Документы\\Шаблоны\\Накладная.docx");

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
                    FileName = "\\Документы\\" + MainForm.DB.Contracts.Get((cBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString() + "\\Файлы\\Накладная №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".nakl"
                };
                MainForm.DB.DeliveryNotes.Create(deliveryNote);
                MainForm.DB.Save();
                string path = Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get((cBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString();
                string subpath = "Файлы\\";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                if (Directory.Exists(path))
                {
                    dirInfo.CreateSubdirectory(subpath);
                    Stream stream = new FileStream(Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get((cBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString() + "\\Файлы\\Накладная №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".nakl", FileMode.CreateNew);
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
            Stream stream = new FileStream(Application.StartupPath + (cBInvoices.SelectedItem as InvoiceDTO).FileName, FileMode.Open);
            List<ProductDTO> listInvoiceProducts = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
            ProductDTO productInInvoice = listInvoiceProducts.Single(x => x.Id == product.Id);
            productInInvoice.Balance -= product.Balance;
            listInvoiceProducts.Remove(listInvoiceProducts.Single(x => x.Id == product.Id));
            listInvoiceProducts.Add(productInInvoice);
            stream.Close();

            stream = new FileStream(Application.StartupPath + (cBInvoices.SelectedItem as InvoiceDTO).FileName, FileMode.OpenOrCreate);
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
                    string path = Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get(deliveryNote.InvoiceId).ContractId).ToString() + "\\Файлы\\Накладная №" + deliveryNote.Number.ToString() + " от " + deliveryNote.Date.ToLongDateString() + ".nakl";
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
                BuildDocument();
            }
        }

        private void BuildDocument()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    lLoad.Visible = true;
                    WordWorker.Load();

                    ReplaceStrings();
                    Word.Range range = WordWorker.doc.Paragraphs[WordWorker.doc.Paragraphs.Count].Range;
                    int i = 3;
                    foreach (ProductDTO product in addedProducts)
                    {
                        WordWorker.doc.Tables[2].Rows.Add();
                        i++;
                        WordWorker.doc.Tables[2].Cell(i, 1).Range.Text = (i - 3).ToString();
                        WordWorker.doc.Tables[2].Cell(i, 2).Range.Text = product.Name;
                        WordWorker.doc.Tables[2].Cell(i, 4).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                        WordWorker.doc.Tables[2].Cell(i, 10).Range.Text = product.Balance.ToString();
                        WordWorker.doc.Tables[2].Cell(i, 11).Range.Text = product.Price.ToString();
                        WordWorker.doc.Tables[2].Cell(i, 12).Range.Text = Math.Round(product.Balance * product.Price, 2).ToString();
                        WordWorker.doc.Tables[2].Cell(i, 13).Range.Text = "БЕЗ НДС";
                        WordWorker.doc.Tables[2].Cell(i, 15).Range.Text = Math.Round(product.Balance * product.Price, 2).ToString();
                    }
                    WordWorker.doc.Tables[2].Rows.Add();
                    i++;
                    WordWorker.doc.Tables[2].Cell(i, 1).Range.Text = "Итого";
                    WordWorker.doc.Tables[2].Cell(i, 11).Range.Text = "X";
                    WordWorker.doc.Tables[2].Cell(i, 12).Range.Text = lSumm.Text;
                    WordWorker.doc.Tables[2].Cell(i, 13).Range.Text = "X";
                    WordWorker.doc.Tables[2].Cell(i, 15).Range.Text = lSumm.Text;

                    WordWorker.Save(Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString() + "\\" + (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".docx");

                    WordWorker.Close();
                    lLoad.Visible = false;
                }
            }
            catch (Exception ex)
            {
                WordWorker.Close();
                throw new Exception("Во время выполнения произошла ошибка!");
            }
        }
        void ReplaceStrings()
        {
            ContractDTO contract = MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId);
            InvoiceDTO invoice = MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId);
            WordWorker.FindReplace("{dateNakl}", dTPData.Value.ToShortDateString());
            WordWorker.FindReplace("{contractName}", contract.ToString());
            WordWorker.FindReplace("{invoiceName}", invoice.ToString());
            WordWorker.FindReplace("{numberNakl}", tBNumber.Text.ToString());
            WordWorker.FindReplace("{nameCompanySeller}", MainForm.DB.Sellers.Get(contract.SellerId).NameCompany);
            WordWorker.FindReplace("{nameCompanyCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).NameCompany);
            WordWorker.FindReplace("{fullNameCompanySeller}", MainForm.DB.Sellers.Get(contract.SellerId).FullNameCompany);
            WordWorker.FindReplace("{fullNameCompanyCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).FullNameCompany);
            WordWorker.FindReplace("{nameSeller}", MainForm.DB.Sellers.Get(contract.SellerId).NameSeller);
            WordWorker.FindReplace("{addressCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).AddressCompany);
            WordWorker.FindReplace("{addressSeller}", MainForm.DB.Sellers.Get(contract.SellerId).AddressCompany);
            WordWorker.FindReplace("{innCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).INN.ToString());
            WordWorker.FindReplace("{innSeller}", MainForm.DB.Sellers.Get(contract.SellerId).INN.ToString());
            WordWorker.FindReplace("{kppCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).KPP.ToString());
            WordWorker.FindReplace("{kppSeller}", MainForm.DB.Sellers.Get(contract.SellerId).KPP.ToString());
            WordWorker.FindReplace("{personalAccountCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).PersonalAccount);
            WordWorker.FindReplace("{corespAccountSeller}", MainForm.DB.Sellers.Get(contract.SellerId).CorrespondentAccount);
            WordWorker.FindReplace("{bikCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).BIK.ToString());
            WordWorker.FindReplace("{bikSeller}", MainForm.DB.Sellers.Get(contract.SellerId).BIK.ToString());
            WordWorker.FindReplace("{bikCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).BIK.ToString());
            WordWorker.FindReplace("{bankCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).Bank);
            WordWorker.FindReplace("{bankSeller}", MainForm.DB.Sellers.Get(contract.SellerId).Bank);
            WordWorker.FindReplace("{bankAccountCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).BankAccount);
            WordWorker.FindReplace("{bankAccountSeller}", MainForm.DB.Sellers.Get(contract.SellerId).BankAccount);
            WordWorker.FindReplace("{priemName}", tBPriemName.Text);
            WordWorker.FindReplace("{gruzName}", tBGruzName.Text);

            string replacedOfWord = WordWorker.ReplaceOfWord(float.Parse(lSumm.Text));
            if (lSumm.Text.Contains(','))
            {
                if (lSumm.Text.Substring(lSumm.Text.IndexOf(',')).Length - 1 == 2)
                {
                    WordWorker.FindReplace("{total}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    WordWorker.FindReplace("{kopeiki}", lSumm.Text.Substring(lSumm.Text.IndexOf(',') + 1));
                }
                else
                {
                    WordWorker.FindReplace("{total}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    WordWorker.FindReplace("{kopeiki}", lSumm.Text.Substring(lSumm.Text.IndexOf(',') + 1) + "0");
                }
            }
            else
            {
                WordWorker.FindReplace("{total}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                WordWorker.FindReplace("{kopeiki}", "00");
            }
        }

        public void OpenDocument(string fileName)
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                WordWorker.Open(fileName);
            }
            lLoad.Visible = false;
        }

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            if (lBDeliveryNotes.SelectedItem != null)
            {
                string pathDir = Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Substring(0, MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Length - 1);
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
        }

        private void ButAddProduct_Click(object sender, EventArgs e)
        {
            AddProductInDeliveryNote addProductInDeliveryNote = new AddProductInDeliveryNote(this, Application.StartupPath + MainForm.DB.Invoices.Get((cBInvoices.SelectedItem as InvoiceDTO).Id).FileName);
            addProductInDeliveryNote.ShowDialog();
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            if(lBDeliveryNotes.SelectedItem != null)
                OpenDocument(Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Substring(0, MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Length - 1) + "\\" + (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".docx");
        }
    }
}
