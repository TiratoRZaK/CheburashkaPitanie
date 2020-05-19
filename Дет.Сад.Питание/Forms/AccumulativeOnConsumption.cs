using BLL.Services;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Дет.Сад.Питание.Forms
{
    public partial class AccumulativeOnConsumption : Form
    {
        private AccumulativeOnConsumptionService service = new AccumulativeOnConsumptionService(MainForm.DB, Application.StartupPath, MainForm.DataPath);
        private MainForm main;
        public AccumulativeOnConsumption(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeListBoxes();
        }

        void InitializeListBoxes()
        {
            foreach (MenuDTO item in MainForm.DB.Menus.GetAll())
                clBMenus.Items.Add(item);
            cBMount.DataSource = new string[]
            {
                "январь",
                "ферваль",
                "март",
                "апрель",
                "мая",
                "июнь",
                "июль",
                "август",
                "сентябрь",
                "октябрь",
                "ноябрь",
                "декабрь"
            };
            for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 100; i++)
            {
                cBYear.Items.Add(i);
            }
            cBYear.SelectedIndex = 0;
        }

        private void ButAddMenus_Click(object sender, EventArgs e)
        {
            if (clBMenus.CheckedItems.Count != 0)
            {
                BuildDocument();
            }
        }

        private void AccumulativeOnConsumption_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
        }

        public void BuildDocument()
        {
            DialogResult dialogResult = MessageBox.Show("Все запущенные документы будут закрыты без сохранения! Сохраните используемые в данный момент документы и нажмите 'Ок'", "ВНИМАНИЕ!!!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                lLoad.Visible = true;
                List<MenuDTO> menus = new List<MenuDTO>();
                foreach (MenuDTO menu in clBMenus.CheckedItems)
                {
                    menus.Add(menu);
                }
                service.BuildDociument(menus, cBMount.SelectedItem.ToString(), cBYear.SelectedItem.ToString());
                lLoad.Visible = false;
            }
        }
        private void butCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clBMenus.Items.Count; i++)
            {
                clBMenus.SetItemChecked(i, true);
            }
        }

        private void butCheckClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clBMenus.Items.Count; i++)
            {
                clBMenus.SetItemChecked(i, false);
            }
        }
    }
}
