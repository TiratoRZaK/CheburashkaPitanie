using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;
using Дет.Сад.Питание.Services;

namespace Дет.Сад.Питание.Forms
{
    public partial class AddEditDishForm : Form
    {
        public Dictionary<string, float> norms = new Dictionary<string, float>();
        public DishesForm main;
        public DishDTO _Dish = null;
        public ObservableCollection<ProductDTO> products = new ObservableCollection<ProductDTO>();

        public AddEditDishForm(DishesForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeListBoxes();
        }

        public AddEditDishForm(DishDTO dish, DishesForm main)
        {
            this.main = main;
            _Dish = dish;
            InitializeComponent();
            InitializeTextBoxes();
            InitializeListBoxes();
        }

        void InitializeTextBoxes()
        {
            tBName.Text = _Dish.Name.ToString();
            tBNorm.Text = _Dish.Norm.ToString();
            tBFat.Text = _Dish.Fat.ToString();
            tBCarbo.Text = _Dish.Carbohydrate.ToString();
            tBProtein.Text = _Dish.Protein.ToString();
            tBVitamine.Text = _Dish.Vitamine_C.ToString();
            butDelete.Visible = true;
        }

        void InitializeListBoxes()
        {
            products.Clear();
            ReloadData();
            if (_Dish != null)
            {                
                var prodDishes = MainForm.DB.ProductDishes.GetAll().Where(x => x.DishId == _Dish.Id).ToList();
                foreach(var item in prodDishes)
                {
                    norms.Add(MainForm.DB.Products.Get(item.ProductId).Name, item.Norm);
                    products.Add(MainForm.DB.Products.Get(item.ProductId));
                }
                ReloadeData();
            }
        }

        void ReloadeData()
        {
            lBSostav.Items.Clear();
            foreach(var item in products)
            {
                lBSostav.Items.Add(item);
            }
        }

        void ShowError(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
            timError.Start();
        }

        private void TimError_Tick(object sender, EventArgs e)
        {
            timError.Stop();
            labelError.Visible = false;
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (tBName.Text == "" || tBNorm.Text == "")
            {
                ShowError("Не все обязательные поля заполнены!");
            }
            else
            {
                if (lBSostav.Items.Count == 0)
                {
                    ShowError("Состав не может быть пустым!");
                }
                else
                {
                    if (_Dish == null)
                    {
                        DishDTO dish = new DishDTO();
                        dish.Name = tBName.Text.ToString();
                        dish.Norm = float.Parse(tBNorm.Text);
                        if (tBCarbo.Text != "")
                        {
                            dish.Carbohydrate = int.Parse(tBCarbo.Text);
                        }
                        if (tBProtein.Text != "")
                        {
                            dish.Protein = int.Parse(tBProtein.Text);
                        }
                        if (tBFat.Text != "")
                        {
                            dish.Fat = int.Parse(tBFat.Text);
                        }
                        if (tBVitamine.Text != "")
                        {
                            dish.Vitamine_C = int.Parse(tBVitamine.Text);
                        }
                        MainForm.DB.Dishes.Create(dish);
                        MainForm.DB.Save();
                        List<ActionDescription> actions = new List<ActionDescription>();
                        actions.Add(new ActionDescription("Характеристики блюда: " + dish.Name, "Норма = " + dish.Norm.ToString(), "Углеводы: " + dish.Carbohydrate.ToString(), "Жиры: " + dish.Fat.ToString(), "Белки: "+dish.Protein.ToString(), "Витамин С: "+dish.Vitamine_C.ToString()));

                        DishDTO dishNew = MainForm.DB.Dishes.GetAll().Last();
                        foreach (var item in products)
                        {
                            float temp;
                            norms.TryGetValue(item.Name, out temp);
                            MainForm.DB.ProductDishes.Create(new ProductDishDTO
                            {
                                Dish = dishNew,
                                DishId = dishNew.Id,
                                Product = item,
                                ProductId = item.Id,
                                Norm = temp
                            });
                            MainForm.DB.Save();
                            actions.Add(new ActionDescription("Добавление продукта " + item.Name, "Норма = " + temp.ToString()));
                        }
                        LoggingService.AddLog("Добавление нового блюда: "+dish.ToString(), actions.ToArray());
                    }
                    else
                    {
                        DishDTO dish = MainForm.DB.Dishes.Get(_Dish.Id);
                        dish.Name = tBName.Text.ToString();
                        dish.Norm = float.Parse(tBNorm.Text);
                        if (tBCarbo.Text != "")
                        {
                            dish.Carbohydrate = int.Parse(tBCarbo.Text);
                        }
                        if (tBProtein.Text != "")
                        {
                            dish.Protein = int.Parse(tBProtein.Text);
                        }
                        if (tBFat.Text != "")
                        {
                            dish.Fat = int.Parse(tBFat.Text);
                        }
                        if (tBVitamine.Text != "")
                        {
                            dish.Vitamine_C = int.Parse(tBVitamine.Text);
                        }

                        var list = MainForm.DB.ProductDishes.GetAll().Where(x => x.DishId == _Dish.Id);
                        foreach(var item in list)
                        {
                            MainForm.DB.ProductDishes.Delete(item.Id);
                        }
                        MainForm.DB.Save();
                        List<ActionDescription> actions = new List<ActionDescription>();
                        actions.Add(new ActionDescription("Характеристики блюда: " + dish.Name, "Норма = " + dish.Norm.ToString(), "Углеводы: " + dish.Carbohydrate.ToString(), "Жиры: " + dish.Fat.ToString(), "Белки: " + dish.Protein.ToString(), "Витамин С: " + dish.Vitamine_C.ToString()));

                        foreach (var item in products)
                        {
                            float temp;
                            norms.TryGetValue(item.Name, out temp);
                            MainForm.DB.ProductDishes.Create(new ProductDishDTO
                            {
                                Dish = dish,
                                DishId = dish.Id,
                                Product = item,
                                ProductId = item.Id,
                                Norm = temp
                            });
                            MainForm.DB.Save();
                            actions.Add(new ActionDescription("Добавление продукта " + item.Name, "Норма = " + temp.ToString()));
                        }
                        LoggingService.AddLog("Изменение блюда: " + dish.ToString(), actions.ToArray());
                    }
                    MainForm.DB.Save();
                    MessageBox.Show("Блюдо успешно сохранено");
                    this.Close();
                    main.ReloadData();
                }
            }
        }

