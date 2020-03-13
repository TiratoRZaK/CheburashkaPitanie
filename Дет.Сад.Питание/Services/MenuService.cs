using DAL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;
using Дет.Сад.Питание.Services.WordService;

namespace Дет.Сад.Питание.Services
{
    public class MenuService : IDocumentService
    {
        WordWorker worker = new WordWorker(Application.StartupPath + "\\Document Templates\\Меню.docx");
        MenuDTO menuInDb;
        public void BuildDocument(int id)
        {
            menuInDb = MainForm.DB.Menus.Get(id);

            Stream stream = new FileStream(Application.StartupPath + "\\Local Data"+menuInDb.FileName, FileMode.Open);
            Models.Menu menuInFile = new BinaryFormatter().Deserialize(stream) as Models.Menu;
            
            worker.Load();
            ReplaceStrings();
            Microsoft.Office.Interop.Word.Range range = worker.doc.Paragraphs[worker.doc.Paragraphs.Count].Range;
            int i = 4;
            int y = 3;
            Dictionary<int, int> productsId = new Dictionary<int, int>();
            foreach (DishDTO dishZ in menuInFile.DishesZ)
            {
                worker.doc.Tables[1].Cell(i, 2).Range.Text = dishZ.Name;
                foreach (ProductDishDTO productDish in MainForm.DB.ProductDishes.GetAll().Where(x => x.DishId == dishZ.Id))
                {
                    if (!productsId.Keys.Contains(productDish.ProductId))
                    {
                        productsId.Add(productDish.ProductId, y);
                        worker.doc.Tables[1].Cell(2, y - 1).Range.Text = MainForm.DB.Products.Get(productDish.ProductId).PsevdoName;
                        worker.doc.Tables[1].Cell(i, y).Range.Text = productDish.Norm.ToString();
                        y++;
                    }
                    else
                    {
                        int s;
                        productsId.TryGetValue(productDish.ProductId, out s);
                        worker.doc.Tables[1].Cell(i, s).Range.Text = productDish.Norm.ToString();
                    }
                }
                i++;
            }
            i = 9;
            foreach (DishDTO dishO in menuInFile.DishesO)
            {
                worker.doc.Tables[1].Cell(i, 2).Range.Text = dishO.Name;
                foreach (ProductDishDTO productDish in MainForm.DB.ProductDishes.GetAll().Where(x => x.DishId == dishO.Id))
                {
                    if (!productsId.Keys.Contains(productDish.ProductId))
                    {
                        productsId.Add(productDish.ProductId, y);
                        worker.doc.Tables[1].Cell(2, y - 1).Range.Text = MainForm.DB.Products.Get(productDish.ProductId).PsevdoName;
                        worker.doc.Tables[1].Cell(i, y).Range.Text = productDish.Norm.ToString();
                        y++;
                    }
                    else
                    {
                        int s;
                        productsId.TryGetValue(productDish.ProductId, out s);
                        worker.doc.Tables[1].Cell(i, s).Range.Text = productDish.Norm.ToString();
                    }
                }
                i++;
            }
            i = 15;
            foreach (DishDTO dishP in menuInFile.DishesP)
            {
                worker.doc.Tables[1].Cell(i, 2).Range.Text = dishP.Name;
                foreach (ProductDishDTO productDish in MainForm.DB.ProductDishes.GetAll().Where(x => x.DishId == dishP.Id))
                {
                    if (!productsId.Keys.Contains(productDish.ProductId))
                    {
                        productsId.Add(productDish.ProductId, y);
                        worker.doc.Tables[1].Cell(2, y - 1).Range.Text = MainForm.DB.Products.Get(productDish.ProductId).PsevdoName;
                        worker.doc.Tables[1].Cell(i, y).Range.Text = productDish.Norm.ToString();
                        y++;
                    }
                    else
                    {
                        int s;
                        productsId.TryGetValue(productDish.ProductId, out s);
                        worker.doc.Tables[1].Cell(i, s).Range.Text = productDish.Norm.ToString();
                    }
                }
                i++;
            }
            foreach (ProductInMenu product in menuInFile.Products)
            {
                int s;
                productsId.TryGetValue(product.Id, out s);
                worker.doc.Tables[1].Cell(20, s - 1).Range.Text = Math.Round(product.SumNorms, 2).ToString();
                worker.doc.Tables[1].Cell(21, s - 1).Range.Text = Math.Round(product.TotalOfKids, 2).ToString();
                worker.doc.Tables[1].Cell(22, s - 1).Range.Text = Math.Round(product.Price, 2).ToString();
                if (product.Id != menuInDb.ProductBId)
                {
                    worker.doc.Tables[1].Cell(23, s).Range.Text = Math.Round(product.TotalOfKids * product.Price, 2).ToString();
                }
                else
                {
                    worker.doc.Tables[1].Cell(24, s).Range.Text = Math.Round(product.TotalOfKids * product.Price, 2).ToString();
                }
            }
            double summ = 0.0d;
            double summB = 0.0d;
            foreach (ProductInMenu prod in menuInFile.Products)
            {
                if(prod.Id != menuInDb.ProductBId)
                {
                    summ += prod.Price * prod.TotalOfKids;
                }
                else
                {
                    summB += prod.Price * prod.TotalOfKids;
                }
            }
            worker.doc.Tables[1].Cell(23, 2).Range.Text = Math.Round(summ, 2).ToString();
            worker.doc.Tables[1].Cell(24, 2).Range.Text = Math.Round(summB, 2).ToString();
            worker.FindReplace("{total}", (summ + summB).ToString());

            worker.Save(MainForm.DataPath + "\\Документы\\Меню\\Меню на " + menuInDb.Date.ToLongDateString() + ".docx");
            worker.Close();
        }

        public void Delete(int id)
        {
            var menuInDb = MainForm.DB.Menus.Get(id);
            string path = Application.StartupPath + "\\Local Data" + menuInDb.FileName;

            Stream stream = new FileStream(path, FileMode.Open);
            Models.Menu menu = new BinaryFormatter().Deserialize(stream) as Models.Menu;

            File.Delete(path);

            foreach (ProductInMenu product in menu.Products)
            {
                ProductDTO productInDb = MainForm.DB.Products.Get(product.Id);
                float tempPrice = productInDb.Sum / productInDb.Balance;
                productInDb.Balance = (float)Math.Round((productInDb.Balance + product.TotalOfKids), 2);
                productInDb.Sum = (float)Math.Round(productInDb.Balance * tempPrice, 2);
                MainForm.DB.Products.Update(productInDb);
                MainForm.DB.Save();
            }
            MainForm.DB.Menus.Delete(id);
            MainForm.DB.Save();
        }

        public void Open(string fileName)
        {
            worker.Open(fileName);
        }

        public void ReplaceStrings()
        {
            worker.FindReplace("{vrachName}", menuInDb.Vrach);
            worker.FindReplace("{kladName}", menuInDb.Klad);
            worker.FindReplace("{otdelenie}", menuInDb.Otdelenie);
            worker.FindReplace("{uchregdenie}", menuInDb.Uchregdenie);
            worker.FindReplace("{povarName}", menuInDb.Povar);
            worker.FindReplace("{rukovoditelName}", menuInDb.Rukowoditel);
            worker.FindReplace("{date}", menuInDb.Date.ToShortDateString());
            worker.FindReplace("{kids}", (menuInDb.Kids + menuInDb.KidsB).ToString());
        }
    }
}
