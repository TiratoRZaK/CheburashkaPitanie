using DAL.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class AddEditProductForm : Form
    {
        public ProductDTO _Product = null;
        public ProductsForm main;

        public AddEditProductForm(ProductsForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeComdoBoxes();
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
        }

        void InitializeTextBoxes()
        {
            tBName.Text = _Product.Name.ToString();
            tBPsevdoName.Text = _Product.Name.ToString();
            tBNorm.Text = _Product.Norm.ToString();
            tBBalance.Text = _Product.Balance.ToString();
            tBPrice.Text = _Product.Price.ToString();
            tBFat.Text = _Product.Fat.ToString();
            tBCarbo.Text = _Product.Carbohydrate.ToString();
            tBProtein.Text = _Product.Protein.ToString();
            tBVitamine.Text = _Product.Vitamine_C.ToString();
        }
        void InitializeComdoBoxes()
        {
            cBType.DataSource = MainForm.DB.Types.GetAll();
            cBType.SelectedItem = MainForm.DB.Types.GetAll().First();
            cBUnit.DataSource = MainForm.DB.Units.GetAll();
            cBUnit.SelectedItem = MainForm.DB.Units.GetAll().First();
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
                    if (tBPrice.Text != "")
                    {
                        product.Price = float.Parse(tBPrice.Text);
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

                    //validation
                    MainForm.DB.Products.Create(product);
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
                    if (tBPrice.Text != "")
                    {
                        product.Price = float.Parse(tBPrice.Text);
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
                    //validation
                    MainForm.DB.Products.Update(product);
                }
                MainForm.DB.Save();
                MessageBox.Show("Продукт успешно сохранён");
                this.Close();
                main.ReloadData();
            }
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить продукт "+_Product.Name+" ?","Удаление продукта",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MainForm.DB.Products.Delete(_Product.Id);
                MessageBox.Show("Продукт успешно удалён");
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
