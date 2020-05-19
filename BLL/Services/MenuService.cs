using BLL.Models;
using BLL.Services.WordService;
using DAL.DTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace BLL.Services
{
    public class MenuService : IDocumentService<MenuDTO>
    {
        MenuDTO menuInDB;
        private WordWorker worker;
        private IUnitOfWork DB;
        private string startupPath;
        private string dataPath;

        public MenuService(IUnitOfWork DB, string startupPath, string dataPath)
        {
            this.DB = DB;
            this.startupPath = startupPath;
            this.dataPath = dataPath;
            worker = new WordWorker(startupPath + "\\Document Templates\\Меню.docx");
        }

        public void BuildDocument(MenuDTO menu)
        {
            menuInDB = menu;

            Stream stream = new FileStream(startupPath + "\\Local Data" + menuInDB.FileName, FileMode.Open);
            Menu menuInFile = new BinaryFormatter().Deserialize(stream) as Menu;

            worker.Load();
            ReplaceStrings();
            Microsoft.Office.Interop.Word.Range range = worker.doc.Paragraphs[worker.doc.Paragraphs.Count].Range;
            int i = 4;
            int y = 3;
            Dictionary<int, int> productsId = new Dictionary<int, int>();
            foreach (DishDTO dishZ in menuInFile.DishesZ)
            {
                worker.doc.Tables[1].Cell(i, 2).Range.Text = dishZ.Name;
                foreach (ProductDishDTO productDish in DB.ProductDishes.GetAll().Where(x => x.DishId == dishZ.Id))
                {
                    if (!productsId.Keys.Contains(productDish.ProductId))
                    {
                        productsId.Add(productDish.ProductId, y);
                        worker.doc.Tables[1].Cell(2, y - 1).Range.Text = DB.Products.Get(productDish.ProductId).PsevdoName;
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
                foreach (ProductDishDTO productDish in DB.ProductDishes.GetAll().Where(x => x.DishId == dishO.Id))
                {
                    if (!productsId.Keys.Contains(productDish.ProductId))
                    {
                        productsId.Add(productDish.ProductId, y);
                        worker.doc.Tables[1].Cell(2, y - 1).Range.Text = DB.Products.Get(productDish.ProductId).PsevdoName;
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
                foreach (ProductDishDTO productDish in DB.ProductDishes.GetAll().Where(x => x.DishId == dishP.Id))
                {
                    if (!productsId.Keys.Contains(productDish.ProductId))
                    {
                        productsId.Add(productDish.ProductId, y);
                        worker.doc.Tables[1].Cell(2, y - 1).Range.Text = DB.Products.Get(productDish.ProductId).PsevdoName;
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
                if (product.Id != menuInDB.ProductBId)
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
                if (prod.Id != menuInDB.ProductBId)
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
            worker.FindReplace("{total}", Math.Round((summ + summB), 2).ToString());

            worker.Save(dataPath + "\\Документы\\Меню\\Меню на " + menuInDB.Date.ToLongDateString() + ".docx");
            worker.Close();
        }

        public void Delete(MenuDTO menuInDB)
        {
            string path = startupPath + "\\Local Data" + menuInDB.FileName;

            Stream stream = new FileStream(path, FileMode.Open);
            Menu menu = new BinaryFormatter().Deserialize(stream) as Menu;
            stream.Close();
            File.Delete(path);

            foreach (ProductInMenu product in menu.Products)
            {

                ProductDTO productInDB = DB.Products.Get(product.Id);
                if (productInDB.Balance != 0)
                {
                    float tempPrice = productInDB.Sum / productInDB.Balance;
                    productInDB.Balance = (float)Math.Round((productInDB.Balance + product.TotalOfKids), 2);
                    productInDB.Sum = (float)Math.Round(productInDB.Balance * tempPrice, 2);
                    DB.Products.Update(productInDB);
                    DB.Save();
                }
                else
                {
                    productInDB.Balance = (float)Math.Round((product.TotalOfKids), 2);
                    productInDB.Sum = (float)Math.Round(productInDB.Balance * product.Price, 2);
                    DB.Products.Update(productInDB);
                    DB.Save();
                }
            }
            DB.Menus.Delete(menuInDB.Id);
            DB.Save();
        }

        public bool Open(string fileName)
        {
            return worker.Open(fileName);
        }

        private void ReplaceStrings()
        {
            worker.FindReplace("{vrachName}", menuInDB.Vrach);
            worker.FindReplace("{kladName}", menuInDB.Klad);
            worker.FindReplace("{otdelenie}", menuInDB.Otdelenie);
            worker.FindReplace("{uchregdenie}", menuInDB.Uchregdenie);
            worker.FindReplace("{povarName}", menuInDB.Povar);
            worker.FindReplace("{rukovoditelName}", menuInDB.Rukowoditel);
            worker.FindReplace("{date}", menuInDB.Date.ToShortDateString());
            worker.FindReplace("{kids}", (menuInDB.Kids + menuInDB.KidsB).ToString());
        }

        public bool IsAvailableDate(DateTime date)
        {
            return DB.Menus.GetAll().Where(x => x.Date.Date.Equals(date.Date)).Count() == 0;
        }

        private bool checkValidateProducts(List<ProductInMenu> addedProducts)
        {
            foreach (ProductInMenu productInMenu in addedProducts)
            {
                ProductDTO productInDB = DB.Products.Get(productInMenu.Id);
                if (Math.Round(productInDB.Balance, 2) < productInMenu.TotalOfKids)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CreateMenu(DateTime dateCreate, int kids, int kidsB, string kladName, string povarName, string rukowoditelName, string vrachName, string otdelenieName, string uchregdenieName, int productBId, List<ProductInMenu> addedProducts, List<DishDTO> listZ, List<DishDTO> listO, List<DishDTO> listP)
        {
            if (checkValidateProducts(addedProducts))
            {
                MenuDTO menu = new MenuDTO
                {
                    Date = dateCreate,
                    Kids = kids,
                    KidsB = kidsB,
                    Klad = kladName,
                    Povar = povarName,
                    Rukowoditel = rukowoditelName,
                    Vrach = vrachName,
                    Otdelenie = otdelenieName,
                    Uchregdenie = uchregdenieName,
                    ProductBId = productBId,
                    FileName = "\\Меню на " + dateCreate.ToLongDateString() + ".menu"
                };
                DB.Menus.Create(menu);
                foreach (ProductInMenu productInMenu in addedProducts)
                {
                    ProductDTO productInDB = DB.Products.Get(productInMenu.Id);
                    float tempPrice = productInDB.GetPrice();
                    productInDB.Balance = (float)Math.Round(productInDB.Balance - (float)productInMenu.TotalOfKids, 2);
                    productInDB.Sum = (float)Math.Round(productInDB.Balance * tempPrice, 2);
                    DB.Products.Update(productInDB);
                }
                DB.Save();
                Menu menuInFile = new Menu();
                menuInFile.DateCreate = dateCreate;
                menuInFile.Products = addedProducts;
                foreach (object item in listZ)
                {
                    menuInFile.DishesZ.Add(DB.Dishes.Get((item as DishDTO).Id));
                }
                foreach (object item in listO)
                {
                    menuInFile.DishesO.Add(DB.Dishes.Get((item as DishDTO).Id));
                }
                foreach (object item in listP)
                {
                    menuInFile.DishesP.Add(DB.Dishes.Get((item as DishDTO).Id));
                }
                BinaryFormatter serializer = new BinaryFormatter();
                Stream stream = new FileStream(startupPath + "\\Local Data" + menu.FileName, FileMode.Create);
                serializer.Serialize(stream, menuInFile);
                stream.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
