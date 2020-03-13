using DAL.DTO;
using Дет.Сад.Питание.Services.WordWorker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;
using Word = Microsoft.Office.Interop.Word;

namespace Дет.Сад.Питание.Forms
{
    public partial class AccumulativeOnConsumption : Form
    {
        public WordWorker WordWorker;
        public MainForm main;
        public AccumulativeOnConsumption(MainForm main)
        {
            this.main = main;
            WordWorker = new WordWorker(Application.StartupPath + "\\Document Templates\\Накопительная по расходу.docx");
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
            if (clBMenus.CheckedItems.Count != 0)
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
                ProductInMenu productB = new ProductInMenu(1, "r", 0, 1, 0, 1, 1, true)
                {
                    SumNorms = 0,
                    TotalOfKids = 0
                };
                List<ProductInMenu> allProducts = new List<ProductInMenu>();
                List<MenuDTO> menus = new List<MenuDTO>();
                foreach (MenuDTO menu in clBMenus.CheckedItems)
                {
                    totalKids += menu.Kids;
                    totalKidsB += menu.KidsB;
                    Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\" + menu.FileName, FileMode.Open);
                    Models.Menu menuInFile = new BinaryFormatter().Deserialize(stream) as Models.Menu;
                    stream.Close();
                    WordWorker.doc.Tables[1].Cell(1, menuIndex).Range.Text = menu.Date.Day.ToString();
                    WordWorker.doc.Tables[1].Cell(2, menuIndex).Range.Text = (menu.Kids + menu.KidsB).ToString();
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
                                WordWorker.doc.Tables[1].Cell(productIndex, 3).Range.Text = Math.Round(product.Price, 2).ToString();
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
                            productB.Id = menu.ProductBId;
                            WordWorker.doc.Tables[2].Cell(productIndexB, 1).Range.Text = product.Name;
                            WordWorker.doc.Tables[2].Cell(productIndexB, 3).Range.Text = Math.Round(product.Price, 2).ToString();
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
                            summ = Math.Round(summ + Math.Round((productInMenu.TotalOfKids * productInMenu.Price), 2),2);
                        else
                            summB += Math.Round(summB + Math.Round((productInMenu.TotalOfKids * productInMenu.Price), 2),2);
                    }
                    WordWorker.doc.Tables[1].Cell(54, menuIndex + 2).Range.Text = Math.Round(summ, 2).ToString();
                    WordWorker.doc.Tables[2].Cell(6, menuIndex + 2).Range.Text = Math.Round(summB, 2).ToString();
                    TotalAllB = Math.Round(TotalAllB + summB,2);
                    TotalAll = Math.Round(TotalAll + summ,2);
                    menuIndex++;
                }
                WordWorker.doc.Tables[1].Cell(54, 1).Range.Text = "ИТОГО";
                WordWorker.doc.Tables[2].Cell(6, 1).Range.Text = "ИТОГО";
                double sumSumm = 0;
                foreach (ProductInMenu product in allProducts)
                {
                    int index = allProducts.IndexOf(product) + 4;
                    WordWorker.doc.Tables[1].Cell(index, 2).Range.Text = allProducts.Single(x => x.Id == product.Id).SumNorms.ToString();
                    WordWorker.doc.Tables[1].Cell(index, 4).Range.Text = Math.Round(Math.Round(allProducts.Single(x => x.Id == product.Id).SumNorms, 2) * product.Price, 2).ToString();
                    sumSumm = Math.Round(sumSumm + Math.Round(Math.Round(allProducts.Single(x => x.Id == product.Id).SumNorms, 2) * product.Price, 2), 2);
                }
                WordWorker.doc.Tables[1].Cell(54, 4).Range.Text = Math.Round(sumSumm, 2).ToString();
                WordWorker.doc.Tables[2].Cell(4, 2).Range.Text = productB.SumNorms.ToString();  
                WordWorker.doc.Tables[2].Cell(4, 4).Range.Text = Math.Round(productB.SumNorms * productB.Price, 2).ToString();
                WordWorker.doc.Tables[2].Cell(6, 4).Range.Text = Math.Round(productB.SumNorms * productB.Price, 2).ToString();

                ReplaceStrings();
                WordWorker.FindReplace("{totalKids}", (totalKids + totalKidsB).ToString());
                WordWorker.FindReplace("{totalKidsB}", totalKidsB.ToString());
                WordWorker.FindReplace("{countMenu}", (menuIndex - 3).ToString());
                WordWorker.Save(MainForm.DataPath + "\\Документы\\Накопительные по расходу\\Накопительная по расходу за " + cBMount.SelectedItem.ToString() + " " + cBYear.SelectedItem.ToString() + ".docx");
                WordWorker.app.Visible = true;
                WordWorker.doc = null;
                lLoad.Visible = false;
            }
            WordWorker.Close();

        }

        void ReplaceStrings()
        {
            WordWorker.FindReplace("{mount}", cBMount.SelectedItem.ToString());
            WordWorker.FindReplace("{year}", cBYear.SelectedItem.ToString());
        }

        private void butCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clBMenus.Items.Count; i++)
            {
                clBMenus.SetItemChecked(i, true);
            }
        }

        private void butCheckClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clBMenus.Items.Count; i++)
            {
                clBMenus.SetItemChecked(i, false);
            }
        }
    }
}
