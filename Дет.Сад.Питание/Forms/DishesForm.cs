using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Дет.Сад.Питание.Services;

namespace Дет.Сад.Питание.Forms
{
    public partial class DishesForm : Form
    {
        public MainForm main;

        public DishesForm(MainForm main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void ButAddDish_Click(object sender, EventArgs e)
        {
            AddEditDishForm addForm = new AddEditDishForm(this);
            addForm.Show();
        }

        public void ReloadData()
        {
            if (tBSearch.Text.Trim().Length > 0)
            {
                //search data
                PopulateData(MainForm.DB.Dishes.GetAll().Where(x => x.Name.ToLower().Contains(tBSearch.Text.ToLower())));
            }
            else
            {
                PopulateData(MainForm.DB.Dishes.GetAll());
            }
        }

        private void PopulateData(IEnumerable<DishDTO> dishes)
        {
            dGVDishesList.Rows.Clear();
            foreach (var item in dishes)
            {
                dGVDishesList.Rows.Add(new object[] {
                    item.Name,
                    item.Norm.ToString(),
                    item.Vitamine_C.ToString(),
                    item.Carbohydrate.ToString(),
                    item.Protein.ToString(),
                    item.Fat.ToString(),
                    "Изменить",
                    "Удалить"
                });
                dGVDishesList.Rows[dGVDishesList.RowCount - 1].Tag = item;
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

        private void DGVDishesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                AddEditDishForm addEdit = new AddEditDishForm((DishDTO)dGVDishesList.CurrentRow.Tag, this);
                addEdit.Show();
            }
            if (e.ColumnIndex == 7)
            {
                DishDTO dish = (DishDTO)dGVDishesList.CurrentRow.Tag;
                if (MessageBox.Show("Удалить " + dish.Name + " ?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MainForm.DB.Dishes.Delete(dish.Id);
                    MainForm.DB.Save();
                    LoggingService.AddLog("Удаление блюда: "+dish.ToString());
                    ReloadData();
                }
            }
        }

        private void DishesForm_Shown(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void DishesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
        }
    }
}
