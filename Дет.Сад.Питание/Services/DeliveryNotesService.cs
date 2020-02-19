using DAL.DTO;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;

namespace Дет.Сад.Питание.Services
{
    public class DeliveryNotesService
    {
        public static void Delete(int id)
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
    }
}
