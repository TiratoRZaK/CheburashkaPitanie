using BLL.Models;
using BLL.Services;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class AccumulativeOnArrival : Form
    {
        private AccumulativeOnArrivalService service = new AccumulativeOnArrivalService(MainForm.DB, Application.StartupPath, MainForm.DataPath);
        private List<ProductArrival> deliveryNotesProducts;
        private List<ProductArrival> accumulateProducts;
        private List<ContractDTO> contracts;
        private MainForm main;

        public AccumulativeOnArrival(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeListBoxes();
        }

        void InitializeListBoxes()
        {
            foreach (ContractDTO item in MainForm.DB.Contracts.GetAll())
                cLBContracts.Items.Add(item);
            cBMonth.DataSource = new string[]
            {
                "январь",
                "ферваль",
                "март",
                "апрель",
                "мая",
                "июнь",
                "июль",
                "август",
                "сентябрь",
                "октябрь",
                "ноябрь",
                "декабрь"
            };
            for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 100; i++)
            {
                cBYear.Items.Add(i);
            }
            cBYear.SelectedIndex = 0;
            cBCustomer.DataSource = MainForm.DB.Customers.GetAll();
        }

        private void AccumulativeOnArrival_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
        }

        public void ReloadedDataDeliveryNotesProducts()
        {
            dGVProducts.Rows.Clear();
            foreach (var item in deliveryNotesProducts)
            {
                dGVProducts.Rows.Add(new object[] {
                    item.Name,
                    item.Price.ToString(),
                    item.Balance.ToString(),
                    item.GetSumRound().ToString()
                });
            }
        }

        public void ReloadedDataAccumulateProducts()
        {
            dGVProductsAll.Rows.Clear();
            foreach (var item in accumulateProducts)
            {
                dGVProductsAll.Rows.Add(new object[] {
                    item.Name,
                    item.Price.ToString(),
                    item.Balance.ToString(),
                    item.GetSumRound().ToString()
                });
            }
        }

        private void CLBDeliveryNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cLBDeliveryNotes.SelectedItems.Count > 0)
            {
                butBuild.Enabled = true;
                pAccumulate.Enabled = true;
                pNakl.Enabled = true;
                tBNumber.Text = (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).Number.ToString();
                dTPData.Value = (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).Date;
                tBPriemName.Text = (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).PriemName;
                tBGruzName.Text = (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).GruzName;
                tBInvoice.Text = MainForm.DB.Invoices.Get((cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ToString();
                dGVProducts.Rows.Clear();
                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString() + "\\" + (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".nakl", FileMode.Open);
                deliveryNotesProducts = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
                stream.Close();
                ReloadedDataDeliveryNotesProducts();
            }
            else
            {
                pAccumulate.Enabled = false;
                pNakl.Enabled = false;
            }
        }

        private void CLBDeliveryNotes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = (CheckedListBox)sender;
            clb.ItemCheck -= CLBDeliveryNotes_ItemCheck;
            clb.SetItemCheckState(e.Index, e.NewValue);
            clb.ItemCheck += CLBDeliveryNotes_ItemCheck;

            accumulateProducts = new List<ProductArrival>();
            dGVProductsAll.Rows.Clear();
            foreach (object itemChecked in cLBDeliveryNotes.CheckedItems)
            {
                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((itemChecked as DeliveryNoteDTO).InvoiceId).ContractId).ToString() + "\\" + (itemChecked as DeliveryNoteDTO).ToString() + ".nakl", FileMode.Open);
                List<ProductArrival> newAddedProducts = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
                stream.Close();
                foreach (ProductArrival item in newAddedProducts)
                {
                    if (accumulateProducts.Where(x => x.Id == item.Id).Count() > 0)
                    {
                        accumulateProducts.Where(x => x.Id == item.Id).First().Balance += item.Balance;
                    }
                    else
                    {
                        accumulateProducts.Add(item);
                    }
                    ReloadedDataAccumulateProducts();
                }
            }
        }

        private void ButBuild_Click(object sender, EventArgs e)
        {
            if (dGVProductsAll.Rows.Count > 0)
            {
                BuildDocument();
            }
        }

        public void BuildDocument()
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                List<ContractDTO> contracts = new List<ContractDTO>();
                foreach (ContractDTO contract in cLBContracts.CheckedItems)
                {
                    contracts.Add(contract);
                }
                List<DeliveryNoteDTO> deliveryNotes = new List<DeliveryNoteDTO>();
                foreach (DeliveryNoteDTO deliveryNote in cLBDeliveryNotes.CheckedItems)
                {
                    deliveryNotes.Add(deliveryNote);
                }
                service.BuildDocument(contracts, deliveryNotes, (cBCustomer.SelectedItem as CustomerDTO), cBMonth.SelectedItem.ToString(), cBYear.SelectedItem.ToString());
                lLoad.Visible = false;
            }
        }

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            string pathDir = MainForm.DataPath + "\\Документы\\Накопительные по приходу\\";
            Process Proc = new Process();
            Proc.StartInfo.FileName = "explorer";
            Proc.StartInfo.Arguments = pathDir;
            Proc.Start();
        }

        private void CLBContracts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = (CheckedListBox)sender;
            clb.ItemCheck -= CLBContracts_ItemCheck;
            clb.SetItemCheckState(e.Index, e.NewValue);
            clb.ItemCheck += CLBContracts_ItemCheck;
            contracts = new List<ContractDTO>();
            foreach (object contract in cLBContracts.CheckedItems)
                contracts.Add(contract as ContractDTO);
            var deliveryNotes = MainForm.DB.DeliveryNotes.GetAll().Where(x => contracts.Where(y => y.Id == MainForm.DB.Invoices.Get(x.InvoiceId).ContractId).Count() > 0);
            cLBDeliveryNotes.Items.Clear();
            foreach (DeliveryNoteDTO deliveryNote in deliveryNotes)
            {
                cLBDeliveryNotes.Items.Add(deliveryNote);
            }
        }

        private void butCheckAllC_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cLBContracts.Items.Count; i++)
            {
                cLBContracts.SetItemChecked(i, true);
            }
        }

        private void butCheckAllD_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cLBDeliveryNotes.Items.Count; i++)
            {
                cLBDeliveryNotes.SetItemChecked(i, true);
            }
        }

        private void butCheckClearC_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cLBContracts.Items.Count; i++)
            {
                cLBContracts.SetItemChecked(i, false);
            }
        }

        private void butCheckClearD_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cLBDeliveryNotes.Items.Count; i++)
            {
                cLBDeliveryNotes.SetItemChecked(i, false);
            }
        }
    }
}
