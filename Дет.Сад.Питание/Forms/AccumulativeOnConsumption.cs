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
using Servises.WordWorker;

namespace Дет.Сад.Питание.Forms
{
    public partial class AccumulativeOnConsumption : Form
    {
        public WordWorker WordWorker = new WordWorker(Application.StartupPath + "\\Документы\\Шаблоны\\Накопительная по расходу.docx");
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
                    WordWorker.Load();
                    Word.Range range = WordWorker.doc.Paragraphs[WordWorker.doc.Paragraphs.Count].Range;
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
                        WordWorker.doc.Tables[1].Cell(1, menuIndex).Range.Text = menu.Date.Day.ToString();
                        WordWorker.doc.Tables[1].Cell(2, menuIndex).Range.Text = menu.Kids.ToString();
                        WordWorker.doc.Tables[2].Cell(1, menuIndex).Range.Text = menu.Date.Day.ToString();
                        WordWorker.doc.Tables[2].Cell(2, menuIndex).Range.Text = menu.KidsB.ToString();
                        foreach (ProductInMenu product in menuInFile.Products)
                        {
                            if (product.Id != menu.ProductBId)
                            {
                                if (allProducts.Where(x => x.Id == product.Id).Count() == 0)
                                {
                                    allProducts.Add(product);
                                    allProducts.Single(x => x.Id == product.Id).SumNorms = product.TotalOfKids;
                                    WordWorker.doc.Tables[1].Cell(productIndex, 1).Range.Text = product.Name;
                                    WordWorker.doc.Tables[1].Cell(productIndex, 3).Range.Text = product.Price.ToString();
                                    WordWorker.doc.Tables[1].Cell(productIndex, menuIndex + 2).Range.Text = product.TotalOfKids.ToString();
                                    productIndex++;
                                }
                                else
                                {
                                    int index = allProducts.IndexOf(allProducts.Single(x => x.Id == product.Id)) + 4;
                                    WordWorker.doc.Tables[1].Cell(index, menuIndex + 2).Range.Text = product.TotalOfKids.ToString();
                                    allProducts.Single(x => x.Id == product.Id).SumNorms += product.TotalOfKids;
                                }
                            }
                            else
                            {
                                totalKidsB += menu.KidsB;
                                productB.Id = menu.ProductBId;
                                WordWorker.doc.Tables[2].Cell(productIndexB, 1).Range.Text = product.Name;
                                WordWorker.doc.Tables[2].Cell(productIndexB, 3).Range.Text = product.Price.ToString();
                                WordWorker.doc.Tables[2].Cell(productIndexB, menuIndex + 2).Range.Text = product.TotalOfKids.ToString();
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
                        WordWorker.doc.Tables[1].Cell(54, menuIndex + 2).Range.Text = summ.ToString();
                        WordWorker.doc.Tables[2].Cell(6, menuIndex + 2).Range.Text = summB.ToString();
                        TotalAllB += summB;
                        TotalAll += summ;
                        menuIndex++;
                    }
                    WordWorker.doc.Tables[1].Cell(54, 1).Range.Text = "ИТОГО";
                    WordWorker.doc.Tables[2].Cell(6, 1).Range.Text = "ИТОГО";
                    double sumSumm = 0;
                    foreach (ProductInMenu product in allProducts)
                    {
                        int index = allProducts.IndexOf(product) + 4;
                        WordWorker.doc.Tables[1].Cell(index, 2).Range.Text = allProducts.Single(x => x.Id == product.Id).SumNorms.ToString();
                        WordWorker.doc.Tables[1].Cell(index, 4).Range.Text = Math.Round(allProducts.Single(x => x.Id == product.Id).SumNorms * product.Price).ToString();
                        sumSumm += Math.Round(allProducts.Single(x => x.Id == product.Id).SumNorms * product.Price);
                    }
                    WordWorker.doc.Tables[1].Cell(54, 4).Range.Text = sumSumm.ToString();
                    WordWorker.doc.Tables[2].Cell(4, 2).Range.Text = productB.SumNorms.ToString();
                    WordWorker.doc.Tables[2].Cell(4, 4).Range.Text = Math.Round(productB.SumNorms * productB.Price).ToString();
                    WordWorker.doc.Tables[2].Cell(6, 4).Range.Text = Math.Round(productB.SumNorms * productB.Price).ToString();

                    ReplaceStrings();
                    WordWorker.FindReplace("{totalKids}", totalKids.ToString());
                    WordWorker.FindReplace("{totalKidsB}", totalKidsB.ToString());
                    WordWorker.FindReplace("{countMenu}", (menuIndex - 3).ToString());
                    WordWorker.Save(Application.StartupPath + "\\Документы\\Накопительные по расходу\\Накопительная по расходу за " + cBMount.SelectedItem.ToString() + " " + cBYear.SelectedItem.ToString() + ".docx");
                    WordWorker.app.Visible = true;
                    WordWorker.doc = null;
                    lLoad.Visible = false;
                }
            }
            catch (Exception ex)
            {
                WordWorker.Close();
                throw new Exception("Во время выполнения произошла ошибка!");
            }
        }

        void ReplaceStrings()
        {
            WordWorker.FindReplace("{mount}", cBMount.SelectedItem.ToString());
            WordWorker.FindReplace("{year}", cBYear.SelectedItem.ToString());
        }
    }
}
