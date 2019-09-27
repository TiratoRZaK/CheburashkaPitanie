using DAL.DTO;
using Servises.WordWorker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Дет.Сад.Питание.Forms
{
    public partial class InvoicesForm : Form
    {
        public WordWorker WordWorker = new WordWorker(Application.StartupPath + "\\Документы\\Шаблоны\\Счёт-фактура.docx");        public InvoiceDTO invoice = null;
        public List<ProductDTO> addedProducts;
        public MainForm main;

        public InvoicesForm(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeListBoxes();
            ButAddInvoice_Click(this, new EventArgs());
        }

        void InitializeListBoxes()
        {
            foreach (var item in MainForm.DB.Invoices.GetAll())
            {
                lBInvoices.Items.Add(item);
            }
            cBContracts.DataSource = MainForm.DB.Contracts.GetAll();
        }

        private void InvoicesForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void ButAddInvoice_Click(object sender, EventArgs e)
        {
            if (pData.Enabled == false)
            {
                pInvoices.Enabled = false;
                pData.Enabled = true;
                pProducts.Enabled = true;
                butAddInvoice.BackColor = Color.Blue;
                butAddInvoice.Text = "Отменить добавление";
                lBInvoices.Enabled = false;
                lInvoice.Text = "Новая счёт-фактура";
                lInvoice.Enabled = false;
                butSave.Enabled = true;
                invoice = new InvoiceDTO();
                addedProducts = new List<ProductDTO>();
                ReloadedData();
            }
            else
            {
                pInvoices.Enabled = true;
                pData.Enabled = false;
                pProducts.Enabled = false;
                butAddInvoice.BackColor = Color.LimeGreen;
                butAddInvoice.Text = "Добавить новую счёт-фактуру";
                lBInvoices.Enabled = true;
                lInvoice.Enabled = true;
                if ((lBInvoices.SelectedItem) != null)
                    lInvoice.Text = (lBInvoices.SelectedItem).ToString();
                else lInvoice.Text = "Не выбрана";
            }
        }

        private void LBInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lBInvoices.SelectedItem != null)
            {
                butBuild.Enabled = true;
                butDirectory.Enabled = true;
                butDel.Enabled = true;
                butOpen.Enabled = true;
                lInvoice.Text = lBInvoices.Text;
                tBNumber.Text = (lBInvoices.SelectedItem as InvoiceDTO).Number.ToString();
                dTPData.Value = (lBInvoices.SelectedItem as InvoiceDTO).Date;
                cBContracts.SelectedItem = MainForm.DB.Contracts.Get((lBInvoices.SelectedItem as InvoiceDTO).ContractId);
                dGVProducts.Rows.Clear();
                Stream stream = new FileStream(Application.StartupPath + "\\Документы\\" + (cBContracts.SelectedItem as ContractDTO).ToString() + "\\Файлы\\" + (lBInvoices.SelectedItem as InvoiceDTO).ToString() + ".invo", FileMode.Open);
                addedProducts = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
                stream.Close();
                ReloadedData();
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (tBNumber.Text.Length != 0 && cBContracts.SelectedItem != null && dGVProducts.Rows.Count != 0)
            {
                float Total = 0;
                foreach (var item in addedProducts)
                {
                    Total += item.Balance * item.Price;
                    AddProduct(item);
                }
                invoice = new InvoiceDTO
                {
                    Number = int.Parse(tBNumber.Text),
                    Date = dTPData.Value,
                    ContractId = (cBContracts.SelectedItem as ContractDTO).Id,
                    FileName = "\\Документы\\" + (cBContracts.SelectedItem as ContractDTO).ToString() + "\\Файлы\\Счёт-фактура №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".invo",
                    Total = (float)Math.Round(Total, 2)
                };
                MainForm.DB.Invoices.Create(invoice);
                MainForm.DB.Save();
                string path = Application.StartupPath + "\\Документы\\" + (cBContracts.SelectedItem as ContractDTO).ToString();
                string subpath = "Файлы\\";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                if (Directory.Exists(path))
                {
                    dirInfo.CreateSubdirectory(subpath);
                    Stream stream = new FileStream(Application.StartupPath + "\\Документы\\" + (cBContracts.SelectedItem as ContractDTO).ToString() + "\\Файлы\\Счёт-фактура №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".invo", FileMode.CreateNew);
                    var serializer = new BinaryFormatter();
                    serializer.Serialize(stream, addedProducts);
                    stream.Close();
                }
                ReloadedInvoices();
                MessageBox.Show("Счёт-фактура успешно сохранена");
                ButAddInvoice_Click(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Не все обязательные поля заполнены или список продуктов пуст!", "Ошибка сохранения счёт-фактуры");
            }
        }

        private void AddProduct(ProductDTO product)
        {
            Stream stream = new FileStream(Application.StartupPath + (cBContracts.SelectedItem as ContractDTO).FileName, FileMode.Open);
            List<ProductDTO> listContractProducts = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
            ProductDTO productInDb = listContractProducts.Single(x => x.Id == product.Id);
            productInDb.Balance -= product.Balance;
            listContractProducts.Remove(listContractProducts.Single(x => x.Id == product.Id));
            listContractProducts.Add(productInDb);
            stream.Close();

            stream = new FileStream(Application.StartupPath + (cBContracts.SelectedItem as ContractDTO).FileName, FileMode.OpenOrCreate);
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, listContractProducts);
            stream.Close();
        }

        private void ReloadedInvoices()
        {
            lBInvoices.Items.Clear();
            foreach (var item in MainForm.DB.Invoices.GetAll())
            {
                lBInvoices.Items.Add(item);
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
            if (lBInvoices.SelectedItem != null)
            {
                var invoice = MainForm.DB.Invoices.Get((lBInvoices.SelectedItem as InvoiceDTO).Id);
                if (MessageBox.Show("Вы уверены что хотите удалить счёт-фактуру №" + invoice.Number.ToString() + "?", "Удаление счёт-фактуры", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string path = Application.StartupPath + "\\Документы\\" + invoice.Contract.ToString() + "\\Файлы\\Счёт-фактура №" + invoice.Number.ToString() + " от " + invoice.Date.ToLongDateString() + ".invo";
                    File.Delete(path);
                }
                MainForm.DB.Invoices.Delete(invoice.Id);
                MainForm.DB.Save();
                ReloadedInvoices();
            }
        }

        private void ButBuild_Click(object sender, EventArgs e)
        {
            if (lBInvoices.SelectedItem != null)
            {
                BuildContract();
            }
        }

        private void BuildContract()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    lLoad.Visible = true;
                    WordWorker.Load();
                    ReplaceStrings();
                    int i = 1;
                    foreach (ProductDTO product in addedProducts)
                    {
                        WordWorker.doc.Tables[1].Rows.Add();
                        i++;
                        WordWorker.doc.Tables[1].Rows[i].Height = (float)12;
                        WordWorker.doc.Tables[1].Cell(i, 1).Range.Text = product.Name;
                        WordWorker.doc.Tables[1].Cell(i, 2).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                        WordWorker.doc.Tables[1].Cell(i, 3).Range.Text = product.Balance.ToString();
                        WordWorker.doc.Tables[1].Cell(i, 4).Range.Text = product.Price.ToString();
                        WordWorker.doc.Tables[1].Cell(i, 5).Range.Text = Math.Round(product.Balance * product.Price, 2).ToString();
                        WordWorker.doc.Tables[1].Cell(i, 7).Range.Text = "БЕЗ НДС";
                    }
                    WordWorker.doc.Tables[1].Rows.Add();
                    i++;
                    WordWorker.doc.Tables[1].Rows[i].Range.Bold = 1;
                    WordWorker.doc.Tables[1].Cell(i, 1).Range.Text = "Итого";
                    WordWorker.doc.Tables[1].Cell(i, 5).Range.Text = lSumm.Text;

                    WordWorker.Save(Application.StartupPath + "\\Документы\\" + (cBContracts.SelectedItem as ContractDTO).ToString() + "\\" + (lBInvoices.SelectedItem as InvoiceDTO).ToString() + ".docx");
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
            WordWorker.FindReplace("{date}", dTPData.Value.ToShortDateString());
            WordWorker.FindReplace("{contractDate}", (cBContracts.SelectedItem as ContractDTO).ConclusionDate.ToLongDateString());
            WordWorker.FindReplace("{contractNumber}", (cBContracts.SelectedItem as ContractDTO).Number.ToString());
            WordWorker.FindReplace("{number}", tBNumber.Text.ToString());
            WordWorker.FindReplace("{NameCompanySeller}", MainForm.DB.Sellers.Get((cBContracts.SelectedItem as ContractDTO).SellerId).NameCompany);
            WordWorker.FindReplace("{nameCompanyCustomer}", MainForm.DB.Customers.Get((cBContracts.SelectedItem as ContractDTO).CustomerId).NameCompany);
            WordWorker.FindReplace("{nameSeller}", MainForm.DB.Sellers.Get((cBContracts.SelectedItem as ContractDTO).SellerId).NameSeller);
            WordWorker.FindReplace("{addressCustomer}", MainForm.DB.Customers.Get((cBContracts.SelectedItem as ContractDTO).CustomerId).AddressCompany);
            WordWorker.FindReplace("{addressSeller}", MainForm.DB.Sellers.Get((cBContracts.SelectedItem as ContractDTO).SellerId).AddressCompany);
            WordWorker.FindReplace("{innCustomer}", MainForm.DB.Customers.Get((cBContracts.SelectedItem as ContractDTO).CustomerId).INN.ToString());
            WordWorker.FindReplace("{innSeller}", MainForm.DB.Sellers.Get((cBContracts.SelectedItem as ContractDTO).SellerId).INN.ToString());
            WordWorker.FindReplace("{kppCustomer}", MainForm.DB.Customers.Get((cBContracts.SelectedItem as ContractDTO).CustomerId).KPP.ToString());
            WordWorker.FindReplace("{kppSeller}", MainForm.DB.Sellers.Get((cBContracts.SelectedItem as ContractDTO).SellerId).KPP.ToString());
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

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            if (cBContracts.SelectedItem != null)
            {
                string pathDir = Application.StartupPath + "\\Документы\\" + (cBContracts.SelectedItem as ContractDTO).ToString().Substring(0, (cBContracts.SelectedItem as ContractDTO).ToString().Length - 1);
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
        }

        private void ButAddProduct_Click(object sender, EventArgs e)
        {
            AddProductInInvoice addProductInInvoice = new AddProductInInvoice(this, Application.StartupPath + (cBContracts.SelectedItem as ContractDTO).FileName);
            addProductInInvoice.ShowDialog();
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

        private void ButOpen_Click(object sender, EventArgs e)
        {
            OpenDocument(Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get((lBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString() + "\\" + (lBInvoices.SelectedItem as InvoiceDTO).ToString() + ".docx");
        }
    }


}
