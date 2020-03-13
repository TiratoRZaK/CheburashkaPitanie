using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;
using Дет.Сад.Питание.Services.WordWorker;
using Word = Microsoft.Office.Interop.Word;

namespace Дет.Сад.Питание.Forms
{
    public partial class MenusForm : Form
    {
        public WordWorker WordWorker;

        public MenuDTO menu = null;
        public List<ProductInMenu> addedProducts;
        public MainForm main;
        public Pattern pattern;
        public Models.Menu menuInFile;

        public MenusForm(MainForm main)
        {
            this.main = main;
            WordWorker = new WordWorker(Application.StartupPath + "\\Document Templates\\Меню.docx");
            InitializeComponent();
            InitializeListBoxes();
        }

        private void MenusForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
        }

        public void ReloadedMenus()
        {
            lBMenus.Items.Clear();
            foreach (var item in MainForm.DB.Menus.GetAll())
            {
                lBMenus.Items.Add(item);
            }
        }

        void InitializeListBoxes()
        {
            Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\patterns.pat", FileMode.Open);
            List<Pattern> patterns = new BinaryFormatter().Deserialize(stream) as List<Pattern>;
            cBPattern.Items.Clear();
            Pattern patternNull = new Pattern()
            {
                Name = "Не выбран"
            };
            cBPattern.Items.Add(patternNull);
            foreach (Pattern pattern in patterns)
            {
                cBPattern.Items.Add(pattern);
            }
            cBPattern.SelectedIndex = 0;
            stream.Close();
            cBProductB.Items.Clear();
            lBMenus.Items.Clear();
            dGVProducts.Rows.Clear();
            cLBO.Items.Clear();
            cLBP.Items.Clear();
            cLBZ.Items.Clear();
            cBProductB.Items.Add(new ProductDTO { Id = -1, Name = "Не выбран" });
            foreach (var item in MainForm.DB.Products.GetAll())
            {
                cBProductB.Items.Add(item);
            }
            foreach (var item in MainForm.DB.Menus.GetAll())
            {
                lBMenus.Items.Add(item);
            }
            foreach (var item in MainForm.DB.Dishes.GetAll())
            {
                cLBZ.Items.Add(item);
                cLBO.Items.Add(item);
                cLBP.Items.Add(item);
            }
            cBProductB.SelectedIndex = 0;
        }

