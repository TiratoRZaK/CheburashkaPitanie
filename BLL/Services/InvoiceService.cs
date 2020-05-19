using BLL.Models;
using BLL.Services.WordService;
using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BLL.Services
{
    public class InvoiceService : IDocumentService<InvoiceDTO>
    {
        private InvoiceDTO invoiceInDb;
        private WordWorker worker;
        private IUnitOfWork DB;
        private string startupPath;
        private string dataPath;

        public InvoiceService(IUnitOfWork DB, string startupPath, string dataPath)
        {
            this.DB = DB;
            this.startupPath = startupPath;
            this.dataPath = dataPath;
            worker = new WordWorker(startupPath + "\\Document Templates\\Счёт-фактура.docx");
        }

        public void BuildDocument(InvoiceDTO invoice)
        {
            invoiceInDb = invoice;
            Stream stream = new FileStream(startupPath + "\\Local Data\\" + invoiceInDb.FileName, FileMode.Open);
            List<ProductArrival> productsInInvoice = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
            worker.Load();
            ReplaceStrings();
            int i = 1;
            double summ = 0.0d;
            foreach (ProductArrival product in productsInInvoice)
            {
                summ += product.GetSumRound();
                worker.doc.Tables[1].Rows.Add();
                i++;
                worker.doc.Tables[1].Rows[i].Height = (float)12;
                worker.doc.Tables[1].Cell(i, 1).Range.Text = product.Name;
                worker.doc.Tables[1].Cell(i, 2).Range.Text = DB.Units.Get(product.UnitId).Name;
                worker.doc.Tables[1].Cell(i, 3).Range.Text = Math.Round(product.Balance, 2).ToString();
                worker.doc.Tables[1].Cell(i, 4).Range.Text = Math.Round(product.Price, 2).ToString();
                worker.doc.Tables[1].Cell(i, 5).Range.Text = Math.Round(product.GetSum(), 2).ToString();
                worker.doc.Tables[1].Cell(i, 9).Range.Text = Math.Round(product.GetSum(), 2).ToString();
            }
            worker.doc.Tables[1].Rows.Add();
            i++;
            worker.doc.Tables[1].Rows[i].Range.Bold = 1;
            worker.doc.Tables[1].Cell(i, 1).Range.Text = "Итого";
            worker.doc.Tables[1].Cell(i, 5).Range.Text = Math.Round(summ, 2).ToString();
            worker.doc.Tables[1].Cell(i, 9).Range.Text = Math.Round(summ, 2).ToString();
            string replacedOfWord = worker.ReplaceOfWord(Math.Round(summ, 2));
            if (summ.ToString().Contains(","))
            {
                if (summ.ToString().Substring(summ.ToString().IndexOf(',')).Length - 1 == 2)
                {
                    worker.FindReplace("{total}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    worker.FindReplace("{kopeiki}", summ.ToString().Substring(summ.ToString().IndexOf(',') + 1));
                }
                else
                {
                    worker.FindReplace("{total}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                    worker.FindReplace("{kopeiki}", summ.ToString().Substring(summ.ToString().IndexOf(',') + 1) + "0");
                }
            }
            else
            {
                worker.FindReplace("{total}", replacedOfWord.Remove(replacedOfWord.Length - 1));
                worker.FindReplace("{kopeiki}", "00");
            }

            worker.Save(dataPath + "\\Документы\\" + invoiceInDb.Contract.ToString() + "\\" + invoiceInDb.ToString() + ".docx");
            worker.Close();
        }

        public void Delete(InvoiceDTO invoice)
        {

            Stream stream = new FileStream(startupPath + "\\Local Data\\" + invoice.FileName, FileMode.Open);
            List<ProductArrival> productsInInvoice = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
            stream.Close();

            foreach (DeliveryNoteDTO deliveryNote in DB.DeliveryNotes.GetAll())
            {
                if (deliveryNote.InvoiceId == invoice.Id)
                {
                    IDocumentService<DeliveryNoteDTO> service = new DeliveryNotesService(DB, startupPath, dataPath);
                    service.Delete(deliveryNote);
                }
            }

            string path = startupPath + "\\Local Data\\" + invoice.FileName;
            File.Delete(path);

            foreach (ProductArrival product in productsInInvoice)
            {
                ProductDTO productInDb = DB.Products.Get(product.Id);
                productInDb.Sum = (float)Math.Round(productInDb.Sum - product.GetSumRound(), 2);
                productInDb.Balance = (float)(productInDb.Balance - product.Balance);
            }

            ContractDTO contract = DB.Contracts.Get(invoice.ContractId);
            stream = new FileStream(startupPath + "\\Local Data\\" + contract.FileName, FileMode.Open);
            List<ProductArrival> productsInContract = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
            stream.Close();

            foreach (ProductArrival productInInv in productsInInvoice)
            {
                for (int i = 0; i < productsInContract.Count; i++)
                {
                    if (productsInContract[i].Id == productInInv.Id)
                    {
                        productsInContract[i].Balance = (float)(productsInContract[i].Balance + productInInv.Balance);
                    }
                }
            }

            stream = new FileStream(startupPath + "\\Local Data\\" + contract.ToString() + "\\contract.cont", FileMode.Create);
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, productsInContract);
            stream.Close();

            DB.Invoices.Delete(invoice.Id);
            DB.Save();
        }

        public void ReplaceStrings()
        {
            ContractDTO contract = DB.Contracts.Get(invoiceInDb.ContractId);
            worker.FindReplace("{date}", invoiceInDb.Date.ToShortDateString());
            worker.FindReplace("{contractDate}", contract.ConclusionDate.ToLongDateString());
            worker.FindReplace("{contractNumber}", contract.Number.ToString());
            worker.FindReplace("{number}", invoiceInDb.Number.ToString());
            worker.FindReplace("{NameCompanySeller}", DB.Sellers.Get(contract.SellerId).NameCompany);
            worker.FindReplace("{nameCompanyCustomer}", DB.Customers.Get(contract.CustomerId).NameCompany);
            worker.FindReplace("{nameSeller}", DB.Sellers.Get(contract.SellerId).NameSeller);
            worker.FindReplace("{addressCustomer}", DB.Customers.Get(contract.CustomerId).AddressCompany);
            worker.FindReplace("{addressSeller}", DB.Sellers.Get(contract.SellerId).AddressCompany);
            worker.FindReplace("{innCustomer}", DB.Customers.Get(contract.CustomerId).INN.ToString());
            worker.FindReplace("{innSeller}", DB.Sellers.Get(contract.SellerId).INN.ToString());
            worker.FindReplace("{kppCustomer}", DB.Customers.Get(contract.CustomerId).KPP.ToString());
            worker.FindReplace("{kppSeller}", DB.Sellers.Get(contract.SellerId).KPP.ToString());
        }

        public bool Open(string fileName)
        {
            return worker.Open(fileName);
        }
    }
}
