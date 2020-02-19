using DAL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;

namespace Дет.Сад.Питание.Services
{
    class InvoiceService
    {
        public static void Delete(int id)
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
                        DeliveryNotesService.Delete(deliveryNote.Id);
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
    }
}
