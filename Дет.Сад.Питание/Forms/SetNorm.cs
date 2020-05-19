using System;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class SetNorm : Form
    {
        public AddEditDishForm main;
        public string nameProduct;

        public SetNorm(AddEditDishForm main, string nameProduct)
        {
            this.main = main;
            this.nameProduct = nameProduct;
            InitializeComponent();
        }

        private void TBNorm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (e.KeyChar == '\r')
            {
                main.norms.Add(nameProduct, float.Parse(tBNorm.Text));
                this.Close();
            }
            if (!Char.IsDigit(ch) && ch != ',' && ch != 8 && !ch.Equals(Keys.Enter))
            {
                e.Handled = true;
            }

        }
    }
}
