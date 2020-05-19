using BLL.Models;
using BLL.Services.WordService;
using DAL.DTO;
using DAL.Interfaces;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace BLL.Services
{
    public class AccumulativeOnArrivalService
    {
        private WordWorker WordWorker;
        private IUnitOfWork DB;
        private string startupPath;
        private string dataPath;

        public AccumulativeOnArrivalService(IUnitOfWork DB, string startupPath, string dataPath)
        {
            this.DB = DB;
            this.startupPath = startupPath;
            this.dataPath = dataPath;
            WordWorker = new WordWorker(startupPath + "\\Document Templates\\Накопительная по приходу.docx");
        }

        public void BuildDocument(List<ContractDTO> contracts, List<DeliveryNoteDTO> deliveryNotes, CustomerDTO customer, string month, string year)
        {
            WordWorker.Load();
            ReplaceStrings(month, year, customer);
            Range range = WordWorker.doc.Paragraphs[WordWorker.doc.Paragraphs.Count].Range;
            int contractIndex = 3;
            int naklIndex = 1;
            float TotalAll = 0;
            float TotalContract = 0;
            List<ProductArrival> allProducts = new List<ProductArrival>();
            foreach (ContractDTO contract in contracts)
            {
                TotalContract = 0;
                WordWorker.doc.Tables[1].Cell(contractIndex, 2).Range.Text = DB.Sellers.Get(contract.SellerId).NameCompany;

                foreach (DeliveryNoteDTO nakl in deliveryNotes.Where(x => DB.Invoices.Get(x.InvoiceId).ContractId == contract.Id))
                {
                    Stream stream = new FileStream(startupPath + "\\Local Data\\" + contract.ToString() + "\\" + nakl.ToString() + ".nakl", FileMode.Open);
                    List<ProductArrival> productList = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
                    stream.Close();
                    float Total = 0;
                    foreach (var item in productList)
                    {
                        Total += item.GetSum();
                        if (allProducts.Where(x => x.Id == item.Id).Count() == 0)
                        {
                            allProducts.Add(item);
                            WordWorker.doc.Tables[2].Rows.Add();
                            WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), 1).Range.Text = item.Name;
                            WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), 2).Range.Text = DB.Units.Get(item.UnitId).Name;
                            WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), naklIndex * 2 + 1).Range.Text = Math.Round(item.Balance, 2).ToString();
                            WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), naklIndex * 2 + 2).Range.Text = item.GetSumRound().ToString();
                        }
                        else
                        {
                            WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), naklIndex * 2 + 1).Range.Text = Math.Round(item.Balance, 2).ToString();
                            WordWorker.doc.Tables[2].Cell((allProducts.FindIndex(x => x.Id == item.Id) + 2), naklIndex * 2 + 2).Range.Text = item.GetSumRound().ToString();
                        }

                    }
                    TotalContract += Total;
                    WordWorker.doc.Tables[1].Cell(1, naklIndex + 2).Range.Text = "От " + (nakl as DeliveryNoteDTO).Date.ToLongDateString();
                    WordWorker.doc.Tables[1].Cell(2, naklIndex + 2).Range.Text = "Накл. №" + (nakl as DeliveryNoteDTO).Number.ToString();
                    WordWorker.doc.Tables[1].Cell(contractIndex, naklIndex + 2).Range.Text = Math.Round(Total, 2).ToString();

                    naklIndex++;
                }
                WordWorker.doc.Tables[1].Cell(contractIndex, 12).Range.Text = Math.Round(TotalContract, 2).ToString();
                WordWorker.doc.Tables[1].Cell(contractIndex, 2).Range.Text = DB.Sellers.Get(contract.SellerId).NameCompany;
                TotalAll += TotalContract;
                contractIndex++;
            }
            WordWorker.doc.Tables[1].Cell(13, 12).Range.Text = Math.Round(TotalAll, 2).ToString();

            WordWorker.Save(dataPath + "\\Документы\\Накопительные по приходу\\Накопительная по приходу за " + month + " " + year + ".docx");
            WordWorker.app.Visible = true;
            WordWorker.doc = null;
            WordWorker.Close();
        }

        private void ReplaceStrings(string month, string year, CustomerDTO customer)
        {
            WordWorker.FindReplace("{mount}", month);
            WordWorker.FindReplace("{year}", year);
            WordWorker.FindReplace("{nameCompanyCustomer}", customer.NameCompany);
            WordWorker.FindReplace("{nameCustomer}", customer.NameCustomer);
        }
    }
}
