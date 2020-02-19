using DAL.DTO;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Дет.Сад.Питание.Models;
using Дет.Сад.Питание.Services;

namespace Дет.Сад.Питание.Forms
{
    public partial class SettingsForm : Form
    {
        public MainForm main;

        public SettingsForm(MainForm main)
        {
            this.main = main;
            InitializeComponent();
            InitializeSellers();
        }

        private void tBDirectoryPath_TextChanged(object sender, EventArgs e)
        {
            if (!tBDirectoryPath.Text.Equals(""))
            {
                MainForm.DataPath = tBDirectoryPath.Text;
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.WindowState = FormWindowState.Normal;
            Properties.Settings.Default.DataPath = tBDirectoryPath.Text;
            Properties.Settings.Default.LogsPath = tBPathHistory.Text;
            Properties.Settings.Default.Save();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tBDirectoryPath.Text = MainForm.DataPath;
            tBPathHistory.Text = MainForm.LogsPath;
            lBLogs.Items.Clear();
            foreach (Log log in LoggingService.logs)
            {
                lBLogs.Items.Add(log);
            }
        }

        private void butDir_Click(object sender, EventArgs e)
        {
            fBDialog.Description = "Выберите папку для сохранения сформированных документов";
            fBDialog.ShowDialog();
            if (fBDialog.SelectedPath != "")
            {
                tBDirectoryPath.Text = fBDialog.SelectedPath;
            }
        }

        private void lBLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Log log = lBLogs.SelectedItem as Log;
            StringBuilder message = new StringBuilder(log.time.ToString());
            if (log.actions != null)
            {
                foreach (ActionDescription action in log.actions)
                {
                    StringBuilder desc = new StringBuilder("");
                    if (action.description != null)
                    {
                        foreach (string item in action.description)
                        {
                            desc.Append(item + "\n");
                        }
                    }
                    message.Append("\n" + action.name + "\n " + desc.ToString());
                }
            }
            MessageBox.Show(message.ToString(), log.message, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fBDialog.Description = "Выберите папку для сохранения файла с иторией";
            fBDialog.ShowDialog();
            if (fBDialog.SelectedPath != "")
            {
                tBPathHistory.Text = fBDialog.SelectedPath;
            }
        }

        private void tBPathHistory_TextChanged(object sender, EventArgs e)
        {
            if (!tBPathHistory.Text.Equals(""))
            {
                MainForm.LogsPath = tBPathHistory.Text;
            }
        }

        private void butNow_Click(object sender, EventArgs e)
        {
            lBLogs.Items.Clear();
            foreach (Log log in LoggingService.logs)
            {
                if (log.time.Date.Equals(DateTime.Now.Date))
                {
                    lBLogs.Items.Add(log);
                }
            }
        }

        private void clearFilters_Click(object sender, EventArgs e)
        {
            nMin.Value = 0;
            lBLogs.Items.Clear();
            foreach (Log log in LoggingService.logs)
            {
                lBLogs.Items.Add(log);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            lBLogs.Items.Clear();
            foreach (Log log in LoggingService.logs)
            {
                if (log.time.AddMinutes((int)nMin.Value) >= DateTime.Now)
                {
                    lBLogs.Items.Add(log);
                }
            }
        }

        private void butNewMonth_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить из программы всю отчётность за текущий месяц?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                foreach (InvoiceDTO invoice in MainForm.DB.Invoices.GetAll())
                {
                    if (File.Exists(Application.StartupPath + "\\Local Data\\" + invoice.FileName))
                    {
                        File.Delete(Application.StartupPath + "\\Local Data\\" + invoice.FileName);
                    }
                    MainForm.DB.Invoices.Delete(invoice.Id);
                }
                foreach (DeliveryNoteDTO deliveryNote in MainForm.DB.DeliveryNotes.GetAll())
                {
                    if (File.Exists(Application.StartupPath + "\\Local Data\\" + deliveryNote.FileName))
                    {
                        File.Delete(Application.StartupPath + "\\Local Data\\" + deliveryNote.FileName);
                    }
                    MainForm.DB.DeliveryNotes.Delete(deliveryNote.Id);
                }
                foreach (MenuDTO menu in MainForm.DB.Menus.GetAll())
                {
                    if (File.Exists(Application.StartupPath + "\\Local Data\\" + menu.FileName))
                    {
                        File.Delete(Application.StartupPath + "\\Local Data\\" + menu.FileName);
                    }
                    MainForm.DB.Menus.Delete(menu.Id);
                }
                MainForm.DB.Save();
                MessageBox.Show("Программа готова для работы с нового месяца.","Успешно выполнено");
            }
        }

        public void InitializeSellers()
        {
            cBSellers.Items.Clear();
            foreach (SellerDTO seller in MainForm.DB.Sellers.GetAll())
            {
                cBSellers.Items.Add(seller);
            }
            cBSellers.SelectedIndex = 0;
        }

