﻿using BLL.Services;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Дет.Сад.Питание.Forms;

namespace Дет.Сад.Питание
{
    public partial class ProductsForm : Form
    {
        public ProductService service = new ProductService(MainForm.DB, Application.StartupPath, MainForm.DataPath);
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
            if (tBSearch.Text.Trim().Length > 0)
            {
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
                    service.Delete(product);
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
                service.BuildDocument();
                lLoad.Visible = false;
            }
        }
    }
}
