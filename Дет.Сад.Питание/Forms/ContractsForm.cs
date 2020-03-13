using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;
using Дет.Сад.Питание.Services;
using Дет.Сад.Питание.Services.WordService;

namespace Дет.Сад.Питание.Forms
{
    public partial class ContractsForm : Form
    {
        IDocumentService service = new ContractsService();

        public ContractDTO contract = null;
        public List<ProductArrival> addedProducts;
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
            dTPData.Value = DateTime.Now;
            dTPOkonch.Value = DateTime.Now.AddMonths(3);
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
                    Math.Round(item.getSum(),2).ToString(),
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

        private void ButAddContract_Click(object sender, EventArgs e)
        {
            if (pData.Enabled == false)
            {
                pContracts.Enabled = false;
                pData.Enabled = true;
                butAddContract.BackColor = Color.Blue;
                butAddContract.Text = "Отменить добавление";
                lBContracts.Enabled = false;
                lContract.Text = "Новый договор";
                lContract.Enabled = false;
                butSave.Enabled = true;
                contract = new ContractDTO();
                addedProducts = new List<ProductArrival>();
                ReloadedData();
            }
            else
            {
                pContracts.Enabled = true;
                pData.Enabled = false;
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
            if (lBContracts.SelectedItem != null)
            {
                pCheckDoc.Visible = true;
                if (File.Exists(MainForm.DataPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString() + "\\" + (lBContracts.SelectedItem as ContractDTO).ToString() + ".docx"))
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
                cBTypeProducts.Text = (lBContracts.SelectedItem as ContractDTO).TypeSpec;
                lContract.Text = lBContracts.Text;
                tBNumber.Text = (lBContracts.SelectedItem as ContractDTO).Number.ToString();
                tBOtv.Text = (lBContracts.SelectedItem as ContractDTO).ResponsiblePerson;
                dTPData.Value = (lBContracts.SelectedItem as ContractDTO).ConclusionDate;
                dTPOkonch.Value = (lBContracts.SelectedItem as ContractDTO).EndDate;
                cBCustomer.SelectedItem = (lBContracts.SelectedItem as ContractDTO).Customer;
                cBSeller.SelectedItem = (lBContracts.SelectedItem as ContractDTO).Seller;
                dGVProducts.Rows.Clear();
                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + (lBContracts.SelectedItem as ContractDTO).FileName, FileMode.Open);
                addedProducts = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
                stream.Close();
                ReloadedData();
                if (lSumm.Text == "0")
                {
                    MessageBox.Show("Данный договор закрыт!");
                }
            }

        }

        private void ButSaveAndOpen_Click(object sender, EventArgs e)
        {
            if (tBNumber.Text.Length != 0 && tBOtv.Text.Length != 0 && dGVProducts.Rows.Count != 0)
            {
                if (MainForm.DB.Contracts.GetAll().Where(x => x.Number == int.Parse(tBNumber.Text) && x.ConclusionDate.ToLongDateString() == dTPData.Value.ToLongDateString()).Count() == 0)
                {
                    float Total = 0;
                    foreach (var item in addedProducts)
                    {
                        Total += item.getSumRound();
                    }
                    contract = new ContractDTO
                    {
                        Number = int.Parse(tBNumber.Text),
                        PeriodInMonths = dTPOkonch.Value.Month - dTPData.Value.Month,
                        ConclusionDate = dTPData.Value,
                        EndDate = dTPOkonch.Value,
                        CustomerId = (cBCustomer.SelectedItem as CustomerDTO).Id,
                        SellerId = (cBSeller.SelectedItem as SellerDTO).Id,
                        TypeSpec = cBTypeProducts.Text,
                        ResponsiblePerson = tBOtv.Text,
                        FileName = "Контракт №" + tBNumber.Text + " от " + dTPData.Value.ToLongDateString() + "\\contract.cont",
                        Total = (float)Math.Round(Total, 2)
                    };
                    MainForm.DB.Contracts.Create(contract);
                    MainForm.DB.Save();
                    string path = Application.StartupPath + "\\Local Data\\";
                    string subpath = contract.ToString();
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (!dirInfo.Exists)
                    {
                        dirInfo.Create();
                    }
                    if (!Directory.Exists(path + contract.ToString()))
                    {
                        dirInfo.CreateSubdirectory(subpath);
                        Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + contract.ToString() + "\\contract.cont", FileMode.Create);
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
            if (dGVProducts.Rows.Count != 0)
            {
                float Total = 0;
                foreach (var item in addedProducts)
                {
                    Total += item.getSumRound();
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
                    Total += item.getSumRound();
                }
                lSumm.Text = Math.Round(Total, 2).ToString();
            }
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            if (lBContracts.SelectedItem != null)
            {
                service.Delete((lBContracts.SelectedItem as ContractDTO).Id);

                ReloadedContracts();
            }
        }

        private void ButBuild_Click(object sender, EventArgs e)
        {
            if (lBContracts.SelectedItem != null)
            {
                BuildContract();
            }
        }

        void BuildContract()
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                service.BuildDocument((lBContracts.SelectedItem as ContractDTO).Id);
                lLoad.Visible = false;
            }
        }

        public void OpenDocument(string path)
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                service.Open(path);
            }
            lLoad.Visible = false;
        }



        private void ButDirectory_Click(object sender, EventArgs e)
        {
            if (lBContracts.SelectedItem != null)
            {
                string pathDir = MainForm.DataPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString().Substring(0, (lBContracts.SelectedItem as ContractDTO).ToString().Length - 1);
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
            else
            {
                string pathDir = MainForm.DataPath + "\\Документы\\";
                Process Proc = new Process();
                Proc.StartInfo.FileName = "explorer";
                Proc.StartInfo.Arguments = pathDir;
                Proc.Start();
            }
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                service.Open(MainForm.DataPath + "\\Документы\\" + (lBContracts.SelectedItem as ContractDTO).ToString().Substring(0, (lBContracts.SelectedItem as ContractDTO).ToString().Length - 1) + "\\" + (lBContracts.SelectedItem as ContractDTO).ToString() + ".docx");
                lLoad.Visible = false;
            }
        }

        private void dGVProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && addedProducts != null)
            {
                string temp = "";
                if (dGVProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("."))
                {
                    temp = dGVProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    temp = temp.Replace(".", ",");
                }
                else
                {
                    temp = dGVProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                ProductDTO prod = MainForm.DB.Products.Get((dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id);
                float newBalance = float.Parse(temp);
                addedProducts.Single(x => x.Id == (dGVProducts.Rows[e.RowIndex].Tag as ProductArrival).Id).Balance = newBalance;

                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + (lBContracts.SelectedItem as ContractDTO).ToString() + "\\contract.cont", FileMode.Create);
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, addedProducts);
                stream.Close();

                ReloadedData();
            }
        }
    }
}