        private void cBSellers_SelectedIndexChanged(object sender, EventArgs e)
        {
            butDelete.Enabled = true;
            SellerDTO selectedSeller = (cBSellers.SelectedItem as SellerDTO);
            tBNameCompany.Text = selectedSeller.NameCompany;
            tBNameCompanyFull.Text = selectedSeller.FullNameCompany;
            tBINN.Text = selectedSeller.INN;
            tBKPP.Text = selectedSeller.KPP;
            tBBIK.Text = selectedSeller.BIK;
            tBOGRN.Text = selectedSeller.OGRN;
            tBAddress.Text = selectedSeller.AddressCompany;
            tBEmail.Text = selectedSeller.Email;
            tBPhone.Text = selectedSeller.PhoneNumber;
            tBPersonalAccount.Text = selectedSeller.PersonalAccount;
            tBBankAccount.Text = selectedSeller.BankAccount;
            tBCorespAccount.Text = selectedSeller.CorrespondentAccount;
            tBBank.Text = selectedSeller.Bank;
            tBNameSeller.Text = selectedSeller.NameSeller;
            tBNameSellerSpec.Text = selectedSeller.NameSellerSpec;
            tBRangSeller.Text = selectedSeller.RangSeller;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (cBSellers.Enabled == true)
            {
                SellerDTO seller = MainForm.DB.Sellers.Get((cBSellers.SelectedItem as SellerDTO).Id);
                seller.NameCompany = tBNameCompany.Text;
                seller.FullNameCompany = tBNameCompanyFull.Text;
                seller.INN = tBINN.Text;
                seller.KPP = tBKPP.Text;
                seller.OGRN = tBOGRN.Text;
                seller.BIK = tBBIK.Text;
                seller.AddressCompany = tBAddress.Text;
                seller.Email = tBEmail.Text;
                seller.PhoneNumber = tBPhone.Text;
                seller.PersonalAccount = tBPersonalAccount.Text;
                seller.BankAccount = tBBankAccount.Text;
                seller.CorrespondentAccount = tBCorespAccount.Text;
                seller.Bank = tBBank.Text;
                seller.NameSeller = tBNameSeller.Text;
                seller.NameSellerSpec = tBNameSellerSpec.Text;
                seller.RangSeller = tBRangSeller.Text;
                MainForm.DB.Sellers.Update(seller);
                MainForm.DB.Save();
                MessageBox.Show("Данные успешно сохранены!");
                InitializeSellers();
            }
            else
            {
                SellerDTO seller = new SellerDTO();
                seller.NameCompany = tBNameCompany.Text;
                seller.FullNameCompany = tBNameCompanyFull.Text;
                seller.INN = tBINN.Text;
                seller.KPP = tBKPP.Text;
                seller.OGRN = tBOGRN.Text;
                seller.BIK = tBBIK.Text;
                seller.AddressCompany = tBAddress.Text;
                seller.Email = tBEmail.Text;
                seller.PhoneNumber = tBPhone.Text;
                seller.PersonalAccount = tBPersonalAccount.Text;
                seller.BankAccount = tBBankAccount.Text;
                seller.CorrespondentAccount = tBCorespAccount.Text;
                seller.Bank = tBBank.Text;
                seller.NameSeller = tBNameSeller.Text;
                seller.NameSellerSpec = tBNameSellerSpec.Text;
                seller.RangSeller = tBRangSeller.Text;
                MainForm.DB.Sellers.Create(seller);
                MainForm.DB.Save();
                MessageBox.Show("Поставщик успешно добавлен!");
                cBSellers.Enabled = true;
                butDelete.Enabled = true;
                butAdd.Text = "Добавить нового поставщика";
                InitializeSellers();

            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (butAdd.Text.Equals("Добавить нового поставщика")) {
                cBSellers.Enabled = false;
                butDelete.Enabled = false;
                butAdd.Text = "Отменить добавление";
                tBNameCompany.Text = "";
                tBNameCompanyFull.Text = "";
                tBINN.Text = "";
                tBKPP.Text = "";
                tBBIK.Text = "";
                tBOGRN.Text = "";
                tBAddress.Text = "";
                tBEmail.Text = "";
                tBPhone.Text = "";
                tBPersonalAccount.Text = "";
                tBBankAccount.Text = "";
                tBCorespAccount.Text = "";
                tBBank.Text = "";
                tBNameSeller.Text = "";
                tBNameSellerSpec.Text = "";
                tBRangSeller.Text = "";
            }
            else
            {
                cBSellers.Enabled = true;
                butDelete.Enabled = true;
                butAdd.Text = "Добавить нового поставщика";
                InitializeSellers();
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            SellerDTO seller = MainForm.DB.Sellers.Get((cBSellers.SelectedItem as SellerDTO).Id);
            if (MessageBox.Show("Вы уверены что хотите удалить поставщика " + seller.NameCompany + "?", "Удаление поставщика", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MainForm.DB.Sellers.Delete(seller.Id);
                MainForm.DB.Save();
            }
            InitializeSellers();
        }
    }
}
