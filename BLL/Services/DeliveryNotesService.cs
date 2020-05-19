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
    public class DeliveryNotesService : IDocumentService<DeliveryNoteDTO>
    {
        DeliveryNoteDTO deliveryNoteInDb;
        WordWorker worker;
        IUnitOfWork DB;
        String startupPath;
        String dataPath;

        public DeliveryNotesService(IUnitOfWork DB, string startupPath, string dataPath)
        {
            this.DB = DB;
            this.startupPath = startupPath;
            this.dataPath = dataPath;
            worker = new WordWorker(startupPath + "\\Document Templates\\Накладная.docx");
        }

        public void BuildDocument(DeliveryNoteDTO deliveryNote)
        {
            deliveryNoteInDb = deliveryNote;
            worker.Load();

            Stream stream = new FileStream(startupPath + "\\Local Data\\" + deliveryNoteInDb.FileName, FileMode.Open);
            List<ProductArrival> productsInNote = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;

            ReplaceStrings();
            Microsoft.Office.Interop.Word.Range range = worker.doc.Paragraphs[worker.doc.Paragraphs.Count].Range;
            int i = 3;
            double summ = 0.0d;
            foreach (ProductArrival product in productsInNote)
            {
                summ += product.GetSumRound();
                worker.doc.Tables[2].Rows.Add();
                i++;
                worker.doc.Tables[2].Cell(i, 1).Range.Text = (i - 3).ToString();
                worker.doc.Tables[2].Cell(i, 2).Range.Text = product.Name;
                worker.doc.Tables[2].Cell(i, 4).Range.Text = DB.Units.Get(product.UnitId).Name;
                worker.doc.Tables[2].Cell(i, 10).Range.Text = Math.Round(product.Balance, 2).ToString();
                worker.doc.Tables[2].Cell(i, 11).Range.Text = Math.Round(product.Price, 2).ToString();
                worker.doc.Tables[2].Cell(i, 12).Range.Text = product.GetSumRound().ToString();
                worker.doc.Tables[2].Cell(i, 13).Range.Text = "БЕЗ НДС";
                worker.doc.Tables[2].Cell(i, 15).Range.Text = product.GetSumRound().ToString();
            }
            worker.doc.Tables[2].Rows.Add();
            i++;
            worker.doc.Tables[2].Cell(i, 1).Range.Text = "Итого";
            worker.doc.Tables[2].Cell(i, 11).Range.Text = "X";
            worker.doc.Tables[2].Cell(i, 12).Range.Text = Math.Round(summ).ToString();
            worker.doc.Tables[2].Cell(i, 13).Range.Text = "X";
            worker.doc.Tables[2].Cell(i, 15).Range.Text = Math.Round(summ).ToString();
            string replacedOfWord = worker.ReplaceOfWord(float.Parse(summ.ToString()));
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

            worker.Save(dataPath + "\\Документы\\" + DB.Contracts.Get(DB.Invoices.Get(deliveryNoteInDb.InvoiceId).ContractId).ToString() + "\\" + deliveryNoteInDb.ToString() + ".docx");

            worker.Close();
        }

        public void Delete(DeliveryNoteDTO deliveryNote)
        {
            InvoiceDTO invoice = DB.Invoices.Get(deliveryNote.InvoiceId);
            Stream stream = new FileStream(startupPath + "\\Local Data\\" + invoice.FileName, FileMode.Open);
            List<ProductArrival> productsInInvoice = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
            stream.Close();

            stream = new FileStream(startupPath + "\\Local Data\\" + deliveryNote.FileName, FileMode.Open);
            List<ProductArrival> productsInDeliveryNote = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
            stream.Close();

            foreach (ProductArrival productInDeliveryNote in productsInDeliveryNote)
            {
                for (int i = 0; i < productsInInvoice.Count; i++)
                {
                    if (productsInInvoice[i].Id == productInDeliveryNote.Id)
                    {
                        productsInInvoice[i].Balance = (float)(productsInInvoice[i].Balance + productInDeliveryNote.Balance);
                    }
                }
            }
            string path = startupPath + "\\Local Data\\" + deliveryNote.FileName;
            File.Delete(path);

            stream = new FileStream(startupPath + "\\Local Data\\" + invoice.FileName, FileMode.Create);
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, productsInInvoice);
            stream.Close();

            DB.DeliveryNotes.Delete(deliveryNote.Id);
            DB.Save();
        }

        public void ReplaceStrings()
        {
            ContractDTO contract = DB.Contracts.Get(DB.Invoices.Get(deliveryNoteInDb.InvoiceId).ContractId);
            InvoiceDTO invoice = DB.Invoices.Get(deliveryNoteInDb.InvoiceId);
            SellerDTO seller = DB.Sellers.Get(contract.SellerId);
            CustomerDTO customer = DB.Customers.Get(contract.CustomerId);
            worker.FindReplace("{dateNakl}", deliveryNoteInDb.Date.ToShortDateString());
            worker.FindReplace("{contractName}", contract.ToString());
            worker.FindReplace("{invoiceName}", invoice.ToString());
            worker.FindReplace("{numberNakl}", deliveryNoteInDb.Number.ToString());
            worker.FindReplace("{nameCompanySeller}", seller.NameCompany);
            worker.FindReplace("{nameCompanyCustomer}", customer.NameCompany);
            worker.FindReplace("{fullNameCompanySeller}", seller.FullNameCompany);
            worker.FindReplace("{fullNameCompanyCustomer}", customer.FullNameCompany);
            worker.FindReplace("{nameSeller}", seller.NameSeller);
            worker.FindReplace("{addressCustomer}", customer.AddressCompany);
            worker.FindReplace("{addressSeller}", seller.AddressCompany);
            worker.FindReplace("{innCustomer}", customer.INN.ToString());
            worker.FindReplace("{innSeller}", seller.INN.ToString());
            worker.FindReplace("{kppCustomer}", customer.KPP.ToString());
            worker.FindReplace("{kppSeller}", seller.KPP.ToString());
            worker.FindReplace("{personalAccountCustomer}", customer.PersonalAccount);
            worker.FindReplace("{corespAccountSeller}", seller.CorrespondentAccount);
            worker.FindReplace("{bikCustomer}", customer.BIK.ToString());
            worker.FindReplace("{bikSeller}", seller.BIK.ToString());
            worker.FindReplace("{bikCustomer}", customer.BIK.ToString());
            worker.FindReplace("{bankCustomer}", customer.Bank);
            worker.FindReplace("{bankSeller}", seller.Bank);
            worker.FindReplace("{bankAccountCustomer}", customer.BankAccount);
            worker.FindReplace("{bankAccountSeller}", seller.BankAccount);
            worker.FindReplace("{priemName}", deliveryNoteInDb.PriemName);
            worker.FindReplace("{gruzName}", deliveryNoteInDb.GruzName);
        }

        public bool Open(string fileName)
        {
            return worker.Open(fileName);
        }
    }
}
