using DAL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Services
{
    public class ContractsService
    {
        public static void Delete(int id)
        {
            ContractDTO contract = MainForm.DB.Contracts.Get(id);
            if (MessageBox.Show("Вы уверены что хотите удалить договор №" + contract.Number.ToString() + " вместе с его счёт-фактурами и накладными?", "Удаление договора", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (var invoice in MainForm.DB.Invoices.GetAll())
                {
                    if (invoice.ContractId == contract.Id)
                    {
                        InvoiceService.Delete(invoice.Id);
                    }
                }
                string path = Application.StartupPath + "\\Local Data\\" + contract.ToString();
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (dirInfo.Exists)
                {
                    dirInfo.Delete(true);
                }
                MainForm.DB.Contracts.Delete(contract.Id);
                MainForm.DB.Save();
            }
        }
    }
}
