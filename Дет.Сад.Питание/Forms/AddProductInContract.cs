using DAL.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class AddProductInContract : Form
    {
        public ProductDTO _Product = new ProductDTO();
        public ContractsForm main;

        public AddProductInContract(ContractsForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeComdoBoxes();
        }

        void InitializeToProduct()
        {
            tBBalance.Text = _Product.Balance.ToString();
            tBPrice.Text = _Product.Price.ToString();
            tBUnit.Text = MainForm.DB.Units.Get(_Product.UnitId).Name;

        }
        void InitializeComdoBoxes()
        {
            cBProduct.DataSource = MainForm.DB.Products.GetAll();
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

        private void TBNorm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != ',' && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void CBProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Product = (cBProduct.SelectedItem as ProductDTO);
            InitializeToProduct();
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if ( tBPrice.Text == "" || tBBalance.Text == "")
            {
                ShowError("Не все обязательные поля заполнены!");
            }
            else
            {
                if (main.addedProducts.Where(x => x.Name == (cBProduct.SelectedItem as ProductDTO).Name).Count() == 0)
                {
                    ProductDTO productInDb = MainForm.DB.Products.Get((cBProduct.SelectedItem as ProductDTO).Id);
                    ProductDTO product = new ProductDTO();
                    product.Id = productInDb.Id;
                    product.Name = productInDb.Name;
                    product.Balance = (float)Math.Round(float.Parse(tBBalance.Text), 2);
                    product.Price = (float)Math.Round(float.Parse(tBPrice.Text), 2);
                    product.Carbohydrate = productInDb.Carbohydrate;
                    product.Fat = productInDb.Fat;
                    product.Norm = productInDb.Norm;
                    product.ProductsDishes = productInDb.ProductsDishes;
                    product.Protein = productInDb.Protein;
                    product.Type = productInDb.Type;
                    product.TypeId = productInDb.TypeId;
                    product.Unit = productInDb.Unit;
                    product.UnitId = productInDb.UnitId;
                    product.Vitamine_C = productInDb.Vitamine_C;

                    main.addedProducts.Add(product);
                    MessageBox.Show("Продукт успешно добавлен");
                    this.Close();
                }
                ShowError("Продукт с данным именем уже в списке!");
            }
        }

        private void AddProductInContract_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ReloadedData();
        }
    }
}
