using DAL.DTO;
using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Servises.WordWorker;

namespace Дет.Сад.Питание.Forms
{
    public partial class AccumulativeOnArrival : Form
    {
        public WordWorker WordWorker = new WordWorker(Application.StartupPath + "\\Документы\\Шаблоны\\Накопительная по приходу.docx");
       
        public List<ProductDTO> deliveryNotesProducts;
        public List<ProductDTO> accumulateProducts;
        public List<ContractDTO> contracts;
        public MainForm main;
        public AccumulativeOnArrival(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeListBoxes();
        }

        void InitializeListBoxes()
        {
            foreach(ContractDTO item in MainForm.DB.Contracts.GetAll())
                cLBContracts.Items.Add(item);
            cBMount.DataSource = new string[]
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
            for(int i = DateTime.Now.Year; i<DateTime.Now.Year + 100; i++)
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
                    Math.Round((item.Price * item.Balance),2).ToString()
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
                    Math.Round((item.Price * item.Balance),2).ToString()
                });
            }
        }

        private void CLBDeliveryNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cLBDeliveryNotes.SelectedItems.Count > 0 )
            {
                butBuild.Enabled = true;
                tBNumber.Text = (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).Number.ToString();
                dTPData.Value = (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).Date;
                tBPriemName.Text = (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).PriemName;
                tBGruzName.Text = (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).GruzName;
                tBInvoice.Text = MainForm.DB.Invoices.Get((cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ToString();
                dGVProducts.Rows.Clear();
                Stream stream = new FileStream(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).InvoiceId).ContractId).ToString() + "\\Файлы\\" + (cLBDeliveryNotes.SelectedItem as DeliveryNoteDTO).ToString() + ".nakl", FileMode.Open);
                deliveryNotesProducts = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
                stream.Close();
                ReloadedDataDeliveryNotesProducts();
            }
        }

        private void CLBDeliveryNotes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = (CheckedListBox)sender;
            clb.ItemCheck -= CLBDeliveryNotes_ItemCheck;
            clb.SetItemCheckState(e.Index, e.NewValue);
            clb.ItemCheck += CLBDeliveryNotes_ItemCheck;

            accumulateProducts = new List<ProductDTO>();
            dGVProductsAll.Rows.Clear();
            foreach (object itemChecked in cLBDeliveryNotes.CheckedItems)
            {
                Stream stream = new FileStream(System.Windows.Forms.Application.StartupPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get((itemChecked as DeliveryNoteDTO).InvoiceId).ContractId).ToString() + "\\Файлы\\" + (itemChecked as DeliveryNoteDTO).ToString() + ".nakl", FileMode.Open);
                List<ProductDTO> newAddedProducts = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
                stream.Close();
                foreach(ProductDTO item in newAddedProducts)
                {
                    if(accumulateProducts.Where(x=>x.Id == item.Id).Count() > 0)
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
            try
            {
                DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    lLoad.Visible = true;
                    WordWorker.Load();
                    ReplaceStrings();
                    Word.Range range = WordWorker.doc.Paragraphs[WordWorker.doc.Paragraphs.Count].Range;
                    int contractIndex = 3;
                    int naklIndex = 1;
                    float TotalAll = 0;
                    float TotalContract = 0;
                    List<ProductDTO> allProducts = new List<ProductDTO>();
                    List<DeliveryNoteDTO> deliveryNotes = new List<DeliveryNoteDTO>();
                    foreach (DeliveryNoteDTO deliveryNote in cLBDeliveryNotes.CheckedItems)
                    {
                        deliveryNotes.Add(deliveryNote);
                    }
                    foreach (ContractDTO contract in cLBContracts.CheckedItems)
                    {
                        TotalContract = 0;
                        WordWorker.doc.Tables[1].Cell(contractIndex, 2).Range.Text = MainForm.DB.Sellers.Get(contract.SellerId).NameCompany;

                        foreach (DeliveryNoteDTO nakl in deliveryNotes.Where(x => MainForm.DB.Invoices.Get(x.InvoiceId).ContractId == contract.Id))
                        {
                            Stream stream = new FileStream(Application.StartupPath + "\\Документы\\" + contract.ToString() + "\\Файлы\\" + nakl.ToString() + ".nakl", FileMode.Open);
                            List<ProductDTO> productList = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
                            stream.Close();
                            float Total = 0;
                            foreach (var item in productList)
                            {
                                Total += item.Balance * item.Price;
                                if (allProducts.Where(x => x.Id == item.Id).Count() == 0)
                                {
                                    allProducts.Add(item);
                                    WordWorker.doc.Tables[2].Rows.Add();
                                    WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), 1).Range.Text = item.Name;
                                    WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), 2).Range.Text = MainForm.DB.Units.Get(item.UnitId).Name;
                                    WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), naklIndex * 2 + 1).Range.Text = item.Balance.ToString();
                                    WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), naklIndex * 2 + 2).Range.Text = Math.Round(item.Balance * item.Price, 2).ToString();
                                }
                                else
                                {
                                    WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), naklIndex * 2 + 1).Range.Text = item.Balance.ToString();
                                    WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), naklIndex * 2 + 2).Range.Text = Math.Round(item.Balance * item.Price, 2).ToString();
                                }

                            }
                            TotalContract += Total;
                            WordWorker.doc.Tables[1].Cell(1, naklIndex + 2).Range.Text = "От " + (nakl as DeliveryNoteDTO).Date.ToLongDateString();
                            WordWorker.doc.Tables[1].Cell(2, naklIndex + 2).Range.Text = "Накл. №" + (nakl as DeliveryNoteDTO).Number.ToString();
                            WordWorker.doc.Tables[1].Cell(contractIndex, naklIndex + 2).Range.Text = Math.Round(Total, 2).ToString();

                            naklIndex++;
                        }
                        WordWorker.doc.Tables[1].Cell(contractIndex, 12).Range.Text = Math.Round(TotalContract, 2).ToString();
                        WordWorker.doc.Tables[1].Cell(contractIndex, 2).Range.Text = MainForm.DB.Sellers.Get(contract.SellerId).NameCompany;
                        TotalAll += TotalContract;
                        contractIndex++;
                    }
                    WordWorker.doc.Tables[1].Cell(13, 12).Range.Text = Math.Round(TotalAll, 2).ToString();

                    WordWorker.Save(Application.StartupPath + "\\Документы\\Накопительные по приходу\\Накопительная по приходу за " + cBMount.SelectedItem.ToString() + " " + cBYear.SelectedItem.ToString() + ".docx");
                    WordWorker.app.Visible = true;
                    WordWorker.doc = null;
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
            WordWorker.FindReplace("{mount}", cBMount.SelectedItem.ToString());
            WordWorker.FindReplace("{year}", cBYear.SelectedItem.ToString());
            WordWorker.FindReplace("{nameCompanyCustomer}", (cBCustomer.SelectedItem as CustomerDTO).NameCompany);
            WordWorker.FindReplace("{nameCustomer}", (cBCustomer.SelectedItem as CustomerDTO).NameCustomer);
        }

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            string pathDir = Application.StartupPath + "\\Документы\\Накопительные по приходу\\";
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
            var deliveryNotes = MainForm.DB.DeliveryNotes.GetAll().Where(x => contracts.Where(y=>y.Id == MainForm.DB.Invoices.Get(x.InvoiceId).ContractId).Count() > 0);
            cLBDeliveryNotes.Items.Clear();
            foreach (DeliveryNoteDTO deliveryNote in deliveryNotes)
            {
                cLBDeliveryNotes.Items.Add(deliveryNote);
            }
        }
    }
}
