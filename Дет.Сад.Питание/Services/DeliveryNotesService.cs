using DAL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;
using Дет.Сад.Питание.Services.WordService;

namespace Дет.Сад.Питание.Services
{
    public class DeliveryNotesService : IDocumentService
    {
        WordWorker worker = new WordWorker(Application.StartupPath + "\\Document Templates\\Накладная.docx");
        DeliveryNoteDTO deliveryNoteInDb;

        public void BuildDocument(int id)
        {
            deliveryNoteInDb = MainForm.DB.DeliveryNotes.Get(id);
            worker.Load();

            Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + deliveryNoteInDb.FileName, FileMode.Open);
            List<ProductArrival> productsInNote = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;

            ReplaceStrings();
            Microsoft.Office.Interop.Word.Range range = worker.doc.Paragraphs[worker.doc.Paragraphs.Count].Range;
            int i = 3;
            double summ = 0.0d;
            foreach (ProductArrival product in productsInNote)
            {
                summ += product.getSumRound();
                worker.doc.Tables[2].Rows.Add();
                i++;
                worker.doc.Tables[2].Cell(i, 1).Range.Text = (i - 3).ToString();
                worker.doc.Tables[2].Cell(i, 2).Range.Text = product.Name;
                worker.doc.Tables[2].Cell(i, 4).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                worker.doc.Tables[2].Cell(i, 10).Range.Text = Math.Round(product.Balance, 2).ToString();
                worker.doc.Tables[2].Cell(i, 11).Range.Text = Math.Round(product.Price, 2).ToString();
                worker.doc.Tables[2].Cell(i, 12).Range.Text = product.getSumRound().ToString();
                worker.doc.Tables[2].Cell(i, 13).Range.Text = "БЕЗ НДС";
                worker.doc.Tables[2].Cell(i, 15).Range.Text = product.getSumRound().ToString();
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

            worker.Save(MainForm.DataPath + "\\Документы\\" + MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get(deliveryNoteInDb.InvoiceId).ContractId).ToString() + "\\" + deliveryNoteInDb.ToString() + ".docx");
            
            worker.Close();
        }

        public void Delete(int id)
        {
            DeliveryNoteDTO deliveryNote = MainForm.DB.DeliveryNotes.Get(id);
            if (MessageBox.Show("Вы уверены что хотите удалить накладную №" + deliveryNote.Number.ToString() + "?", "Удаление накладной", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InvoiceDTO invoice = MainForm.DB.Invoices.Get(deliveryNote.InvoiceId);
                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + invoice.FileName, FileMode.Open);
                List<ProductArrival> productsInInvoice = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
                stream.Close();

                stream = new FileStream(Application.StartupPath + "\\Local Data\\" + deliveryNote.FileName, FileMode.Open);
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
                string path = Application.StartupPath + "\\Local Data\\" + deliveryNote.FileName;
                File.Delete(path);

                stream = new FileStream(Application.StartupPath + "\\Local Data\\" + invoice.FileName, FileMode.Create);
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, productsInInvoice);
                stream.Close();

                MainForm.DB.DeliveryNotes.Delete(deliveryNote.Id);
                MainForm.DB.Save();
            }
        }

        public void ReplaceStrings()
        {
            ContractDTO contract = MainForm.DB.Contracts.Get(MainForm.DB.Invoices.Get(deliveryNoteInDb.InvoiceId).ContractId);
            InvoiceDTO invoice = MainForm.DB.Invoices.Get(deliveryNoteInDb.InvoiceId);
            SellerDTO seller = MainForm.DB.Sellers.Get(contract.SellerId);
            CustomerDTO customer = MainForm.DB.Customers.Get(contract.CustomerId);
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

        public void Open(string fileName)
        {
            worker.Open(fileName);
        }
    }
}
