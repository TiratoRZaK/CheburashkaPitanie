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
    public partial class DeliveryNotesForm : Form
    {
        IDocumentService<DeliveryNoteDTO> service = new DeliveryNotesService(MainForm.DB, Application.StartupPath, MainForm.DataPath);

        public DeliveryNoteDTO deliveryNote = null;
        public List<ProductArrival> addedProducts;
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

        private void ButAddDeliveryNote_Click(object sender, EventArgs e)
        {
            if (pData.Enabled == false)
            {
                pDeliveryNotes.Enabled = false;
                pData.Enabled = true;
                butAddDeliveryNote.BackColor = Color.Blue;
                butAddDeliveryNote.Text = "Отменить добавление";
                lBDeliveryNotes.Enabled = false;
                lDeliveryNote.Text = "Новая накладная";
                lDeliveryNote.Enabled = false;
                butSave.Enabled = true;
                deliveryNote = new DeliveryNoteDTO();
                addedProducts = new List<ProductArrival>();
                ReloadedData();
            }
            else
            {
                pDeliveryNotes.Enabled = true;
                pData.Enabled = false;
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
                pCheckDoc.Visible = true;
                if (File.Exists(MainForm.DataPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString() + "\\" + (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".docx"))
                {
                    lCheckDoc.Text = "Документ сформирован";
                }
                else
                {
                    lCheckDoc.Text = "Документ отсутствует";
                }
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
                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString() + "\\" + (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".nakl", FileMode.Open);
                addedProducts = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
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
                    Total += item.GetSumRound();
                    AddProduct(item);
                }
                deliveryNote = new DeliveryNoteDTO
                {
                    Number = int.Parse(tBNumber.Text),
                    Date = dTPData.Value,
                    InvoiceId = (cBInvoices.SelectedItem as InvoiceDTO).Id,
                    PriemName = tBPriemName.Text,
                    GruzName = tBGruzName.Text,
                    FileName = MainForm.DB.Contracts.Get((cBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString() + "\\Накладная №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".nakl"
                };
                MainForm.DB.DeliveryNotes.Create(deliveryNote);
                MainForm.DB.Save();
                string path = Application.StartupPath + "\\Local Data\\";
                string subpath = MainForm.DB.Contracts.Get((cBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString() + "\\";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                if (Directory.Exists(path))
                {
                    dirInfo.CreateSubdirectory(subpath);
                    Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + MainForm.DB.Contracts.Get((cBInvoices.SelectedItem as InvoiceDTO).ContractId).ToString() + "\\Накладная №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + ".nakl", FileMode.CreateNew);
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

        private void AddProduct(ProductArrival product)
        {
            Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + (cBInvoices.SelectedItem as InvoiceDTO).FileName, FileMode.Open);
            List<ProductArrival> listInvoiceProducts = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
            ProductArrival productInInvoice = listInvoiceProducts.Single(x => x.Id == product.Id);
            productInInvoice.Balance -= product.Balance;
            listInvoiceProducts.Remove(listInvoiceProducts.Single(x => x.Id == product.Id));
            listInvoiceProducts.Add(productInInvoice);
            stream.Close();

            stream = new FileStream(Application.StartupPath + "\\Local Data\\" + (cBInvoices.SelectedItem as InvoiceDTO).FileName, FileMode.OpenOrCreate);
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
            if (lBDeliveryNotes.SelectedItem != null)
            {
                DeliveryNoteDTO deliveryNote = lBDeliveryNotes.SelectedItem as DeliveryNoteDTO;
                if (MessageBox.Show("Вы уверены что хотите удалить накладную №" + deliveryNote.Number.ToString() + "?", "Удаление накладной", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    service.Delete(deliveryNote);
                }
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
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                service.BuildDocument(lBDeliveryNotes.SelectedItem as DeliveryNoteDTO);
                lLoad.Visible = false;
            }
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

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            if (lBDeliveryNotes.SelectedItem != null)
            {
                string pathDir = MainForm.DataPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Substring(0, MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Length - 1);
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
        }

        private void ButAddProduct_Click(object sender, EventArgs e)
        {
            AddProductInDeliveryNote addProductInDeliveryNote = new AddProductInDeliveryNote(this, Application.StartupPath + "\\Local Data\\" + MainForm.DB.Invoices.Get((cBInvoices.SelectedItem as InvoiceDTO).Id).FileName);
            addProductInDeliveryNote.ShowDialog();
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            if (lBDeliveryNotes.SelectedItem != null)
                OpenDocument(MainForm.DataPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Substring(0, MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString().Length - 1) + "\\" + (lBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".docx");
        }
    }
}
