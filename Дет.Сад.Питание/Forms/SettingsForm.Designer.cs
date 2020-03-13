namespace Дет.Сад.Питание.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tControl = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.butNewMonth = new System.Windows.Forms.Button();
            this.butPathHistory = new System.Windows.Forms.Button();
            this.tBPathHistory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butDir = new System.Windows.Forms.Button();
            this.tBDirectoryPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Providers = new System.Windows.Forms.TabPage();
            this.butAdd = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tBRangSeller = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tBNameCompanyFull = new System.Windows.Forms.TextBox();
            this.tBNameSellerSpec = new System.Windows.Forms.TextBox();
            this.tBNameSeller = new System.Windows.Forms.TextBox();
            this.tBBank = new System.Windows.Forms.TextBox();
            this.tBCorespAccount = new System.Windows.Forms.TextBox();
            this.tBBankAccount = new System.Windows.Forms.TextBox();
            this.tBPersonalAccount = new System.Windows.Forms.TextBox();
            this.tBPhone = new System.Windows.Forms.TextBox();
            this.tBEmail = new System.Windows.Forms.TextBox();
            this.tBAddress = new System.Windows.Forms.TextBox();
            this.tBOGRN = new System.Windows.Forms.TextBox();
            this.tBKPP = new System.Windows.Forms.TextBox();
            this.tBBIK = new System.Windows.Forms.TextBox();
            this.tBINN = new System.Windows.Forms.TextBox();
            this.tBNameCompany = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cBSellers = new System.Windows.Forms.ComboBox();
            this.Types = new System.Windows.Forms.TabPage();
            this.History = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nMin = new System.Windows.Forms.NumericUpDown();
            this.clearFilters = new System.Windows.Forms.Button();
            this.butNow = new System.Windows.Forms.Button();
            this.lBLogs = new System.Windows.Forms.ListBox();
            this.fBDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.butExport = new System.Windows.Forms.Button();
            this.butImport = new System.Windows.Forms.Button();
            this.tControl.SuspendLayout();
            this.General.SuspendLayout();
            this.Providers.SuspendLayout();
            this.panel1.SuspendLayout();
            this.History.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMin)).BeginInit();
            this.SuspendLayout();
            // 
            // tControl
            // 
            this.tControl.Controls.Add(this.General);
            this.tControl.Controls.Add(this.Providers);
            this.tControl.Controls.Add(this.Types);
            this.tControl.Controls.Add(this.History);
            this.tControl.Location = new System.Drawing.Point(13, 13);
            this.tControl.Name = "tControl";
            this.tControl.SelectedIndex = 0;
            this.tControl.Size = new System.Drawing.Size(775, 425);
            this.tControl.TabIndex = 0;
            // 
            // General
            // 
            this.General.Controls.Add(this.butImport);
            this.General.Controls.Add(this.butExport);
            this.General.Controls.Add(this.butNewMonth);
            this.General.Controls.Add(this.butPathHistory);
            this.General.Controls.Add(this.tBPathHistory);
            this.General.Controls.Add(this.label2);
            this.General.Controls.Add(this.butDir);
            this.General.Controls.Add(this.tBDirectoryPath);
            this.General.Controls.Add(this.label1);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(767, 399);
            this.General.TabIndex = 0;
            this.General.Text = "Общие";
            this.General.UseVisualStyleBackColor = true;
            // 
            // butNewMonth
            // 
            this.butNewMonth.Location = new System.Drawing.Point(21, 353);
            this.butNewMonth.Name = "butNewMonth";
            this.butNewMonth.Size = new System.Drawing.Size(191, 28);
            this.butNewMonth.TabIndex = 6;
            this.butNewMonth.Text = "Перейти на новый месяц";
            this.butNewMonth.UseVisualStyleBackColor = true;
            this.butNewMonth.Click += new System.EventHandler(this.butNewMonth_Click);
            // 
            // butPathHistory
            // 
            this.butPathHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPathHistory.Location = new System.Drawing.Point(581, 95);
            this.butPathHistory.Name = "butPathHistory";
            this.butPathHistory.Size = new System.Drawing.Size(165, 20);
            this.butPathHistory.TabIndex = 5;
            this.butPathHistory.Text = "Выберите папку";
            this.butPathHistory.UseVisualStyleBackColor = true;
            this.butPathHistory.Click += new System.EventHandler(this.button1_Click);
            // 
            // tBPathHistory
            // 
            this.tBPathHistory.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Дет.Сад.Питание.Properties.Settings.Default, "LogsPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tBPathHistory.Location = new System.Drawing.Point(21, 95);
            this.tBPathHistory.Name = "tBPathHistory";
            this.tBPathHistory.ReadOnly = true;
            this.tBPathHistory.Size = new System.Drawing.Size(542, 20);
            this.tBPathHistory.TabIndex = 4;
            this.tBPathHistory.Text = global::Дет.Сад.Питание.Properties.Settings.Default.LogsPath;
            this.tBPathHistory.TextChanged += new System.EventHandler(this.tBPathHistory_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Путь к файлу с историей:";
            // 
            // butDir
            // 
            this.butDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDir.Location = new System.Drawing.Point(581, 38);
            this.butDir.Name = "butDir";
            this.butDir.Size = new System.Drawing.Size(165, 20);
            this.butDir.TabIndex = 2;
            this.butDir.Text = "Выберите папку";
            this.butDir.UseVisualStyleBackColor = true;
            this.butDir.Click += new System.EventHandler(this.butDir_Click);
            // 
            // tBDirectoryPath
            // 
            this.tBDirectoryPath.Location = new System.Drawing.Point(21, 38);
            this.tBDirectoryPath.Name = "tBDirectoryPath";
            this.tBDirectoryPath.ReadOnly = true;
            this.tBDirectoryPath.Size = new System.Drawing.Size(542, 20);
            this.tBDirectoryPath.TabIndex = 1;
            this.tBDirectoryPath.Text = global::Дет.Сад.Питание.Properties.Settings.Default.DataPath;
            this.tBDirectoryPath.TextChanged += new System.EventHandler(this.tBDirectoryPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к папке с документами:";
            // 
            // Providers
            // 
            this.Providers.Controls.Add(this.butAdd);
            this.Providers.Controls.Add(this.butDelete);
            this.Providers.Controls.Add(this.butSave);
            this.Providers.Controls.Add(this.panel1);
            this.Providers.Controls.Add(this.label5);
            this.Providers.Controls.Add(this.cBSellers);
            this.Providers.Location = new System.Drawing.Point(4, 22);
            this.Providers.Name = "Providers";
            this.Providers.Padding = new System.Windows.Forms.Padding(3);
            this.Providers.Size = new System.Drawing.Size(767, 399);
            this.Providers.TabIndex = 1;
            this.Providers.Text = "Поставщики";
            this.Providers.UseVisualStyleBackColor = true;
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(24, 279);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(243, 23);
            this.butAdd.TabIndex = 5;
            this.butAdd.Text = "Добавить нового поставщика";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butDelete
            // 
            this.butDelete.Enabled = false;
            this.butDelete.Location = new System.Drawing.Point(24, 316);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(243, 23);
            this.butDelete.TabIndex = 4;
            this.butDelete.Text = "Удалить выбранного поставщика";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(24, 353);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(243, 21);
            this.butSave.TabIndex = 3;
            this.butSave.Text = "Сохранить введённые данные";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tBRangSeller);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.tBNameCompanyFull);
            this.panel1.Controls.Add(this.tBNameSellerSpec);
            this.panel1.Controls.Add(this.tBNameSeller);
            this.panel1.Controls.Add(this.tBBank);
            this.panel1.Controls.Add(this.tBCorespAccount);
            this.panel1.Controls.Add(this.tBBankAccount);
            this.panel1.Controls.Add(this.tBPersonalAccount);
            this.panel1.Controls.Add(this.tBPhone);
            this.panel1.Controls.Add(this.tBEmail);
            this.panel1.Controls.Add(this.tBAddress);
            this.panel1.Controls.Add(this.tBOGRN);
            this.panel1.Controls.Add(this.tBKPP);
            this.panel1.Controls.Add(this.tBBIK);
            this.panel1.Controls.Add(this.tBINN);
            this.panel1.Controls.Add(this.tBNameCompany);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(311, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 366);
            this.panel1.TabIndex = 2;
            // 
            // tBRangSeller
            // 
            this.tBRangSeller.Location = new System.Drawing.Point(222, 335);
            this.tBRangSeller.Name = "tBRangSeller";
            this.tBRangSeller.Size = new System.Drawing.Size(196, 20);
            this.tBRangSeller.TabIndex = 40;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 341);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(141, 13);
            this.label21.TabIndex = 39;
            this.label21.Text = "Должность руководителя:";
            // 
            // tBNameCompanyFull
            // 
            this.tBNameCompanyFull.Location = new System.Drawing.Point(222, 37);
            this.tBNameCompanyFull.Name = "tBNameCompanyFull";
            this.tBNameCompanyFull.Size = new System.Drawing.Size(196, 20);
            this.tBNameCompanyFull.TabIndex = 38;
            // 
            // tBNameSellerSpec
            // 
            this.tBNameSellerSpec.Location = new System.Drawing.Point(222, 305);
            this.tBNameSellerSpec.Name = "tBNameSellerSpec";
            this.tBNameSellerSpec.Size = new System.Drawing.Size(196, 20);
            this.tBNameSellerSpec.TabIndex = 37;
            // 
            // tBNameSeller
            // 
            this.tBNameSeller.Location = new System.Drawing.Point(222, 275);
            this.tBNameSeller.Name = "tBNameSeller";
            this.tBNameSeller.Size = new System.Drawing.Size(196, 20);
            this.tBNameSeller.TabIndex = 36;
            // 
            // tBBank
            // 
            this.tBBank.Location = new System.Drawing.Point(222, 249);
            this.tBBank.Name = "tBBank";
            this.tBBank.Size = new System.Drawing.Size(196, 20);
            this.tBBank.TabIndex = 35;
            // 
            // tBCorespAccount
            // 
            this.tBCorespAccount.Location = new System.Drawing.Point(222, 223);
            this.tBCorespAccount.Name = "tBCorespAccount";
            this.tBCorespAccount.Size = new System.Drawing.Size(196, 20);
            this.tBCorespAccount.TabIndex = 34;
            // 
            // tBBankAccount
            // 
            this.tBBankAccount.Location = new System.Drawing.Point(222, 197);
            this.tBBankAccount.Name = "tBBankAccount";
            this.tBBankAccount.Size = new System.Drawing.Size(196, 20);
            this.tBBankAccount.TabIndex = 33;
            // 
            // tBPersonalAccount
            // 
            this.tBPersonalAccount.Location = new System.Drawing.Point(222, 171);
            this.tBPersonalAccount.Name = "tBPersonalAccount";
            this.tBPersonalAccount.Size = new System.Drawing.Size(196, 20);
            this.tBPersonalAccount.TabIndex = 32;
            // 
            // tBPhone
            // 
            this.tBPhone.Location = new System.Drawing.Point(222, 145);
            this.tBPhone.Name = "tBPhone";
            this.tBPhone.Size = new System.Drawing.Size(196, 20);
            this.tBPhone.TabIndex = 31;
            // 
            // tBEmail
            // 
            this.tBEmail.Location = new System.Drawing.Point(279, 119);
            this.tBEmail.Name = "tBEmail";
            this.tBEmail.Size = new System.Drawing.Size(139, 20);
            this.tBEmail.TabIndex = 30;
            // 
            // tBAddress
            // 
            this.tBAddress.Location = new System.Drawing.Point(64, 119);
            this.tBAddress.Name = "tBAddress";
            this.tBAddress.Size = new System.Drawing.Size(139, 20);
            this.tBAddress.TabIndex = 29;
            // 
            // tBOGRN
            // 
            this.tBOGRN.Location = new System.Drawing.Point(279, 90);
            this.tBOGRN.Name = "tBOGRN";
            this.tBOGRN.Size = new System.Drawing.Size(139, 20);
            this.tBOGRN.TabIndex = 28;
            // 
            // tBKPP
            // 
            this.tBKPP.Location = new System.Drawing.Point(279, 62);
            this.tBKPP.Name = "tBKPP";
            this.tBKPP.Size = new System.Drawing.Size(139, 20);
            this.tBKPP.TabIndex = 27;
            // 
            // tBBIK
            // 
            this.tBBIK.Location = new System.Drawing.Point(64, 90);
            this.tBBIK.Name = "tBBIK";
            this.tBBIK.Size = new System.Drawing.Size(139, 20);
            this.tBBIK.TabIndex = 26;
            // 
            // tBINN
            // 
            this.tBINN.Location = new System.Drawing.Point(64, 62);
            this.tBINN.Name = "tBINN";
            this.tBINN.Size = new System.Drawing.Size(139, 20);
            this.tBINN.TabIndex = 25;
            // 
            // tBNameCompany
            // 
            this.tBNameCompany.Location = new System.Drawing.Point(222, 12);
            this.tBNameCompany.Name = "tBNameCompany";
            this.tBNameCompany.Size = new System.Drawing.Size(196, 20);
            this.tBNameCompany.TabIndex = 24;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(219, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "ОГРН:";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(24, 305);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(163, 31);
            this.label19.TabIndex = 22;
            this.label19.Text = "Руководитель в род. падеже (включая должность) :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 278);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "Руководитель:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 226);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(137, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "Корреспондентский счёт:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Банковский счёт:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 174);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Расчётный счёт:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 252);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Отделение банка:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "БИК:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(219, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "КПП:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Телефонный номер:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(219, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Адрес:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "ИНН:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Полное наименование компании:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Наименование компании (краткое) :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(21, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Выберите поставщика, данные о котором вы хотели бы изменить:";
            // 
            // cBSellers
            // 
            this.cBSellers.FormattingEnabled = true;
            this.cBSellers.Location = new System.Drawing.Point(24, 47);
            this.cBSellers.Name = "cBSellers";
            this.cBSellers.Size = new System.Drawing.Size(243, 21);
            this.cBSellers.TabIndex = 0;
            this.cBSellers.SelectedIndexChanged += new System.EventHandler(this.cBSellers_SelectedIndexChanged);
            // 
            // Types
            // 
            this.Types.Location = new System.Drawing.Point(4, 22);
            this.Types.Name = "Types";
            this.Types.Size = new System.Drawing.Size(767, 399);
            this.Types.TabIndex = 2;
            this.Types.Text = "Типы продуктов";
            this.Types.UseVisualStyleBackColor = true;
            // 
            // History
            // 
            this.History.Controls.Add(this.label4);
            this.History.Controls.Add(this.label3);
            this.History.Controls.Add(this.nMin);
            this.History.Controls.Add(this.clearFilters);
            this.History.Controls.Add(this.butNow);
            this.History.Controls.Add(this.lBLogs);
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(767, 399);
            this.History.TabIndex = 3;
            this.History.Text = "История";
            this.History.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(437, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "минут";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "За последние";
            // 
            // nMin
            // 
            this.nMin.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nMin.Location = new System.Drawing.Point(346, 24);
            this.nMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nMin.Name = "nMin";
            this.nMin.Size = new System.Drawing.Size(85, 20);
            this.nMin.TabIndex = 3;
            this.nMin.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // clearFilters
            // 
            this.clearFilters.Location = new System.Drawing.Point(518, 19);
            this.clearFilters.Name = "clearFilters";
            this.clearFilters.Size = new System.Drawing.Size(201, 26);
            this.clearFilters.TabIndex = 2;
            this.clearFilters.Text = "Показать все";
            this.clearFilters.UseVisualStyleBackColor = true;
            this.clearFilters.Click += new System.EventHandler(this.clearFilters_Click);
            // 
            // butNow
            // 
            this.butNow.Location = new System.Drawing.Point(32, 19);
            this.butNow.Name = "butNow";
            this.butNow.Size = new System.Drawing.Size(194, 26);
            this.butNow.TabIndex = 1;
            this.butNow.Text = "Сегодня";
            this.butNow.UseVisualStyleBackColor = true;
            this.butNow.Click += new System.EventHandler(this.butNow_Click);
            // 
            // lBLogs
            // 
            this.lBLogs.FormattingEnabled = true;
            this.lBLogs.Location = new System.Drawing.Point(32, 59);
            this.lBLogs.Name = "lBLogs";
            this.lBLogs.Size = new System.Drawing.Size(687, 316);
            this.lBLogs.TabIndex = 0;
            this.lBLogs.SelectedIndexChanged += new System.EventHandler(this.lBLogs_SelectedIndexChanged);
            // 
            // fBDialog
            // 
            this.fBDialog.Description = "Выберите папку для сохранения сформированных документов";
            // 
            // butExport
            // 
            this.butExport.Location = new System.Drawing.Point(387, 354);
            this.butExport.Name = "butExport";
            this.butExport.Size = new System.Drawing.Size(164, 27);
            this.butExport.TabIndex = 7;
            this.butExport.Text = "Экспорт";
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.butExport_Click);
            // 
            // butImport
            // 
            this.butImport.Location = new System.Drawing.Point(581, 354);
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(164, 27);
            this.butImport.TabIndex = 8;
            this.butImport.Text = "Импорт";
            this.butImport.UseVisualStyleBackColor = true;
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tControl);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tControl.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.Providers.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.History.ResumeLayout(false);
            this.History.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tControl;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage Providers;
        private System.Windows.Forms.TabPage Types;
        private System.Windows.Forms.TabPage History;
        private System.Windows.Forms.TextBox tBDirectoryPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butDir;
        private System.Windows.Forms.FolderBrowserDialog fBDialog;
        private System.Windows.Forms.ListBox lBLogs;
        private System.Windows.Forms.Button butPathHistory;
        private System.Windows.Forms.TextBox tBPathHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butNow;
        private System.Windows.Forms.Button clearFilters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nMin;
        private System.Windows.Forms.Button butNewMonth;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tBNameCompanyFull;
        private System.Windows.Forms.TextBox tBNameSellerSpec;
        private System.Windows.Forms.TextBox tBNameSeller;
        private System.Windows.Forms.TextBox tBBank;
        private System.Windows.Forms.TextBox tBCorespAccount;
        private System.Windows.Forms.TextBox tBBankAccount;
        private System.Windows.Forms.TextBox tBPersonalAccount;
        private System.Windows.Forms.TextBox tBPhone;
        private System.Windows.Forms.TextBox tBEmail;
        private System.Windows.Forms.TextBox tBAddress;
        private System.Windows.Forms.TextBox tBOGRN;
        private System.Windows.Forms.TextBox tBKPP;
        private System.Windows.Forms.TextBox tBBIK;
        private System.Windows.Forms.TextBox tBINN;
        private System.Windows.Forms.TextBox tBNameCompany;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBSellers;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.TextBox tBRangSeller;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button butExport;
        private System.Windows.Forms.Button butImport;
    }
}