using DAL.Interfaces;
using DAL.Repositories;
using NLog;
using System;
using System.IO;
using System.Windows.Forms;
using Дет.Сад.Питание.Forms;

namespace Дет.Сад.Питание
{
    public partial class MainForm : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static IUnitOfWork DB;
        public static String DataPath = Properties.Settings.Default.DataPath;
        public MainForm()
        {
            if ((DB = EFUnitOfWork.GetInstance()) == null)
            {
                MessageBox.Show("Критическая ошибка!", "Невозможно подключиться к базе данных! Приложение завершит свою работу.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Fatal("Невозможно подключиться к базе данных.");
                Application.Exit();
            }
            InitializeComponent();
        }

        private void CheckValidDirectory()
        {
            if (!Directory.Exists(DataPath))
            {
                logger.Debug("Отсутствует путь к документам.");
                DialogResult result = MessageBox.Show("Путь к созданым ранее документам недоступен! Указать новый путь или использовать путь по умолчанию?", "Использовать новый путь?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    fBDialogPath = new FolderBrowserDialog
                    {
                        Description = "Выберите папку для загрузки и сохранения документов"
                    };
                    fBDialogPath.ShowDialog();
                    if (!Directory.Exists(fBDialogPath.SelectedPath))
                    {
                        CheckValidDirectory();
                    }
                    else
                    {
                        DataPath = fBDialogPath.SelectedPath;
                        logger.Debug("Выбран путь к документам: " + DataPath);
                    }
                }
                else
                {
                    DataPath = Application.StartupPath;
                    logger.Debug("Используется путь по умолчанию: " + DataPath);
                }

            }
            this.WindowState = FormWindowState.Normal;
            this.Focus();
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
            Properties.Settings.Default.DataPath = DataPath;
            Properties.Settings.Default.Save();
            logger.Debug("Сохранён путь к документам: " + DataPath);
            logger.Debug("Программа завершена.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            logger.Debug("Старт программы.");
            CheckValidDirectory();
        }
    }
}
