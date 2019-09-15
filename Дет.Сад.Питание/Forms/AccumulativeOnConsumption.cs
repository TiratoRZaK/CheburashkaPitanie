using DAL.DTO;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;

namespace Дет.Сад.Питание.Forms
{
    public partial class AccumulativeOnConsumption : Form
    {
        public static Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        public static string generalfile = System.Windows.Forms.Application.StartupPath + "\\Документы\\Шаблоны\\Накопительная по расходу.docx"; // файл-шаблон
        public static Object fileName = generalfile;
        public static Object missing = System.Type.Missing;
        public static bool checkOpenDoc = false;
        public MainForm main;
        public AccumulativeOnConsumption(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeListBoxes();
        }

        void InitializeListBoxes()
        {
            foreach (MenuDTO item in MainForm.DB.Menus.GetAll())
                clBMenus.Items.Add(item);
            cBMount.DataSource = new string[]
            {
                "январь",
                "ферваль",
                "март",
                "апрель",
                "мая",
                "июнь",
                "июль",
                "август",
                "сентябрь",
                "октябрь",
                "ноябрь",
                "декабрь"
            };
            for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 100; i++)
            {
                cBYear.Items.Add(i);
            }
            cBYear.SelectedIndex = 0;
        }

        private void ButAddMenus_Click(object sender, EventArgs e)
        {
            if(clBMenus.CheckedItems.Count != 0)
            {
                if (checkOpenDoc)
                {
                    app = new Microsoft.Office.Interop.Word.Application();
                }
                checkOpenDoc = true;
                BuildDocument();
            }
        }

