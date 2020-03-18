using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Дет.Сад.Питание.Services.WordService;

namespace Дет.Сад.Питание.Services
{
    public class ProductService
    {
        WordWorker worker = new WordWorker(Application.StartupPath + "\\Document Templates\\Остатки продуктов.docx");

        public void BuildDocument()
        {
            worker.Load();
            Microsoft.Office.Interop.Word.Range range = worker.doc.Paragraphs[worker.doc.Paragraphs.Count].Range;
            double summ = 0;
            int i = 2;
            foreach (ProductDTO product in MainForm.DB.Products.GetAll())
            {
                worker.doc.Tables[1].Rows.Add();
                i++;
                worker.doc.Tables[1].Cell(i, 1).Range.Text = product.Name;
                worker.doc.Tables[1].Cell(i, 2).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                worker.doc.Tables[1].Cell(i, 4).Range.Text = product.Balance.ToString();
                worker.doc.Tables[1].Cell(i, 3).Range.Text = product.GetPrice().ToString();
                worker.doc.Tables[1].Cell(i, 5).Range.Text = Math.Round(product.Sum, 2).ToString();
                summ += product.Sum;
            }
            worker.doc.Tables[1].Rows.Add();
            i++;
            worker.doc.Tables[1].Cell(i, 1).Range.Text = "Итого";
            worker.doc.Tables[1].Cell(i, 5).Range.Text = Math.Round(summ, 2).ToString();
            DateTime now = DateTime.Now;
            worker.Save(MainForm.DataPath + "\\Документы\\Остатки продуктов на " + (now.ToString("g")).Replace('.', '-').Replace(':', '-') + ".docx");
            worker.Close();
            worker.Open(MainForm.DataPath + "\\Документы\\Остатки продуктов на " + (now.ToString("g")).Replace('.', '-').Replace(':', '-') + ".docx");
            LoggingService.AddLog("Распечатка остатков на " + (now.ToString("g")).Replace('.', '-').Replace(':', '-') + " в файл по пути: " + MainForm.DataPath + "\\Документы\\");
        }

        public void Delete(int id)
        {
            string name = MainForm.DB.Products.Get(id).Name;
            MainForm.DB.Products.Delete(id);
            MainForm.DB.Save();
            LoggingService.AddLog("Удаление продукта: " + name);
        }
    }
}
