using DAL.DTO;
using System;
using System.Linq;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;

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
            tBPrice.Text = _Product.GetPrice().ToString();
            tBUnit.Text = MainForm.DB.Units.Get(_Product.UnitId).Name;

        }
        void InitializeComdoBoxes()
        {
            cBProduct.DataSource = MainForm.DB.Products.GetAll().ToList();
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
                    ProductArrival product = new ProductArrival();
                    product.Id = productInDb.Id;
                    product.Name = productInDb.Name;
                    product.Balance = float.Parse(tBBalance.Text);
                    product.Price = float.Parse(tBPrice.Text);
                    product.TypeId = productInDb.TypeId;
                    product.UnitId = productInDb.UnitId;
                    
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