        private void AccumulativeOnConsumption_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
        }

        public void BuildDocument()
        {
            OpenFile();
            Document document = app.ActiveDocument;
            Range range = document.Paragraphs[document.Paragraphs.Count].Range;
            int productIndex = 4;
            int productIndexB = 4;
            int menuIndex = 3;
            double TotalAll = 0;
            double TotalAllB = 0;
            int totalKids = 0;
            int totalKidsB = 0;
            ProductInMenu productB = new ProductInMenu(1,"r",0,1,0,1,1,true);
            productB.SumNorms = 0;
            productB.TotalOfKids = 0;
            List<ProductInMenu> allProducts = new List<ProductInMenu>();
            List<MenuDTO> menus = new List<MenuDTO>();
            foreach (MenuDTO menu in clBMenus.CheckedItems)
            {
                totalKids += menu.Kids;
                Stream stream = new FileStream(menu.FileName, FileMode.Open);
                Models.Menu menuInFile = new BinaryFormatter().Deserialize(stream) as Models.Menu;
                stream.Close();
                document.Tables[1].Cell(1, menuIndex).Range.Text = menu.Date.Day.ToString();
                document.Tables[1].Cell(2, menuIndex).Range.Text = menu.Kids.ToString();
                document.Tables[2].Cell(1, menuIndex).Range.Text = menu.Date.Day.ToString();
                document.Tables[2].Cell(2, menuIndex).Range.Text = menu.KidsB.ToString();
                foreach (ProductInMenu product in menuInFile.Products)
                {
                    if (product.Id != menu.ProductBId)
                    {
                        if (allProducts.Where(x=>x.Id == product.Id).Count() == 0)
                        {
                            allProducts.Add(product);
                            allProducts.Single(x => x.Id == product.Id).SumNorms = product.TotalOfKids;
                            document.Tables[1].Cell(productIndex, 1).Range.Text = product.Name;
                            document.Tables[1].Cell(productIndex, 3).Range.Text = product.Price.ToString();
                            document.Tables[1].Cell(productIndex, menuIndex+2).Range.Text = product.TotalOfKids.ToString();
                            productIndex++;
                        }
                        else
                        {
                            int index = allProducts.IndexOf(allProducts.Single(x=>x.Id == product.Id)) + 4;
                            document.Tables[1].Cell(index, menuIndex+2).Range.Text = product.TotalOfKids.ToString();
                            allProducts.Single(x => x.Id == product.Id).SumNorms += product.TotalOfKids;
                        }
                    }
                    else
                    {
                        totalKidsB += menu.KidsB;
                        productB.Id = menu.ProductBId;
                        document.Tables[2].Cell(productIndexB, 1).Range.Text = product.Name;
                        document.Tables[2].Cell(productIndexB, 3).Range.Text = product.Price.ToString();
                        document.Tables[2].Cell(productIndexB, menuIndex + 2).Range.Text = product.TotalOfKids.ToString();
                        productB.SumNorms += product.TotalOfKids;
                        productB.Price = product.Price;
                    }
                }
                double summ = 0;
                double summB = 0;

                foreach (ProductInMenu productInMenu in menuInFile.Products)
                {
                    if (productInMenu.Id != menu.ProductBId)
                        summ += Math.Round((productInMenu.TotalOfKids * productInMenu.Price), 2);
                    else
                        summB += Math.Round((productInMenu.TotalOfKids * productInMenu.Price), 2);
                }
                document.Tables[1].Cell(54, menuIndex+2).Range.Text = summ.ToString();
                document.Tables[2].Cell(6, menuIndex + 2).Range.Text = summB.ToString();
                TotalAllB += summB;
                TotalAll += summ;
                menuIndex++;
            }
            document.Tables[1].Cell(54, 1).Range.Text = "ИТОГО";
            document.Tables[2].Cell(6, 1).Range.Text = "ИТОГО";
            double sumSumm = 0;
            foreach (ProductInMenu product in allProducts)
            {
                int index = allProducts.IndexOf(product) + 4;
                document.Tables[1].Cell(index, 2).Range.Text = allProducts.Single(x => x.Id == product.Id).SumNorms.ToString();
                document.Tables[1].Cell(index, 4).Range.Text = Math.Round(allProducts.Single(x => x.Id == product.Id).SumNorms * product.Price).ToString();
                sumSumm += Math.Round(allProducts.Single(x => x.Id == product.Id).SumNorms * product.Price);
            }
            document.Tables[1].Cell(54, 4).Range.Text = sumSumm.ToString();
            document.Tables[2].Cell(4, 2).Range.Text = productB.SumNorms.ToString();
            document.Tables[2].Cell(4, 4).Range.Text = Math.Round(productB.SumNorms * productB.Price).ToString();
            document.Tables[2].Cell(6, 4).Range.Text = Math.Round(productB.SumNorms * productB.Price).ToString();

            ReplaceStrings();
            FindReplace("{totalKids}", totalKids.ToString());
            FindReplace("{totalKidsB}", totalKidsB.ToString());
            FindReplace("{countMenu}", (menuIndex - 3).ToString());
            SaveFile(System.Windows.Forms.Application.StartupPath + "\\Документы\\Накопительные по расходу\\Накопительная по расходу за " + cBMount.SelectedItem.ToString() + " " + cBYear.SelectedItem.ToString() + ".docx");

        }

        void ReplaceStrings()
        {
            FindReplace("{mount}", cBMount.SelectedItem.ToString());
            FindReplace("{year}", cBYear.SelectedItem.ToString());
        }

        public void OpenFile()
        {
            app = new Microsoft.Office.Interop.Word.Application();
            app.Documents.Open(ref fileName);
            app.Visible = true;
        }

        public void SaveFile(string fileName)
        {
            app.ActiveDocument.SaveAs(fileName);
        }

        public void FindReplace(string str_old, string str_new)
        {
            Find find = app.Selection.Find;

            find.Text = str_old; // текст поиска
            find.Replacement.Text = str_new; // текст замены

            find.Execute(FindText: System.Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                        MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true, Wrap: WdFindWrap.wdFindContinue,
                        Format: false, ReplaceWith: missing, Replace: WdReplace.wdReplaceAll);
        }
    }
}
