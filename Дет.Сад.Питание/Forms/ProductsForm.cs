using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Дет.Сад.Питание.Forms;
using Дет.Сад.Питание.Services;
using Дет.Сад.Питание.Services.WordService;
using Word = Microsoft.Office.Interop.Word;

namespace Дет.Сад.Питание
{
    public partial class ProductsForm : Form
    {
        public MainForm main;
        public WordWorker WordWorker;

        public ProductsForm(MainForm main)
        {
            this.main = main;
            WordWorker = new WordWorker(Application.StartupPath + "\\Document Templates\\Остатки продуктов.docx");
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
            dGVProductsList.Rows.Clear();
            foreach (var item in products)
            {
                dGVProductsList.Rows.Add(new object[] {
                    item.Name,
                    item.Unit.ToString(),
                    item.Type.ToString(),
                    item.Norm.ToString(),
                    item.Sum.ToString(),
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
            if (e.ColumnIndex == 6)
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
                    LoggingService.AddLog("Удаление продукта: " + product.ToString());
                    ReloadData();
                }
            }
        }

        private void ButBuild_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                BuildDocument();
                lLoad.Visible = false;
            }
            WordWorker.Close();
        }

        private void BuildDocument()
        {
            WordWorker.Load();
            Word.Range range = WordWorker.doc.Paragraphs[WordWorker.doc.Paragraphs.Count].Range;
            double summ = 0;
            int i = 2;
            foreach (ProductDTO product in MainForm.DB.Products.GetAll())
            {
                WordWorker.doc.Tables[1].Rows.Add();
                i++;
                WordWorker.doc.Tables[1].Cell(i, 1).Range.Text = product.Name;
                WordWorker.doc.Tables[1].Cell(i, 2).Range.Text = MainForm.DB.Units.Get(product.UnitId).Name;
                WordWorker.doc.Tables[1].Cell(i, 4).Range.Text = product.Balance.ToString();
                WordWorker.doc.Tables[1].Cell(i, 3).Range.Text = product.GetPrice().ToString();
                WordWorker.doc.Tables[1].Cell(i, 5).Range.Text = Math.Round(product.Sum, 2).ToString();
                summ += product.Sum;
            }
            WordWorker.doc.Tables[1].Rows.Add();
            i++;
            WordWorker.doc.Tables[1].Cell(i, 1).Range.Text = "Итого";
            WordWorker.doc.Tables[1].Cell(i, 5).Range.Text = Math.Round(summ,2).ToString();
            DateTime now = DateTime.Now;
            WordWorker.Save(MainForm.DataPath + "\\Документы\\Остатки продуктов на "+ (now.ToString("g")).Replace('.','-').Replace(':', '-') + ".docx");
            WordWorker.Close();
            WordWorker.Open(MainForm.DataPath + "\\Документы\\Остатки продуктов на " + (now.ToString("g")).Replace('.', '-').Replace(':', '-') + ".docx");
            LoggingService.AddLog("Распечатка остатков на " + (now.ToString("g")).Replace('.', '-').Replace(':', '-') + " в файл по пути: " + MainForm.DataPath + "\\Документы\\");
        }
    }
}
