using DAL.DTO;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Дет.Сад.Питание.Forms;

namespace Дет.Сад.Питание
{
    public partial class ProductsForm : Form
    {
        public static Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        public static string generalfile = System.Windows.Forms.Application.StartupPath + "\\Документы\\Шаблоны\\Остатки продуктов.docx"; // файл-шаблон
        public static Object fileName = generalfile;
        public static Object missing = System.Type.Missing;
        public MainForm main;

        public ProductsForm(MainForm main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void ButAddProduct_Click(object sender, EventArgs e)
        {
            AddEditProductForm addForm = new AddEditProductForm(this);
            addForm.Show();            
        }

        private void ProductsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
        }

        private void ProductsForm_Shown(object sender, EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            if(tBSearch.Text.Trim().Length>0)
            {
                //search data
                PopulateData(MainForm.DB.Products.GetAll().Where(x=>x.Name.ToLower().Contains(tBSearch.Text.ToLower())));
            }
            else
            {
                PopulateData(MainForm.DB.Products.GetAll());
            }
        }

        private void PopulateData(IEnumerable<ProductDTO> products)
        {
            dGVProductsList.Rows.Clear();
            foreach(var item in products)
            {
                dGVProductsList.Rows.Add(new object[] {
                    item.Name,
                    item.Unit.ToString(),
                    item.Type.ToString(),
                    item.Norm.ToString(),
                    item.Price.ToString(),
                    item.Balance.ToString(),
                    "Изменить",
                    "Удалить"
                });
                dGVProductsList.Rows[dGVProductsList.RowCount - 1].Tag = item;
            }
        }

        private void ButRefresh_Click(object sender, EventArgs e)
        {
            tBSearch.Text = "";
            ReloadData();
        }

        private void TBSearch_TextChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void DGVProductsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                AddEditProductForm addEdit = new AddEditProductForm((ProductDTO)dGVProductsList.CurrentRow.Tag, this);
                addEdit.Show();
            }
            if (e.ColumnIndex == 7)
            {
                ProductDTO product = (ProductDTO)dGVProductsList.CurrentRow.Tag;
                if (MessageBox.Show("Удалить " + product.Name + " ?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MainForm.DB.Products.Delete(product.Id);
                    MainForm.DB.Save();
                    ReloadData();
                }
            }
        }

        private void ButBuild_Click(object sender, EventArgs e)
        {
            BuildDocument();
        }

        private void BuildDocument()
        {
            app = new Microsoft.Office.Interop.Word.Application();
            app.Documents.Open(ref fileName);
            app.Visible = true;
            Document document = app.ActiveDocument;
            Range range = document.Paragraphs[document.Paragraphs.Count].Range;
            double summ = 0;
            int i = 2;
            foreach (ProductDTO product in MainForm.DB.Products.GetAll())
            {
                document.Tables[1].Rows.Add();
                i++;
                document.Tables[1].Cell(i, 1).Range.Text = product.Name;
                document.Tables[1].Cell(i, 2).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                document.Tables[1].Cell(i, 4).Range.Text = product.Balance.ToString();
                document.Tables[1].Cell(i, 3).Range.Text = product.Price.ToString();
                document.Tables[1].Cell(i, 5).Range.Text = Math.Round(product.Balance* product.Price, 2).ToString();
                summ += product.Balance * product.Price;
            }
            document.Tables[1].Rows.Add();
            i++;
            document.Tables[1].Cell(i, 1).Range.Text = "Итого";
            document.Tables[1].Cell(i, 5).Range.Text = summ.ToString();
        }
    }
}
