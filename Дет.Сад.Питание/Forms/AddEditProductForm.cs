using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;
using Дет.Сад.Питание.Services;

namespace Дет.Сад.Питание.Forms
{
    public partial class AddEditProductForm : Form
    {
        private ProductDTO _Product = null;
        private ProductsForm main;
        private List<ActionDescription> actions = new List<ActionDescription>();
        private StringBuilder logMessage;

        public AddEditProductForm(ProductsForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeComdoBoxes();
            logMessage = new StringBuilder("Добавление нового продукта: ");
        }
        public AddEditProductForm(ProductDTO product, ProductsForm main)
        {
            this.main = main;
            _Product = product;
            InitializeComponent();
            InitializeComdoBoxes();
            InitializeTextBoxes();
            butSave.Text = "Обновить продукт";
            this.Text = "Обновление продукта " + product.Name;
            butDel.Visible = true;
            logMessage = new StringBuilder("Изменение продукта: ");
        }

        void InitializeTextBoxes()
        {
            tBName.Text = _Product.Name.ToString();
            tBPsevdoName.Text = _Product.PsevdoName.ToString();
            tBNorm.Text = _Product.Norm.ToString();
            tBBalance.Text = _Product.Balance.ToString();
            tBSum.Text = _Product.Sum.ToString();
            tBFat.Text = _Product.Fat.ToString();
            tBCarbo.Text = _Product.Carbohydrate.ToString();
            tBProtein.Text = _Product.Protein.ToString();
            tBVitamine.Text = _Product.Vitamine_C.ToString();
        }
        void InitializeComdoBoxes()
        {
            cBType.DataSource = MainForm.DB.Types.GetAll();
            cBUnit.DataSource = MainForm.DB.Units.GetAll();
            if (_Product != null)
            {
                cBType.SelectedItem = _Product.Type;
                cBUnit.SelectedItem = _Product.Unit;
            }
            else
            {
                cBType.SelectedIndex = 0;
                cBUnit.SelectedIndex = 0;
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
            if(tBName.Text == "")
            {
                ShowError("Не все обязательные поля заполнены!");
            }
            else
            {
                if (_Product == null)
                {
                    ProductDTO product = new ProductDTO();
                    product.Name = tBName.Text.ToString();
                    product.PsevdoName = tBPsevdoName.Text.ToString();
                    if (tBNorm.Text != "")
                    {
                        product.Norm = float.Parse(tBNorm.Text);
                    }
                    if (tBSum.Text != "")
                    {
                        product.Sum = float.Parse(tBSum.Text);
                    }
                    if (tBBalance.Text != "")
                    {
                        product.Balance = float.Parse(tBBalance.Text);
                    }
                    if (tBCarbo.Text != "")
                    {
                        product.Carbohydrate = int.Parse(tBCarbo.Text);
                    }
                    if (tBProtein.Text != "")
                    {
                        product.Protein = int.Parse(tBProtein.Text);
                    }
                    if (tBFat.Text != "")
                    {
                        product.Fat = int.Parse(tBFat.Text);
                    }
                    if (tBVitamine.Text != "")
                    {
                        product.Vitamine_C = int.Parse(tBVitamine.Text);
                    }
                    TypeDTO type = MainForm.DB.Types.GetAll().Where(x => x.Name == cBType.SelectedValue.ToString()).First();
                    product.Type = type;
                    product.TypeId = type.Id;
                    UnitDTO unit = MainForm.DB.Units.GetAll().Where(x => x.Name == cBUnit.SelectedValue.ToString()).First();
                    product.Unit = unit;
                    product.UnitId = unit.Id;
                    MainForm.DB.Products.Create(product);
                    actions.Add(new ActionDescription("Характеристики продукта: " + product.Name, "Псевдоним: " + product.PsevdoName, "Ед. изм.: "+product.Unit.Name, "Тип: "+product.Type.Name, "Сумма: " + product.Sum.ToString(), "Количество: " + product.Balance.ToString(), "Норма = " + product.Norm.ToString(), "Углеводы: " + product.Carbohydrate.ToString(), "Жиры: " + product.Fat.ToString(), "Белки: " + product.Protein.ToString(), "Витамин С: " + product.Vitamine_C.ToString()));
                    logMessage.Append(product.Name);
                }
                else
                {
                    ProductDTO product = MainForm.DB.Products.Get(_Product.Id);
                    product.Name = tBName.Text.ToString();
                    product.PsevdoName = tBPsevdoName.Text.ToString();
                    if (tBNorm.Text != "")
                    {
                        product.Norm = float.Parse(tBNorm.Text);
                    }
                    if (tBCarbo.Text != "")
                    {
                        product.Carbohydrate = int.Parse(tBCarbo.Text);
                    }
                    if (tBProtein.Text != "")
                    {
                        product.Protein = int.Parse(tBProtein.Text);
                    }
                    if (tBSum.Text != "")
                    {
                        product.Sum = float.Parse(tBSum.Text);
                    }
                    if (tBBalance.Text != "")
                    {
                        product.Balance = float.Parse(tBBalance.Text);
                    }
                    if (tBFat.Text != "")
                    {
                        product.Fat = int.Parse(tBFat.Text);
                    }
                    if (tBVitamine.Text != "")
                    {
                        product.Vitamine_C = int.Parse(tBVitamine.Text);
                    }
                    TypeDTO type = MainForm.DB.Types.GetAll().Where(x => x.Name == cBType.SelectedValue.ToString()).First();
                    product.Type = type;
                    product.TypeId = type.Id;
                    UnitDTO unit = MainForm.DB.Units.GetAll().Where(x => x.Name == cBUnit.SelectedValue.ToString()).First();
                    product.Unit = unit;
                    product.UnitId = unit.Id;

                    MainForm.DB.Products.Update(product);
                    actions.Add(new ActionDescription("Характеристики продукта: " + product.Name, "Псевдоним: " + product.PsevdoName, "Ед. изм.: " + product.Unit.Name, "Тип: " + product.Type.Name, "Cумма: " + product.Sum.ToString(), "Количество: " + product.Balance.ToString(), "Норма = " + product.Norm.ToString(), "Углеводы: " + product.Carbohydrate.ToString(), "Жиры: " + product.Fat.ToString(), "Белки: " + product.Protein.ToString(), "Витамин С: " + product.Vitamine_C.ToString()));
                    logMessage.Append(product.Name);
                }
                MainForm.DB.Save();
                MessageBox.Show("Продукт успешно сохранён");
                LoggingService.AddLog(logMessage.ToString(), actions.ToArray());
                this.Close();
            }
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить продукт "+_Product.Name+" ?","Удаление продукта",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MainForm.DB.Products.Delete(_Product.Id);
                MainForm.DB.Save();
                MessageBox.Show("Продукт успешно удалён");
                LoggingService.AddLog("Удаление продукта: "+_Product.Name);
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

        private void ButEditPanel_Click(object sender, EventArgs e)
        {
            panBalancePrice.Enabled = true;
        }
    }
}
