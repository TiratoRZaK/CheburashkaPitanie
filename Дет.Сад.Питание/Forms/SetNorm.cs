using System;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class SetNorm : Form
    {
        public AddEditDishForm main;
        public string key;

        public SetNorm(AddEditDishForm main, string key)
        {
            this.main = main;
            this.key = key;
            InitializeComponent();
        }

        private void TBNorm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (e.KeyChar == '\r')
            {
                main.norms.Add(key, float.Parse(tBNorm.Text));
                this.Close();
            }
            if (!Char.IsDigit(ch) && ch != ',' && ch != 8 && !ch.Equals(Keys.Enter))
            {
                e.Handled = true;
            }
            
        }
    }
}