        private void ButDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить блюдо " + _Dish.Name + " ?", "Удаление блюда", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MainForm.DB.Dishes.Delete(_Dish.Id);
                MainForm.DB.Save();
                LoggingService.AddLog("Удаление блюда: " + _Dish.ToString());
                MessageBox.Show("Блюдо успешно удалено");
                this.Close();
                main.ReloadData();
            }
        }

        private void TBNorm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != ',' && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void ButPlus_Click(object sender, EventArgs e)
        {
            if(lBProducts.SelectedItem != null && !lBSostav.Items.Contains(lBProducts.SelectedItem))
            {
                SetNorm set = new SetNorm(this, ((ProductDTO)lBProducts.SelectedItem).Name);
                set.ShowDialog();
                products.Add((ProductDTO)lBProducts.SelectedItem);
                
                ReloadeData();
            }
        }

        private void ButMin_Click(object sender, EventArgs e)
        {
            if(lBSostav.SelectedItem != null)
            {
                norms.Remove(((ProductDTO)lBSostav.SelectedItem).Name);
                products.Remove((ProductDTO)lBSostav.SelectedItem);
                ReloadeData();
            }
        }

        private void TBSearch_TextChanged(object sender, EventArgs e)
        {
            ReloadData();

        }

        public void ReloadData()
        {
            if (tBSearch.Text.Trim().Length > 0)
            {
                //search data
                PopulateData(MainForm.DB.Products.GetAll().Where(x => x.Name.ToLower().Contains(tBSearch.Text.ToLower())));
            }
            else
            {
                PopulateData(MainForm.DB.Products.GetAll());
            }
        }

        private void PopulateData(IEnumerable<ProductDTO> products)
        {
            lBProducts.Items.Clear();
            foreach (var item in products)
            {
                lBProducts.Items.Add(item);
            }
        }

        private void lBSostav_SelectedIndexChanged(object sender, EventArgs e)
        {
            float norm;
            norms.TryGetValue(lBSostav.Text, out norm); 
            tTListBoxSostav.SetToolTip(lBSostav, norm.ToString());
        }
    }
}