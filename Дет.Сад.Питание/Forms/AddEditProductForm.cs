using DAL.DTO;
using NLog;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class AddEditProductForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ProductDTO _Product = null;
        private ProductsForm main;

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
            if (tBName.Text == "")
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
                    logger.Debug("Создание нового продукта: " + product + "c id = " + product.Id);
                    logger.Trace("Наименование: " + product.Name);
                    logger.Trace("Псевдоним: " + product.PsevdoName);
                    logger.Trace("Норма: " + product.Norm);
                    logger.Trace("Сумма: " + product.Sum);
                    logger.Trace("Количество: " + product.Balance);
                    logger.Trace("Углеводы: " + product.Carbohydrate);
                    logger.Trace("Жиры: " + product.Fat);
                    logger.Trace("Белки: " + product.Protein);
                    logger.Trace("Витамин Ц: " + product.Vitamine_C);

                    logger.Trace("Тип: " + product.Type.Name);
                    logger.Trace("Ед. изм.: " + product.Type.Name);
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
                    logger.Debug("Обновление продукта: " + product + "c id = " + product.Id);
                    logger.Trace("Наименование: " + product.Name);
                    logger.Trace("Псевдоним: " + product.PsevdoName);
                    logger.Trace("Норма: " + product.Norm);
                    logger.Trace("Сумма: " + product.Sum);
                    logger.Trace("Количество: " + product.Balance);
                    logger.Trace("Углеводы: " + product.Carbohydrate);
                    logger.Trace("Жиры: " + product.Fat);
                    logger.Trace("Белки: " + product.Protein);
                    logger.Trace("Витамин Ц: " + product.Vitamine_C);

                    logger.Trace("Тип: " + product.Type.Name);
                    logger.Trace("Ед. изм.: " + product.Type.Name);
                }
                MainForm.DB.Save();
                MessageBox.Show("Продукт успешно сохранён");
                main.ReloadData();
                this.Close();
            }
        }

        private void ButDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить продукт " + _Product.Name + " ?", "Удаление продукта", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MainForm.DB.Products.Delete(_Product.Id);
                MainForm.DB.Save();
                logger.Debug("Удаление продукта: " + _Product + " с id = " + _Product.Id);
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
