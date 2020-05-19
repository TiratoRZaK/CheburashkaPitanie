using BLL.Models;
using BLL.Services;
using BLL.Services.WordService;
using DAL.DTO;
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
    public partial class InvoicesForm : Form
    {
        IDocumentService<InvoiceDTO> service = new InvoiceService(MainForm.DB, Application.StartupPath, MainForm.DataPath);

        public InvoiceDTO invoice = null;
        public List<ProductArrival> addedProducts;
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
            dTPData.Value = DateTime.Now;
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
                    item.GetSumRound().ToString(),
                    "Удалить"
                });
                dGVProducts.Rows[dGVProducts.RowCount - 1].Tag = item;
            }
        }

        private void DGVProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                ProductArrival product = (ProductArrival)dGVProducts.CurrentRow.Tag;
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
                butAddInvoice.BackColor = Color.Blue;
                butAddInvoice.Text = "Отменить добавление";
                lBInvoices.Enabled = false;
                lInvoice.Text = "Новая счёт-фактура";
                lInvoice.Enabled = false;
                butSave.Enabled = true;
                invoice = new InvoiceDTO();
                addedProducts = new List<ProductArrival>();
                ReloadedData();
            }
            else
            {
                pInvoices.Enabled = true;
                pData.Enabled = false;
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
                pCheckDoc.Visible = true;
                if (File.Exists(MainForm.DataPath + "\\Документы\\" + (cBContracts.SelectedItem as ContractDTO).ToString() + "\\" + (lBInvoices.SelectedItem as InvoiceDTO).ToString() + ".docx"))
                {
                    lCheckDoc.Text = "Документ сформирован";
                }
                else
                {
                    lCheckDoc.Text = "Документ отсутствует";
                }
                butBuild.Enabled = true;
                butDirectory.Enabled = true;
                butDel.Enabled = true;
                butOpen.Enabled = true;
                lInvoice.Text = lBInvoices.Text;
                tBNumber.Text = (lBInvoices.SelectedItem as InvoiceDTO).Number.ToString();
                dTPData.Value = (lBInvoices.SelectedItem as InvoiceDTO).Date;
                cBContracts.SelectedItem = MainForm.DB.Contracts.Get((lBInvoices.SelectedItem as InvoiceDTO).ContractId);
                dGVProducts.Rows.Clear();
                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + (cBContracts.SelectedItem as ContractDTO).ToString() + "\\" + (lBInvoices.SelectedItem as InvoiceDTO).ToString() + ".invo", FileMode.Open);
                addedProducts = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
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
                    Total += item.GetSumRound();
                    AddProduct(item);
                }
                invoice = new InvoiceDTO
                {
                    Number = int.Parse(tBNumber.Text),
                    Date = dTPData.Value,
                    ContractId = (cBContracts.SelectedItem as ContractDTO).Id,
                    FileName = (cBContracts.SelectedItem as ContractDTO).ToString() + "\\Счёт-фактура №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".invo",
                    Total = (float)Math.Round(Total, 2)
                };
                MainForm.DB.Invoices.Create(invoice);
                MainForm.DB.Save();
                string path = MainForm.DataPath + "\\Документы\\";
                string subpath = (cBContracts.SelectedItem as ContractDTO).ToString() + "\\";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                if (Directory.Exists(path))
                {
                    dirInfo.CreateSubdirectory(subpath);
                    Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + (cBContracts.SelectedItem as ContractDTO).ToString() + "\\Счёт-фактура №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".invo", FileMode.CreateNew);
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

        private void AddProduct(ProductArrival product)
        {
            ProductDTO dbProduct = MainForm.DB.Products.Get(product.Id);
            float newBalance = (float)(dbProduct.Balance + product.Balance);
            dbProduct.Sum = (float)Math.Round(product.GetSumRound() + dbProduct.Sum, 2);
            dbProduct.Balance = newBalance;
            MainForm.DB.Products.Update(dbProduct);
            MainForm.DB.Save();
            Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + (cBContracts.SelectedItem as ContractDTO).FileName, FileMode.Open);
            List<ProductArrival> listContractProducts = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
            ProductArrival productInContract = listContractProducts.Single(x => x.Id == product.Id);
            productInContract.Balance = (float)(productInContract.Balance - product.Balance);
            listContractProducts.Remove(listContractProducts.Single(x => x.Id == product.Id));
            listContractProducts.Add(productInContract);
            stream.Close();

            stream = new FileStream(Application.StartupPath + "\\Local Data\\" + (cBContracts.SelectedItem as ContractDTO).FileName, FileMode.OpenOrCreate);
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
                    Total += item.GetSumRound();
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
                    Total += item.GetSumRound();
                }
                lSumm.Text = Math.Round(Total, 2).ToString();
            }
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            if (lBInvoices.SelectedItem != null)
            {
                InvoiceDTO invoice = lBInvoices.SelectedItem as InvoiceDTO;
                if (MessageBox.Show("Вы уверены что хотите удалить счёт-фактуру №" + invoice.Number.ToString() + " со всеми её накладными? Все продукты пришедшие по накладной будут изъяты со склада!", "Удаление счёт-фактуры", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    service.Delete(invoice);
                }
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
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                service.BuildDocument(lBInvoices.SelectedItem as InvoiceDTO);
                lLoad.Visible = false;
            }
        }

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            if (cBContracts.SelectedItem != null)
            {
                string pathDir = MainForm.DataPath + "\\Документы\\" + (cBContracts.SelectedItem as ContractDTO).ToString().Substring(0, (cBContracts.SelectedItem as ContractDTO).ToString().Length - 1);
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
        }

        private void ButAddProduct_Click(object sender, EventArgs e)
        {
            AddProductInInvoice addProductInInvoice = new AddProductInInvoice(this, Application.StartupPath + "\\Local Data\\" + (cBContracts.SelectedItem as ContractDTO).FileName);
            addProductInInvoice.ShowDialog();
        }

        public void OpenDocument(string fileName)
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                if (!service.Open(fileName))
                {
                    MessageBox.Show("Документ ещё не сформирован!");
                }
            }
            lLoad.Visible = false;
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            OpenDocument(MainForm.DataPath + "\\Документы\\" + MainForm.DB.Contracts.Get((lBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString() + "\\" + (lBInvoices.SelectedItem as InvoiceDTO).ToString() + ".docx");
        }
    }


}
