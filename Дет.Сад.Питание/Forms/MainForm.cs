using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Дет.Сад.Питание.Forms;

namespace Дет.Сад.Питание
{
    public partial class MainForm : Form
    {
        public static IUnitOfWork DB;
        public MainForm()
        {
            DB = new EFUnitOfWork();
            InitializeComponent();
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
            string pathDir = System.Windows.Forms.Application.StartupPath + "\\Документы\\";
            Process Proc = new Process();
            Proc.StartInfo.FileName = "explorer";
            Proc.StartInfo.Arguments = pathDir;
            Proc.Start();
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
    }
}
