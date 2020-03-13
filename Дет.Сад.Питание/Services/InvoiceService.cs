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
    public class InvoiceService : IDocumentService
    {
        WordWorker worker = new WordWorker(Application.StartupPath + "\\Document Templates\\Счёт-фактура.docx");
        InvoiceDTO invoiceInDb;

        public void BuildDocument(int id)
        {
            invoiceInDb = MainForm.DB.Invoices.Get(id);
            Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + invoiceInDb.FileName, FileMode.Open);
            List<ProductArrival> productsInInvoice = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
            worker.Load();
            ReplaceStrings();
            int i = 1;
            double summ = 0.0d;
            foreach (ProductArrival product in productsInInvoice)
            {
                summ += product.getSumRound();
                worker.doc.Tables[1].Rows.Add();
                i++;
                worker.doc.Tables[1].Rows[i].Height = (float)12;
                worker.doc.Tables[1].Cell(i, 1).Range.Text = product.Name;
                worker.doc.Tables[1].Cell(i, 2).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                worker.doc.Tables[1].Cell(i, 3).Range.Text = Math.Round(product.Balance, 2).ToString();
                worker.doc.Tables[1].Cell(i, 4).Range.Text = Math.Round(product.Price, 2).ToString();
                worker.doc.Tables[1].Cell(i, 5).Range.Text = Math.Round(product.getSum(), 2).ToString();
                worker.doc.Tables[1].Cell(i, 9).Range.Text = Math.Round(product.getSum(), 2).ToString();
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

            worker.Save(MainForm.DataPath + "\\Документы\\" + invoiceInDb.Contract.ToString() + "\\" + invoiceInDb.ToString() + ".docx");
            worker.Close();
        }

        public void Delete(int id)
        {
            var invoice = MainForm.DB.Invoices.Get(id);
            if (MessageBox.Show("Вы уверены что хотите удалить счёт-фактуру №" + invoice.Number.ToString() + " со всеми её накладными? Все продукты пришедшие по накладной будут изъяты со склада!", "Удаление счёт-фактуры", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + invoice.FileName, FileMode.Open);
                List<ProductArrival> productsInInvoice = new BinaryFormatter().Deserialize(stream) as List<ProductArrival>;
                stream.Close();

                foreach (DeliveryNoteDTO deliveryNote in MainForm.DB.DeliveryNotes.GetAll())
                {
                    if (deliveryNote.InvoiceId == invoice.Id)
                    {
                        IDocumentService service = new DeliveryNotesService(); 
                        service.Delete(deliveryNote.Id);
                    }
                }

                string path = Application.StartupPath + "\\Local Data\\" + invoice.FileName;
                File.Delete(path);

                foreach (ProductArrival product in productsInInvoice)
                {
                    ProductDTO productInDb = MainForm.DB.Products.Get(product.Id);
                    productInDb.Sum = (float)Math.Round(productInDb.Sum - product.getSumRound(), 2);
                    productInDb.Balance = (float)(productInDb.Balance - product.Balance);
                }

                ContractDTO contract = MainForm.DB.Contracts.Get(invoice.ContractId);
                stream = new FileStream(Application.StartupPath + "\\Local Data\\" + contract.FileName, FileMode.Open);
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

                stream = new FileStream(Application.StartupPath + "\\Local Data\\" + contract.ToString() + "\\contract.cont", FileMode.Create);
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, productsInContract);
                stream.Close();

                MainForm.DB.Invoices.Delete(invoice.Id);
                MainForm.DB.Save();
            }
        }

        public void ReplaceStrings()
        {
            ContractDTO contract = MainForm.DB.Contracts.Get(invoiceInDb.ContractId);
            worker.FindReplace("{date}", invoiceInDb.Date.ToShortDateString());
            worker.FindReplace("{contractDate}", contract.ConclusionDate.ToLongDateString());
            worker.FindReplace("{contractNumber}", contract.Number.ToString());
            worker.FindReplace("{number}", invoiceInDb.Number.ToString());
            worker.FindReplace("{NameCompanySeller}", MainForm.DB.Sellers.Get(contract.SellerId).NameCompany);
            worker.FindReplace("{nameCompanyCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).NameCompany);
            worker.FindReplace("{nameSeller}", MainForm.DB.Sellers.Get(contract.SellerId).NameSeller);
            worker.FindReplace("{addressCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).AddressCompany);
            worker.FindReplace("{addressSeller}", MainForm.DB.Sellers.Get(contract.SellerId).AddressCompany);
            worker.FindReplace("{innCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).INN.ToString());
            worker.FindReplace("{innSeller}", MainForm.DB.Sellers.Get(contract.SellerId).INN.ToString());
            worker.FindReplace("{kppCustomer}", MainForm.DB.Customers.Get(contract.CustomerId).KPP.ToString());
            worker.FindReplace("{kppSeller}", MainForm.DB.Sellers.Get(contract.SellerId).KPP.ToString());
        }

        public void Open(string fileName)
        {
            worker.Open(fileName);
        }
    }
}
