using BLL.Services.WordService;
using DAL.DTO;
using DAL.Interfaces;
using NLog;
using System;

namespace BLL.Services
{
    public class ProductService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private WordWorker worker;
        private IUnitOfWork DB;
        private string dataPath;

        public ProductService(IUnitOfWork DB, string startupPath, string dataPath)
        {
            this.DB = DB;
            this.dataPath = dataPath;
            worker = new WordWorker(startupPath + "\\Document Templates\\Остатки продуктов.docx");
        }

        public void BuildDocument()
        {
            logger.Debug("Формирование файла с остатками продуктов.");
            worker.Load();
            Microsoft.Office.Interop.Word.Range range = worker.doc.Paragraphs[worker.doc.Paragraphs.Count].Range;
            double summ = 0;
            int i = 2;
            foreach (ProductDTO product in DB.Products.GetAll())
            {
                worker.doc.Tables[1].Rows.Add();
                i++;
                worker.doc.Tables[1].Cell(i, 1).Range.Text = product.Name;
                worker.doc.Tables[1].Cell(i, 2).Range.Text = DB.Units.Get(product.UnitId).Name;
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
            worker.Save(dataPath + "\\Документы\\Остатки продуктов на " + (now.ToString("g")).Replace('.', '-').Replace(':', '-') + ".docx");
            worker.Close();
            logger.Debug("Остатки продуктов сохранены в файле: " + dataPath + "\\Документы\\Остатки продуктов на " + (now.ToString("g")).Replace('.', '-').Replace(':', '-') + ".docx");
            worker.Open(dataPath + "\\Документы\\Остатки продуктов на " + (now.ToString("g")).Replace('.', '-').Replace(':', '-') + ".docx");
        }

        public void Delete(ProductDTO product)
        {
            DB.Products.Delete(product.Id);
            DB.Save();
            logger.Debug("Удаление продукта: " + product.PsevdoName + ". С id = " + product.Id + ".");
        }
    }
}
