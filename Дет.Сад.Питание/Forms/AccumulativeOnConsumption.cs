using DAL.DTO;
using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;
using System.Diagnostics;

namespace Дет.Сад.Питание.Forms
{
    public partial class AccumulativeOnConsumption : Form
    {
        public static Word.Application app = null;
        public static Word.Document doc = null;
        public static string generalfile = Application.StartupPath + "\\Документы\\Шаблоны\\Накопительная по расходу.docx"; // файл-шаблон
        public static Object fileName = generalfile;
        public static Object missing = Type.Missing;
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
                BuildDocument();
            }
        }

        private void AccumulativeOnConsumption_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
        }

        public void BuildDocument()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    lLoad.Visible = true;
                    foreach (Process proc in Process.GetProcessesByName("WINWORD"))
                    {
                        proc.Kill();
                    }
                    app = new Word.Application();
                    doc = app.Documents.Open(fileName);
                    doc.Activate();
                    Word.Range range = doc.Paragraphs[doc.Paragraphs.Count].Range;
                    int productIndex = 4;
                    int productIndexB = 4;
                    int menuIndex = 3;
                    double TotalAll = 0;
                    double TotalAllB = 0;
                    int totalKids = 0;
                    int totalKidsB = 0;
                    ProductInMenu productB = new ProductInMenu(1, "r", 0, 1, 0, 1, 1, true);
                    productB.SumNorms = 0;
                    productB.TotalOfKids = 0;
                    List<ProductInMenu> allProducts = new List<ProductInMenu>();
                    List<MenuDTO> menus = new List<MenuDTO>();
                    foreach (MenuDTO menu in clBMenus.CheckedItems)
                    {
                        totalKids += menu.Kids;
                        Stream stream = new FileStream(Application.StartupPath + menu.FileName, FileMode.Open);
                        Models.Menu menuInFile = new BinaryFormatter().Deserialize(stream) as Models.Menu;
                        stream.Close();
                        doc.Tables[1].Cell(1, menuIndex).Range.Text = menu.Date.Day.ToString();
                        doc.Tables[1].Cell(2, menuIndex).Range.Text = menu.Kids.ToString();
                        doc.Tables[2].Cell(1, menuIndex).Range.Text = menu.Date.Day.ToString();
                        doc.Tables[2].Cell(2, menuIndex).Range.Text = menu.KidsB.ToString();
                        foreach (ProductInMenu product in menuInFile.Products)
                        {
                            if (product.Id != menu.ProductBId)
                            {
                                if (allProducts.Where(x => x.Id == product.Id).Count() == 0)
                                {
                                    allProducts.Add(product);
                                    allProducts.Single(x => x.Id == product.Id).SumNorms = product.TotalOfKids;
                                    doc.Tables[1].Cell(productIndex, 1).Range.Text = product.Name;
                                    doc.Tables[1].Cell(productIndex, 3).Range.Text = product.Price.ToString();
                                    doc.Tables[1].Cell(productIndex, menuIndex + 2).Range.Text = product.TotalOfKids.ToString();
                                    productIndex++;
                                }
                                else
                                {
                                    int index = allProducts.IndexOf(allProducts.Single(x => x.Id == product.Id)) + 4;
                                    doc.Tables[1].Cell(index, menuIndex + 2).Range.Text = product.TotalOfKids.ToString();
                                    allProducts.Single(x => x.Id == product.Id).SumNorms += product.TotalOfKids;
                                }
                            }
                            else
                            {
                                totalKidsB += menu.KidsB;
                                productB.Id = menu.ProductBId;
                                doc.Tables[2].Cell(productIndexB, 1).Range.Text = product.Name;
                                doc.Tables[2].Cell(productIndexB, 3).Range.Text = product.Price.ToString();
                                doc.Tables[2].Cell(productIndexB, menuIndex + 2).Range.Text = product.TotalOfKids.ToString();
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
                        doc.Tables[1].Cell(54, menuIndex + 2).Range.Text = summ.ToString();
                        doc.Tables[2].Cell(6, menuIndex + 2).Range.Text = summB.ToString();
                        TotalAllB += summB;
                        TotalAll += summ;
                        menuIndex++;
                    }
                    doc.Tables[1].Cell(54, 1).Range.Text = "ИТОГО";
                    doc.Tables[2].Cell(6, 1).Range.Text = "ИТОГО";
                    double sumSumm = 0;
                    foreach (ProductInMenu product in allProducts)
                    {
                        int index = allProducts.IndexOf(product) + 4;
                        doc.Tables[1].Cell(index, 2).Range.Text = allProducts.Single(x => x.Id == product.Id).SumNorms.ToString();
                        doc.Tables[1].Cell(index, 4).Range.Text = Math.Round(allProducts.Single(x => x.Id == product.Id).SumNorms * product.Price).ToString();
                        sumSumm += Math.Round(allProducts.Single(x => x.Id == product.Id).SumNorms * product.Price);
                    }
                    doc.Tables[1].Cell(54, 4).Range.Text = sumSumm.ToString();
                    doc.Tables[2].Cell(4, 2).Range.Text = productB.SumNorms.ToString();
                    doc.Tables[2].Cell(4, 4).Range.Text = Math.Round(productB.SumNorms * productB.Price).ToString();
                    doc.Tables[2].Cell(6, 4).Range.Text = Math.Round(productB.SumNorms * productB.Price).ToString();

                    ReplaceStrings();
                    FindReplace("{totalKids}", totalKids.ToString());
                    FindReplace("{totalKidsB}", totalKidsB.ToString());
                    FindReplace("{countMenu}", (menuIndex - 3).ToString());
                    SaveFile(Application.StartupPath + "\\Документы\\Накопительные по расходу\\Накопительная по расходу за " + cBMount.SelectedItem.ToString() + " " + cBYear.SelectedItem.ToString() + ".docx");
                    app.Visible = true;
                    doc = null;
                    lLoad.Visible = false;
                }
            }
            catch (Exception ex)
            {
                doc.Close();
                doc = null;
                throw new Exception("Во время выполнения произошла ошибка!");
            }
        }

        void ReplaceStrings()
        {
            FindReplace("{mount}", cBMount.SelectedItem.ToString());
            FindReplace("{year}", cBYear.SelectedItem.ToString());
        }

        public void SaveFile(string fileName)
        {
            app.ActiveDocument.SaveAs(fileName);
        }

        public void FindReplace(string str_old, string str_new)
        {
            Word.Find find = app.Selection.Find;

            find.Text = str_old; // текст поиска
            find.Replacement.Text = str_new; // текст замены

            find.Execute(FindText: System.Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                        MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true, Wrap: Word.WdFindWrap.wdFindContinue,
                        Format: false, ReplaceWith: missing, Replace: Word.WdReplace.wdReplaceAll);
        }
    }
}
