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
using Дет.Сад.Питание.Services;

namespace Дет.Сад.Питание.Forms
{
    public partial class MenusForm : Form
    {
        MenuService service = new MenuService();

        public MenuDTO menu = null;
        public List<ProductInMenu> addedProducts;
        public MainForm main;
        public Pattern pattern;
        public Models.Menu menuInFile;

        public MenusForm(MainForm main)
        {
            this.main = main;
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
                if (checkValidate && summ > Math.Round(balance, 2))
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
            if (!service.IsAvailableDate(dTPDate.Value))
            {
                MessageBox.Show("Меню на данную дату уже существует.", "Неверная дата", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (service.CreateMenu(dTPDate.Value, int.Parse(tBKids.Text), int.Parse(tBKidsB.Text), tBKlad.Text, tBPovar.Text, tBRukov.Text, tBVrach.Text, tBOtdelenie.Text, tBUchregdenie.Text, (cBProductB.SelectedItem as ProductDTO).Id, addedProducts, cLBZ.CheckedItems, cLBO.CheckedItems, cLBP.CheckedItems))
                {
                    MessageBox.Show("Меню успешно сохранено и продукты списаны со склада");
                    ButAddMenu_Click(this, new EventArgs());
                    ReloadedMenus();
                }
                else
                {
                    MessageBox.Show("Неудалось создать меню. Данные не корректны.", "Ошибка при создании меню", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            if (lBMenus.SelectedItem != sender as MenuDTO)
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
                    tBOtdelenie.Text = (lBMenus.SelectedItem as MenuDTO).Otdelenie;
                    tBUchregdenie.Text = (lBMenus.SelectedItem as MenuDTO).Uchregdenie;

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
                service.BuildDocument((lBMenus.SelectedItem as MenuDTO).Id);
                lLoad.Visible = false;
            }
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            if (lBMenus.SelectedItem != null)
            {
                if (MessageBox.Show("Списанные в данном меню продукты будут возвращеы на склад! Вы уверены что хотите удалить меню?", "Внимание! Удаление меню", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    service.Delete((lBMenus.SelectedItem as MenuDTO).Id);
                    ReloadedMenus();
                }
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
                service.Open(fileName);
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

        private void lBMenus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = lBMenus.IndexFromPoint(e.X, e.Y);
                if (index != -1)
                {
                    lBMenus.SetSelected(index, true);
                    contextMenu.Show(lBMenus, e.Location);
                }
            }
        }

        private void пересозадатьМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cLBZ.Items.Clear();
            cLBO.Items.Clear();
            cLBP.Items.Clear();
            MenuDTO menu = MainForm.DB.Menus.Get((lBMenus.SelectedItem as MenuDTO).Id);

            ButAddMenu_Click(this, new EventArgs());
            tBKids.Text = menu.Kids.ToString();
            tBKidsB.Text = menu.KidsB.ToString();
            tBKlad.Text = menu.Klad;
            tBPovar.Text = menu.Povar;
            tBRukov.Text = menu.Rukowoditel;
            tBVrach.Text = menu.Vrach;
            dTPDate.Value = menu.Date;
            tBOtdelenie.Text = menu.Otdelenie;
            tBUchregdenie.Text = menu.Uchregdenie;

            foreach (var item in cBProductB.Items)
            {
                if ((item as ProductDTO).Id == menu.ProductBId)
                {
                    cBProductB.SelectedItem = item;
                }
            }

            Stream stream = new FileStream(Application.StartupPath + "//Local Data//" + menu.FileName, FileMode.Open);
            menuInFile = new BinaryFormatter().Deserialize(stream) as Models.Menu;
            addedProducts = menuInFile.Products;
            stream.Close();
            cLBZ.Items.Clear();
            foreach (var item in menuInFile.DishesZ)
            {
                cLBZ.Items.Add(item, true);
            }
            cLBO.Items.Clear();
            foreach (var item in menuInFile.DishesO)
            {
                cLBO.Items.Add(item, true);
            }
            cLBP.Items.Clear();
            foreach (var item in menuInFile.DishesP)
            {
                cLBP.Items.Add(item, true);
            }

            pInfo.Enabled = true;
            pProducts.Enabled = true;
            dGVProducts.Enabled = true;

            foreach (var item in addedProducts)
            {
                dGVProducts.Rows.Add(new object[] {
                    item.Name,
                    MainForm.DB.Products.Get(item.Id).Balance.ToString(),
                    item.SumNorms.ToString(),
                    item.TotalOfKids.ToString(),
                    item.Price.ToString(),
                    Math.Round(item.TotalOfKids * item.Price, 2).ToString()
                });
                dGVProducts.Rows[dGVProducts.RowCount - 1].Tag = item;
            }
            service.Delete(menu.Id);
            ReloadedMenus();
            butSave.Enabled = true;
        }
    }
}
