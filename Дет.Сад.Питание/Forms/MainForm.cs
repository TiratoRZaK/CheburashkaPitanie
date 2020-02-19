using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Дет.Сад.Питание.Forms;
using Дет.Сад.Питание.Services;

namespace Дет.Сад.Питание
{
    public partial class MainForm : Form
    {
        public static IUnitOfWork DB;
        public static String DataPath = Properties.Settings.Default.DataPath;
        public static String LogsPath = Properties.Settings.Default.LogsPath;
        public MainForm()
        {
            DB = EFUnitOfWork.GetInstance();
            InitializeComponent();
            LoggingService.StartLogging();
        }

        private void checkValidDirectory()
        {
            if (!Directory.Exists(DataPath))
            {
                DialogResult result = MessageBox.Show("Путь к созданым ранее документам недоступен! Указать новый путь или использовать путь по умолчанию?", "Использовать новый путь?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    fBDialogPath = new FolderBrowserDialog();
                    fBDialogPath.Description = "Выберите папку для загрузки и сохранения документов";
                    fBDialogPath.ShowDialog();
                    if (!Directory.Exists(fBDialogPath.SelectedPath))
                    {
                        checkValidDirectory();
                    }
                    else
                    {
                        DataPath = fBDialogPath.SelectedPath;
                    }
                }
                else
                {
                    DataPath = Application.StartupPath;
                }

            }
            this.WindowState = FormWindowState.Normal;
            this.Focus();
            LoggingService.AddLog("Выбран путь: "+ DataPath);
        }

        private void ButProducts_Click(object sender, EventArgs e)
        {
            ProductsForm productsForm = new ProductsForm(this);
            productsForm.Show();
            this.WindowState = FormWindowState.Minimized;

        }

        private void ButDishes_Click(object sender, EventArgs e)
        {
            DishesForm dishesForm = new DishesForm(this);
            dishesForm.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButContracts_Click(object sender, EventArgs e)
        {
            ContractsForm contractsForm = new ContractsForm(this);
            contractsForm.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButDirectory_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButInvoices_Click(object sender, EventArgs e)
        {
            InvoicesForm invoicesForm = new InvoicesForm(this);
            invoicesForm.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButOverhead_Click(object sender, EventArgs e)
        {
            DeliveryNotesForm deliveryNoteForm = new DeliveryNotesForm(this);
            deliveryNoteForm.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButIncome_Click(object sender, EventArgs e)
        {
            AccumulativeOnArrival accumulativeOnArrival = new AccumulativeOnArrival(this);
            accumulativeOnArrival.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButMenus_Click(object sender, EventArgs e)
        {
            MenusForm menusForm = new MenusForm(this);
            menusForm.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButConsumption_Click(object sender, EventArgs e)
        {
            AccumulativeOnConsumption accumulative = new AccumulativeOnConsumption(this);
            accumulative.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButPatterns_Click(object sender, EventArgs e)
        {
            PatternsForm patternsForm = new PatternsForm(this);
            patternsForm.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.DataPath = MainForm.DataPath;
            Properties.Settings.Default.LogsPath = MainForm.LogsPath;
            Properties.Settings.Default.Save();
            LoggingService.StopLogging();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            checkValidDirectory();
            if (!Directory.Exists(Properties.Settings.Default.LogsPath))
            {
                Properties.Settings.Default.LogsPath = Application.StartupPath + "\\Local Data\\";
                LogsPath = Application.StartupPath + "\\Local Data\\";
                Properties.Settings.Default.Save();
            }
        }
    }
}