        public void ReloadedData(bool checkValidate)
        {
            dGVProducts.Rows.Clear();
            string namesInvalidRows = "";
            foreach (var item in addedProducts)
            {
                float balance = MainForm.DB.Products.Get(item.Id).Balance;
                double summ = item.TotalOfKids;

                dGVProducts.Rows.Add(new object[] {
                    item.Name,
                    balance.ToString(),
                    item.SumNorms.ToString(),
                    summ.ToString(),
                    item.Price.ToString(),
                    Math.Round(item.TotalOfKids * item.Price, 2).ToString()
                });
                dGVProducts.Rows[dGVProducts.RowCount - 1].Tag = item;
                if (checkValidate && summ > Math.Round(balance,2))
                {
                    namesInvalidRows = namesInvalidRows + ("\n" + item.Name);
                    dGVProducts.Rows[dGVProducts.RowCount - 1].DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            }
            if (checkValidate && namesInvalidRows.Length > 0)
            {
                MessageBox.Show("Следующих продуктов на складе меньше, чем запрашивается!" + namesInvalidRows + "\n Уменьшите расход и повторите попытку.", "Слишком большой расход продуктов", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void ButAddMenu_Click(object sender, EventArgs e)
        {
            if (butAddMenu.Text == "Добавить новое меню")
            {
                pMenus.Enabled = false;
                pDishes.Enabled = true;
                pInfo.Enabled = false;
                pProducts.Enabled = false;
                butBuild.Enabled = false;
                butOpen.Enabled = false;
                butDel.Enabled = false;
                butAddMenu.BackColor = Color.Blue;
                butAddMenu.Text = "Отменить добавление";
                lMenu.Text = "Новое меню-требование";
                menu = new MenuDTO();
                addedProducts = new List<ProductInMenu>();
                InitializeListBoxes();
            }
            else
            {
                pMenus.Enabled = true;
                pProducts.Enabled = false;
                pDishes.Enabled = false;
                pInfo.Enabled = false;
                butSave.Enabled = false;
                butBuild.Enabled = true;
                butOpen.Enabled = true;
                butDel.Enabled = true;
                butDirectory.Enabled = true;
                dGVProducts.Rows.Clear();
                butAddMenu.BackColor = Color.LimeGreen;
                butAddMenu.Text = "Добавить новое меню";
                if ((lBMenus.SelectedItem) != null)
                    lMenu.Text = (lBMenus.SelectedItem).ToString();
                else lMenu.Text = "Не выбрана";
            }

        }

        private void CLBZ_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int checkCount = int.Parse(lZ.Text);
            CheckedListBox clb = (CheckedListBox)sender;
            clb.ItemCheck -= CLBZ_ItemCheck;
            clb.SetItemCheckState(e.Index, e.NewValue);
            clb.ItemCheck += CLBZ_ItemCheck;
            lZ.Text = cLBZ.CheckedItems.Count.ToString();
            if (checkCount < int.Parse(lZ.Text))
            {
                cLBP.Items.Remove(cLBZ.Items[e.Index]);
                cLBO.Items.Remove(cLBZ.Items[e.Index]);
            }
            else
            {
                cLBP.Items.Add(cLBZ.Items[e.Index]);
                cLBO.Items.Add(cLBZ.Items[e.Index]);
            }
        }

        private void CLBO_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int checkCount = int.Parse(lO.Text);
            CheckedListBox clb = (CheckedListBox)sender;
            clb.ItemCheck -= CLBO_ItemCheck;
            clb.SetItemCheckState(e.Index, e.NewValue);
            clb.ItemCheck += CLBO_ItemCheck;
            lO.Text = cLBO.CheckedItems.Count.ToString();
            if (checkCount < int.Parse(lO.Text))
            {
                cLBZ.Items.Remove(cLBO.Items[e.Index]);
                cLBP.Items.Remove(cLBO.Items[e.Index]);
            }
            else
            {
                cLBZ.Items.Add(cLBO.Items[e.Index]);
                cLBP.Items.Add(cLBO.Items[e.Index]);
            }
        }

        private void CLBP_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int checkCount = int.Parse(lP.Text);
            CheckedListBox clb = (CheckedListBox)sender;
            clb.ItemCheck -= CLBP_ItemCheck;
            clb.SetItemCheckState(e.Index, e.NewValue);
            clb.ItemCheck += CLBP_ItemCheck;
            lP.Text = cLBP.CheckedItems.Count.ToString();
            if (checkCount < int.Parse(lP.Text))
            {
                cLBZ.Items.Remove(cLBP.Items[e.Index]);
                cLBO.Items.Remove(cLBP.Items[e.Index]);
            }
            else
            {
                cLBZ.Items.Add(cLBP.Items[e.Index]);
                cLBO.Items.Add(cLBP.Items[e.Index]);
            }
        }

        void AddProducts(CheckedListBox.CheckedItemCollection collection, bool checkValidate)
        {
            foreach (object item in collection)
            {
                var list = MainForm.DB.ProductDishes.GetAll().Where(x => x.DishId == (item as DishDTO).Id);
                foreach (ProductDishDTO productDish in list)
                {
                    bool B = false;
                    ProductDTO product = MainForm.DB.Products.Get(productDish.ProductId);
                    if (product.Id == (cBProductB.SelectedItem as ProductDTO).Id)
                        B = true;
                    if (addedProducts.Where(x => x.Id == product.Id).Count() == 0)
                    {
                        addedProducts.Add(new ProductInMenu(
                            product.Id,
                            product.Name,
                            product.GetPrice(),
                            productDish.DishId,
                            productDish.Norm,
                            int.Parse(tBKids.Text),
                            int.Parse(tBKidsB.Text),
                            B
                            ));
                    }
                    else
                    {
                        if (!B)
                        {
                            addedProducts.Single(x => x.Id == product.Id).AddNorm(productDish.DishId, productDish.Norm);
                            addedProducts.Single(x => x.Id == product.Id).SetNewTotalOfKids((int.Parse(tBKids.Text) + int.Parse(tBKidsB.Text)));
                        }
                    }
                }
            }
            ReloadedData(checkValidate);
        }

        private void DGVProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && addedProducts != null)
            {
                string temp = "";
                if (dGVProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("."))
                {
                    temp = dGVProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    temp = temp.Replace(".", ",");
                }
                else
                {
                    temp = dGVProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                ProductDTO prod = MainForm.DB.Products.Get((dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id);
                double norm = double.Parse(temp);
                addedProducts.Single(x => x.Id == (dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id).SumNorms = Math.Round(norm, 3);
                if ((dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id != (cBProductB.SelectedItem as ProductDTO).Id)
                {
                    addedProducts.Single(x => x.Id == (dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id).TotalOfKids = Math.Round(norm * (int.Parse(tBKids.Text) + int.Parse(tBKidsB.Text)), 2);
                }
                else
                {
                    addedProducts.Single(x => x.Id == (dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id).TotalOfKids = Math.Round(norm * int.Parse(tBKidsB.Text), 2);
                }
                ReloadedData(true);
            }
            if (e.ColumnIndex == 3 && addedProducts != null)
            {
                string temp = "";
                if (dGVProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("."))
                {
                    temp = dGVProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    temp = temp.Replace(".", ",");
                }
                else
                {
                    temp = dGVProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                ProductDTO prod = MainForm.DB.Products.Get((dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id);
                double norm = double.Parse(temp);

                addedProducts.Single(x => x.Id == (dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id).TotalOfKids = Math.Round(norm, 2);
                if ((dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id != (cBProductB.SelectedItem as ProductDTO).Id)
                {
                    addedProducts.Single(x => x.Id == (dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id).SumNorms = Math.Round(norm / (int.Parse(tBKids.Text) + int.Parse(tBKidsB.Text)), 3);
                }
                else
                {
                    addedProducts.Single(x => x.Id == (dGVProducts.Rows[e.RowIndex].Tag as ProductInMenu).Id).SumNorms = Math.Round(norm / int.Parse(tBKidsB.Text), 3);
                }
                ReloadedData(true);

            }
        }

        private void ButAddDishes_Click(object sender, EventArgs e)
        {
            if (int.Parse(lZ.Text) + int.Parse(lO.Text) + int.Parse(lP.Text) != 0)
            {
                pInfo.Enabled = true;
                dGVProducts.Rows.Clear();
                pDishes.Enabled = false;
            }
            else
            {
                MessageBox.Show("Невозможно создать меню без блюд!", "Ошибка");
            }
        }

        private void ButSaveSetting_Click(object sender, EventArgs e)
        {
            if (int.Parse(tBKids.Text) + int.Parse(tBKidsB.Text) > 0 && cBProductB.SelectedItem != null)
            {
                pProducts.Enabled = true;
                addedProducts = new List<ProductInMenu>();
                AddProducts(cLBZ.CheckedItems, false);
                AddProducts(cLBO.CheckedItems, false);
                AddProducts(cLBP.CheckedItems, false);
                ReloadedData(true);

                butSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("Укажите количество детей и выберите бюджетный продукт", "Ошибка");
            }
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (MainForm.DB.Menus.GetAll().Where(x => x.Date.ToLongDateString() == dTPDate.Value.ToLongDateString()).Count() > 0)
            {
                MessageBox.Show("Уже существует", "Меню на данную дату уже существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (checkValidateMenu())
                {
                    menu = new MenuDTO
                    {
                        Date = dTPDate.Value,
                        Kids = int.Parse(tBKids.Text),
                        KidsB = int.Parse(tBKidsB.Text),
                        Klad = tBKlad.Text,
                        Povar = tBPovar.Text,
                        Rukowoditel = tBRukov.Text,
                        Vrach = tBVrach.Text,
                        ProductBId = (cBProductB.SelectedItem as ProductDTO).Id,
                        FileName = "\\Меню на " + dTPDate.Value.ToLongDateString() + ".menu"
                    };
                    MainForm.DB.Menus.Create(menu);
                    foreach (ProductInMenu productInMenu in addedProducts)
                    {
                        ProductDTO productInDb = MainForm.DB.Products.Get(productInMenu.Id);
                        float tempPrice = productInDb.GetPrice();
                        productInDb.Balance = (float)Math.Round(productInDb.Balance - (float)productInMenu.TotalOfKids, 2);
                        productInDb.Sum = (float)Math.Round(productInDb.Balance * tempPrice, 2);
                        MainForm.DB.Products.Update(productInDb);
                    }
                    MainForm.DB.Save();
                    Models.Menu menuInFile = new Models.Menu();
                    menuInFile.Products = addedProducts;
                    foreach (object item in cLBZ.CheckedItems)
                    {
                        menuInFile.DishesZ.Add(MainForm.DB.Dishes.Get((item as DishDTO).Id));
                    }
                    foreach (object item in cLBO.CheckedItems)
                    {
                        menuInFile.DishesO.Add(MainForm.DB.Dishes.Get((item as DishDTO).Id));
                    }
                    foreach (object item in cLBP.CheckedItems)
                    {
                        menuInFile.DishesP.Add(MainForm.DB.Dishes.Get((item as DishDTO).Id));
                    }
                    string path = Application.StartupPath + "\\Local Data\\";
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (!dirInfo.Exists)
                    {
                        dirInfo.Create();
                    }
                    if (Directory.Exists(path))
                    {
                        Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\Меню на " + dTPDate.Value.ToLongDateString() + ".menu", FileMode.Create);
                        var serializer = new BinaryFormatter();
                        serializer.Serialize(stream, menuInFile);
                        stream.Close();
                    }
                    MessageBox.Show("Меню успешно сохранено и продукты списаны со склада");
                    ButAddMenu_Click(this, new EventArgs());
                    ReloadedMenus();
                }
                else
                {
                    return;
                }
            }
        }

        private bool checkValidateMenu()
        {
            foreach (ProductInMenu productInMenu in addedProducts)
            {
                ProductDTO productInDb = MainForm.DB.Products.Get(productInMenu.Id);
                if (Math.Round(productInDb.Balance, 2) < productInMenu.TotalOfKids)
                {
                    MessageBox.Show("Меню не может быть созданно, так как вы запрашиваете больше продуктов, чем есть на складе!", "Невозможно создать меню", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void DGVProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double summ = 0;
            double summB = 0;

            foreach (ProductInMenu productInMenu in addedProducts)
            {
                if (productInMenu.Id != (cBProductB.SelectedItem as ProductDTO).Id)
                    summ += Math.Round((productInMenu.TotalOfKids * productInMenu.Price), 2);
                else
                    summB += Math.Round((productInMenu.TotalOfKids * productInMenu.Price), 2);
            }
            lSumm.Text = summ.ToString();
            lSummB.Text = summB.ToString();
        }

        private void DGVProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double summ = 0;
            double summB = 0;

            foreach (ProductInMenu productInMenu in addedProducts)
            {
                if (productInMenu.Id != (cBProductB.SelectedItem as ProductDTO).Id)
                    summ += Math.Round((productInMenu.TotalOfKids * productInMenu.Price), 2);
                else
                    summB += Math.Round((productInMenu.TotalOfKids * productInMenu.Price), 2);
            }
            lSumm.Text = summ.ToString();
            lSummB.Text = summB.ToString();
        }

        private void LBMenus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lBMenus.SelectedItem != null)
            {
                pCheckDoc.Visible = true;
                if (File.Exists(MainForm.DataPath + "\\Документы\\Меню\\Меню на " + (lBMenus.SelectedItem as MenuDTO).Date.ToLongDateString() + ".docx"))
                {
                    lCheckDoc.Text = "Документ сформирован";
                }
                else
                {
                    lCheckDoc.Text = "Документ отсутствует";
                }
                butOpen.Enabled = true;
                butDirectory.Enabled = true;
                butDel.Enabled = true;
                butBuild.Enabled = true;
                pProducts.Enabled = true;
                dGVProducts.Enabled = true;
                lMenu.Text = lBMenus.Text;
                tBKids.Text = (lBMenus.SelectedItem as MenuDTO).Kids.ToString();
                tBKidsB.Text = (lBMenus.SelectedItem as MenuDTO).KidsB.ToString();
                tBKlad.Text = (lBMenus.SelectedItem as MenuDTO).Klad;
                tBPovar.Text = (lBMenus.SelectedItem as MenuDTO).Povar;
                tBRukov.Text = (lBMenus.SelectedItem as MenuDTO).Rukowoditel;
                tBVrach.Text = (lBMenus.SelectedItem as MenuDTO).Vrach;
                dTPDate.Value = (lBMenus.SelectedItem as MenuDTO).Date;
                foreach (var item in cBProductB.Items)
                {
                    if ((item as ProductDTO).Id == (lBMenus.SelectedItem as MenuDTO).ProductBId)
                    {
                        cBProductB.SelectedItem = item;
                    }
                }
                dGVProducts.Rows.Clear();
                Stream stream = new FileStream(Application.StartupPath + "\\Local Data\\Меню на " + dTPDate.Value.ToLongDateString() + ".menu", FileMode.Open);
                menuInFile = new BinaryFormatter().Deserialize(stream) as Models.Menu;
                addedProducts = menuInFile.Products;
                cLBZ.Items.Clear();
                foreach (var item in menuInFile.DishesZ)
                {
                    cLBZ.Items.Add(item);
                }
                cLBO.Items.Clear();
                foreach (var item in menuInFile.DishesO)
                {
                    cLBO.Items.Add(item);
                }
                cLBP.Items.Clear();
                foreach (var item in menuInFile.DishesP)
                {
                    cLBP.Items.Add(item);
                }

                stream.Close();
                ReloadedData(false);
            }
            else
            {
                pCheckDoc.Visible = false;
            }
        }

        private void ButBuild_Click(object sender, EventArgs e)
        {
            if (lBMenus.SelectedItem != null)
            {
                BuildDocument();
            }
        }

        private void BuildDocument()
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                WordWorker.Load();
                ReplaceStrings();
                Word.Range range = WordWorker.doc.Paragraphs[WordWorker.doc.Paragraphs.Count].Range;
                int i = 4;
                int y = 3;
                Dictionary<int, int> productsId = new Dictionary<int, int>();
                foreach (DishDTO dishZ in menuInFile.DishesZ)
                {
                    WordWorker.doc.Tables[1].Cell(i, 2).Range.Text = dishZ.Name;
                    foreach (ProductDishDTO productDish in MainForm.DB.ProductDishes.GetAll().Where(x => x.DishId == dishZ.Id))
                    {
                        if (!productsId.Keys.Contains(productDish.ProductId))
                        {
                            productsId.Add(productDish.ProductId, y);
                            WordWorker.doc.Tables[1].Cell(2, y - 1).Range.Text = MainForm.DB.Products.Get(productDish.ProductId).PsevdoName;
                            WordWorker.doc.Tables[1].Cell(i, y).Range.Text = productDish.Norm.ToString();
                            y++;
                        }
                        else
                        {
                            int s;
                            productsId.TryGetValue(productDish.ProductId, out s);
                            WordWorker.doc.Tables[1].Cell(i, s).Range.Text = productDish.Norm.ToString();
                        }
                    }
                    i++;
                }
                i = 9;
                foreach (DishDTO dishO in menuInFile.DishesO)
                {
                    WordWorker.doc.Tables[1].Cell(i, 2).Range.Text = dishO.Name;
                    foreach (ProductDishDTO productDish in MainForm.DB.ProductDishes.GetAll().Where(x => x.DishId == dishO.Id))
                    {
                        if (!productsId.Keys.Contains(productDish.ProductId))
                        {
                            productsId.Add(productDish.ProductId, y);
                            WordWorker.doc.Tables[1].Cell(2, y - 1).Range.Text = MainForm.DB.Products.Get(productDish.ProductId).PsevdoName;
                            WordWorker.doc.Tables[1].Cell(i, y).Range.Text = productDish.Norm.ToString();
                            y++;
                        }
                        else
                        {
                            int s;
                            productsId.TryGetValue(productDish.ProductId, out s);
                            WordWorker.doc.Tables[1].Cell(i, s).Range.Text = productDish.Norm.ToString();
                        }
                    }
                    i++;
                }
                i = 15;
                foreach (DishDTO dishP in menuInFile.DishesP)
                {
                    WordWorker.doc.Tables[1].Cell(i, 2).Range.Text = dishP.Name;
                    foreach (ProductDishDTO productDish in MainForm.DB.ProductDishes.GetAll().Where(x => x.DishId == dishP.Id))
                    {
                        if (!productsId.Keys.Contains(productDish.ProductId))
                        {
                            productsId.Add(productDish.ProductId, y);
                            WordWorker.doc.Tables[1].Cell(2, y - 1).Range.Text = MainForm.DB.Products.Get(productDish.ProductId).PsevdoName;
                            WordWorker.doc.Tables[1].Cell(i, y).Range.Text = productDish.Norm.ToString();
                            y++;
                        }
                        else
                        {
                            int s;
                            productsId.TryGetValue(productDish.ProductId, out s);
                            WordWorker.doc.Tables[1].Cell(i, s).Range.Text = productDish.Norm.ToString();
                        }
                    }
                    i++;
                }
                foreach (ProductInMenu product in menuInFile.Products)
                {
                    int s;
                    productsId.TryGetValue(product.Id, out s);
                    WordWorker.doc.Tables[1].Cell(20, s - 1).Range.Text = Math.Round(product.SumNorms, 2).ToString();
                    WordWorker.doc.Tables[1].Cell(21, s - 1).Range.Text = Math.Round(product.TotalOfKids, 2).ToString();
                    WordWorker.doc.Tables[1].Cell(22, s - 1).Range.Text = Math.Round(product.Price, 2).ToString();
                    if (product.Id != (cBProductB.SelectedItem as ProductDTO).Id)
                    {
                        WordWorker.doc.Tables[1].Cell(23, s).Range.Text = Math.Round(product.TotalOfKids * product.Price, 2).ToString();
                    }
                    else
                    {
                        WordWorker.doc.Tables[1].Cell(24, s).Range.Text = Math.Round(product.TotalOfKids * product.Price, 2).ToString();
                    }
                }
                WordWorker.doc.Tables[1].Cell(23, 2).Range.Text = Math.Round(float.Parse(lSumm.Text), 2).ToString();
                WordWorker.doc.Tables[1].Cell(24, 2).Range.Text = Math.Round(float.Parse(lSummB.Text), 2).ToString();

                WordWorker.Save(MainForm.DataPath + "\\Документы\\Меню\\Меню на " + dTPDate.Value.ToLongDateString() + ".docx");
                WordWorker.Close();
                lLoad.Visible = false;
            }
            WordWorker.Close();
        }

        void ReplaceStrings()
        {
            WordWorker.FindReplace("{vrachName}", tBVrach.Text);
            WordWorker.FindReplace("{kladName}", tBKlad.Text);
            WordWorker.FindReplace("{otdelenie}", tBOtdelenie.Text);
            WordWorker.FindReplace("{uchregdenie}", tBUchregdenie.Text);
            WordWorker.FindReplace("{povarName}", tBPovar.Text);
            WordWorker.FindReplace("{rukovoditelName}", tBRukov.Text);
            WordWorker.FindReplace("{date}", dTPDate.Value.ToShortDateString());
            WordWorker.FindReplace("{kids}", (int.Parse(tBKids.Text) + int.Parse(tBKidsB.Text)).ToString());
            WordWorker.FindReplace("{total}", (float.Parse(lSumm.Text) + float.Parse(lSummB.Text)).ToString());
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            if (lBMenus.SelectedItem != null)
            {
                var menu = MainForm.DB.Menus.Get((lBMenus.SelectedItem as MenuDTO).Id);
                if (MessageBox.Show("Списанные в данном меню продукты будут возвращеы на склад! Вы уверены что хотите удалить меню на " + menu.Date.ToLongDateString() + " ?", "Внимание! Удаление меню", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string path = Application.StartupPath + "\\Local Data\\Меню на " + menu.Date.ToLongDateString() + ".menu";
                    File.Delete(path);
                }
                foreach (ProductInMenu product in addedProducts)
                {
                    ProductDTO productInDb = MainForm.DB.Products.Get(product.Id);
                    float tempPrice = productInDb.Sum / productInDb.Balance;
                    productInDb.Balance = (float)Math.Round((productInDb.Balance + product.TotalOfKids), 2);
                    productInDb.Sum = (float)Math.Round(productInDb.Balance * tempPrice, 2);
                    MainForm.DB.Products.Update(productInDb);
                    MainForm.DB.Save();
                }
                MainForm.DB.Menus.Delete(menu.Id);
                MainForm.DB.Save();
                ReloadedMenus();
            }
        }

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            string pathDir = MainForm.DataPath + "\\Документы\\Меню\\";
            Process Proc = new Process();
            Proc.StartInfo.FileName = "explorer";
            Proc.StartInfo.Arguments = pathDir;
            Proc.Start();
        }

        public void OpenDocument(string fileName)
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                WordWorker.Open(fileName);
            }
            lLoad.Visible = false;
        }

        private void ButOpen_Click(object sender, EventArgs e)
        {
            if (lBMenus.SelectedItem != null)
                OpenDocument(MainForm.DataPath + "\\Документы\\Меню\\Меню на " + (lBMenus.SelectedItem as MenuDTO).Date.ToLongDateString() + ".docx");
        }

        private void CBPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            cLBZ.Items.Clear();
            cLBO.Items.Clear();
            cLBP.Items.Clear();
            if (cBPattern.SelectedItem != null && !((cBPattern.SelectedItem as Pattern).Name).Equals("Не выбран"))
            {
                pattern = (cBPattern.SelectedItem as Pattern);
                cLBZ.Items.Clear();
                cLBO.Items.Clear();
                cLBP.Items.Clear();
                foreach (var item in pattern.DishesZ)
                {
                    cLBZ.Items.Add(item, true);
                }
                lZ.Text = pattern.DishesZ.Count().ToString();
                foreach (var item in pattern.DishesO)
                {
                    cLBO.Items.Add(item, true);
                }
                lO.Text = pattern.DishesO.Count().ToString();
                foreach (var item in pattern.DishesP)
                {
                    cLBP.Items.Add(item, true);
                }
                lP.Text = pattern.DishesP.Count().ToString();
            }
            else
            {
                foreach (DishDTO item in MainForm.DB.Dishes.GetAll())
                {
                    cLBZ.Items.Add(item);
                    cLBO.Items.Add(item);
                    cLBP.Items.Add(item);
                    lZ.Text = "0";
                    lO.Text = "0";
                    lP.Text = "0";
                }
            }
        }
    }
}
