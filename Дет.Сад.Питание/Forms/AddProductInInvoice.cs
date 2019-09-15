using DAL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class AddProductInInvoice : Form
    {
        public ProductDTO _Product = null;
        public InvoicesForm main;
        public List<ProductDTO> addedProducts;

        public AddProductInInvoice(InvoicesForm main, string fileContractPath)
        {
            this.main = main;
            InitializeProducts(fileContractPath);
            InitializeComponent();
            InitializeComdoBoxes();
        }

        private void InitializeProducts(string filePath)
        {
            Stream stream = new FileStream(filePath, FileMode.Open);
            addedProducts = new BinaryFormatter().Deserialize(stream) as List<ProductDTO>;
            stream.Close();
        }

        void InitializeToProduct()
        {
            tBBalance.Text = _Product.Balance.ToString();
        }
        void InitializeComdoBoxes()
        {
            cBProduct.DataSource = addedProducts;
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            if (tBBalance.Text == "")
            {
                ShowError("Не все обязательные поля заполнены!");
            }
            else
            {
                if (main.addedProducts.Where(x => x.Name == (cBProduct.SelectedItem as ProductDTO).Name).Count() == 0)
                {
                    ProductDTO productInDb = addedProducts.Single(x=>x.Id == (cBProduct.SelectedItem as ProductDTO).Id);
                    ProductDTO product = new ProductDTO();
                    product.Id = productInDb.Id;
                    product.Name = productInDb.Name;
                    product.Balance = (float)Math.Round(float.Parse(tBBalance.Text), 2);
                    product.Price = productInDb.Price;
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

        private void ButDel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ShowError(string message)
        {
            labelError.Text = message;
            labelError.Visible = true;
            timError.Start();
        }

        private void CBProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Product = cBProduct.SelectedItem as ProductDTO;
            InitializeToProduct();
        }

        private void TBBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (Char.IsDigit(ch) ||
                (ch == ',' && !tBBalance.Text.Contains(',') && tBBalance.Text.Count() != 0)  ||
                (ch == '\b' && tBBalance.Text.Count() != 0)
                )
            {
                StringBuilder temp = new StringBuilder(tBBalance.Text);
                if (ch != '\b' && ch != ',')
                {
                    temp.Append(ch);
                    if (float.Parse(temp.ToString()) > (float)_Product.Balance)
                    {
                        e.Handled = true;
                        ShowError("Неверное количество продукта");
                        return;
                    }
                }
                else
                {
                    if(ch == '\b' && temp.Length != 1)
                    {
                        temp.Remove(temp.Length - 1, 1);
                        if (float.Parse(temp.ToString()) > (float)_Product.Balance)
                        {
                            e.Handled = true;
                            ShowError("Неверное количество продукта");
                            return;
                        }
                    }
                }
            }
            else
            {
                e.Handled = true;
                ShowError("Неверное количество продукта");
            }
        }

        private void TimError_Tick(object sender, EventArgs e)
        {
            timError.Stop();
            labelError.Visible = false;
        }

        private void AddProductInInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.ReloadedData();
        }
    }
}
