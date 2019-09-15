namespace Дет.Сад.Питание.Forms
{
    partial class ContractsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContractsForm));
            this.lBContracts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butAddContract = new System.Windows.Forms.Button();
            this.pData = new System.Windows.Forms.Panel();
            this.dTPOkonch = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cBSeller = new System.Windows.Forms.ComboBox();
            this.cBCustomer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBChet = new System.Windows.Forms.RadioButton();
            this.rBPol = new System.Windows.Forms.RadioButton();
            this.dTPData = new System.Windows.Forms.DateTimePicker();
            this.tBOtv = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tBNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lContract = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butDirectory = new System.Windows.Forms.Button();
            this.pProducts = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lSumm = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.butCleanProducts = new System.Windows.Forms.Button();
            this.butAddProduct = new System.Windows.Forms.Button();
            this.dGVProducts = new System.Windows.Forms.DataGridView();
            this.NameProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.butDel = new System.Windows.Forms.Button();
            this.butBuild = new System.Windows.Forms.Button();
            this.pContracts = new System.Windows.Forms.Panel();
            this.butOpen = new System.Windows.Forms.Button();
            this.pData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pProducts.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).BeginInit();
            this.pContracts.SuspendLayout();
            this.SuspendLayout();
            // 
            // lBContracts
            // 
            this.lBContracts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lBContracts.FormattingEnabled = true;
            this.lBContracts.Location = new System.Drawing.Point(7, 30);
            this.lBContracts.Name = "lBContracts";
            this.lBContracts.Size = new System.Drawing.Size(206, 251);
            this.lBContracts.TabIndex = 0;
            this.lBContracts.SelectedIndexChanged += new System.EventHandler(this.LBContracts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите договор:";
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.BackColor = System.Drawing.Color.BlueViolet;
            this.butSave.Enabled = false;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butSave.Location = new System.Drawing.Point(516, 14);
            this.butSave.Margin = new System.Windows.Forms.Padding(5);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(148, 31);
            this.butSave.TabIndex = 8;
            this.butSave.Text = "Сохранить договор";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.ButSaveAndOpen_Click);
            // 
            // butAddContract
            // 
            this.butAddContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddContract.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddContract.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butAddContract.Location = new System.Drawing.Point(345, 14);
            this.butAddContract.Margin = new System.Windows.Forms.Padding(5);
            this.butAddContract.Name = "butAddContract";
            this.butAddContract.Size = new System.Drawing.Size(159, 31);
            this.butAddContract.TabIndex = 7;
            this.butAddContract.Text = "Добавить новый договор";
            this.butAddContract.UseVisualStyleBackColor = false;
            this.butAddContract.Click += new System.EventHandler(this.ButAddContract_Click);
            // 
            // pData
            // 
            this.pData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pData.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pData.Controls.Add(this.dTPOkonch);
            this.pData.Controls.Add(this.label5);
            this.pData.Controls.Add(this.cBSeller);
            this.pData.Controls.Add(this.cBCustomer);
            this.pData.Controls.Add(this.label4);
            this.pData.Controls.Add(this.label3);
            this.pData.Controls.Add(this.groupBox1);
            this.pData.Controls.Add(this.dTPData);
            this.pData.Controls.Add(this.tBOtv);
            this.pData.Controls.Add(this.label9);
            this.pData.Controls.Add(this.label8);
            this.pData.Controls.Add(this.tBNumber);
            this.pData.Controls.Add(this.label7);
            this.pData.Location = new System.Drawing.Point(15, 62);
            this.pData.Name = "pData";
            this.pData.Size = new System.Drawing.Size(649, 136);
            this.pData.TabIndex = 9;
            // 
            // dTPOkonch
            // 
            this.dTPOkonch.Location = new System.Drawing.Point(179, 65);
            this.dTPOkonch.Name = "dTPOkonch";
            this.dTPOkonch.Size = new System.Drawing.Size(146, 22);
            this.dTPOkonch.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Дата окончания:";
            // 
            // cBSeller
            // 
            this.cBSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBSeller.FormattingEnabled = true;
            this.cBSeller.Location = new System.Drawing.Point(339, 65);
            this.cBSeller.Name = "cBSeller";
            this.cBSeller.Size = new System.Drawing.Size(292, 21);
            this.cBSeller.TabIndex = 39;
            // 
            // cBCustomer
            // 
            this.cBCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBCustomer.FormattingEnabled = true;
            this.cBCustomer.Location = new System.Drawing.Point(339, 26);
            this.cBCustomer.Name = "cBCustomer";
            this.cBCustomer.Size = new System.Drawing.Size(292, 21);
            this.cBCustomer.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Продавец:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Получатель:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.rBChet);
            this.groupBox1.Controls.Add(this.rBPol);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(339, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 39);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Срок заключения:";
            // 
            // rBChet
            // 
            this.rBChet.AutoSize = true;
            this.rBChet.Location = new System.Drawing.Point(162, 16);
            this.rBChet.Name = "rBChet";
            this.rBChet.Size = new System.Drawing.Size(69, 17);
            this.rBChet.TabIndex = 1;
            this.rBChet.Text = "Квартал";
            this.rBChet.UseVisualStyleBackColor = true;
            // 
            // rBPol
            // 
            this.rBPol.AutoSize = true;
            this.rBPol.Checked = true;
            this.rBPol.Location = new System.Drawing.Point(8, 16);
            this.rBPol.Name = "rBPol";
            this.rBPol.Size = new System.Drawing.Size(72, 17);
            this.rBPol.TabIndex = 0;
            this.rBPol.TabStop = true;
            this.rBPol.Text = "Полгода";
            this.rBPol.UseVisualStyleBackColor = true;
            // 
            // dTPData
            // 
            this.dTPData.Location = new System.Drawing.Point(14, 64);
            this.dTPData.Name = "dTPData";
            this.dTPData.Size = new System.Drawing.Size(159, 22);
            this.dTPData.TabIndex = 32;
            // 
            // tBOtv
            // 
            this.tBOtv.Location = new System.Drawing.Point(14, 106);
            this.tBOtv.Name = "tBOtv";
            this.tBOtv.Size = new System.Drawing.Size(311, 22);
            this.tBOtv.TabIndex = 29;
            this.tBOtv.Text = "Абдрахманова Е.А.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Ответственный:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Дата заключения:";
            // 
            // tBNumber
            // 
            this.tBNumber.Location = new System.Drawing.Point(14, 26);
            this.tBNumber.Name = "tBNumber";
            this.tBNumber.Size = new System.Drawing.Size(311, 22);
            this.tBNumber.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Номер договора";
            // 
            // lContract
            // 
            this.lContract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lContract.AutoSize = true;
            this.lContract.Enabled = false;
            this.lContract.Location = new System.Drawing.Point(135, 32);
            this.lContract.Name = "lContract";
            this.lContract.Size = new System.Drawing.Size(93, 13);
            this.lContract.TabIndex = 3;
            this.lContract.Text = "Новый договор";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Текущий договор:";
            // 
            // butDirectory
            // 
            this.butDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDirectory.BackColor = System.Drawing.Color.BlueViolet;
            this.butDirectory.Enabled = false;
            this.butDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDirectory.Location = new System.Drawing.Point(6, 383);
            this.butDirectory.Name = "butDirectory";
            this.butDirectory.Size = new System.Drawing.Size(206, 24);
            this.butDirectory.TabIndex = 2;
            this.butDirectory.Text = "Открыть папку с документом";
            this.butDirectory.UseVisualStyleBackColor = false;
            this.butDirectory.Click += new System.EventHandler(this.ButDirectory_Click);
            // 
            // pProducts
            // 
            this.pProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pProducts.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pProducts.Controls.Add(this.groupBox2);
            this.pProducts.Controls.Add(this.butCleanProducts);
            this.pProducts.Controls.Add(this.butAddProduct);
            this.pProducts.Controls.Add(this.dGVProducts);
            this.pProducts.Location = new System.Drawing.Point(15, 204);
            this.pProducts.Name = "pProducts";
            this.pProducts.Size = new System.Drawing.Size(649, 203);
            this.pProducts.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lSumm);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Location = new System.Drawing.Point(13, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(617, 35);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // lSumm
            // 
            this.lSumm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lSumm.BackColor = System.Drawing.Color.White;
            this.lSumm.ForeColor = System.Drawing.Color.Black;
            this.lSumm.Location = new System.Drawing.Point(323, 14);
            this.lSumm.Name = "lSumm";
            this.lSumm.Size = new System.Drawing.Size(288, 13);
            this.lSumm.TabIndex = 4;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(4, 14);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(99, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Итоговая сумма:";
            // 
            // butCleanProducts
            // 
            this.butCleanProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCleanProducts.BackColor = System.Drawing.Color.Tomato;
            this.butCleanProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCleanProducts.Location = new System.Drawing.Point(540, 104);
            this.butCleanProducts.Name = "butCleanProducts";
            this.butCleanProducts.Size = new System.Drawing.Size(91, 50);
            this.butCleanProducts.TabIndex = 2;
            this.butCleanProducts.Text = "Очистить список";
            this.butCleanProducts.UseVisualStyleBackColor = false;
            this.butCleanProducts.Click += new System.EventHandler(this.ButCleanProducts_Click);
            // 
            // butAddProduct
            // 
            this.butAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddProduct.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddProduct.Location = new System.Drawing.Point(539, 13);
            this.butAddProduct.Name = "butAddProduct";
            this.butAddProduct.Size = new System.Drawing.Size(91, 51);
            this.butAddProduct.TabIndex = 1;
            this.butAddProduct.Text = "Добавить продукт";
            this.butAddProduct.UseVisualStyleBackColor = false;
            this.butAddProduct.Click += new System.EventHandler(this.ButAddProduct_Click);
            // 
            // dGVProducts
            // 
            this.dGVProducts.AllowUserToAddRows = false;
            this.dGVProducts.AllowUserToDeleteRows = false;
            this.dGVProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGVProducts.BackgroundColor = System.Drawing.Color.Black;
            this.dGVProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameProduct,
            this.Price,
            this.Balance,
            this.Sum,
            this.Delete});
            this.dGVProducts.Location = new System.Drawing.Point(14, 13);
            this.dGVProducts.Name = "dGVProducts";
            this.dGVProducts.ReadOnly = true;
            this.dGVProducts.Size = new System.Drawing.Size(504, 141);
            this.dGVProducts.TabIndex = 0;
            this.dGVProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVProducts_CellClick);
            this.dGVProducts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGVProducts_RowsAdded);
            this.dGVProducts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DGVProducts_RowsRemoved);
            // 
            // NameProduct
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.NameProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.NameProduct.HeaderText = "Наименование";
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.ReadOnly = true;
            this.NameProduct.Width = 114;
            // 
            // Price
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 60;
            // 
            // Balance
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle4;
            this.Balance.HeaderText = "Количество";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 96;
            // 
            // Sum
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.Sum.DefaultCellStyle = dataGridViewCellStyle5;
            this.Sum.HeaderText = "Сумма";
            this.Sum.Name = "Sum";
            this.Sum.ReadOnly = true;
            this.Sum.Width = 69;
            // 
            // Delete
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.Delete.DefaultCellStyle = dataGridViewCellStyle6;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 5;
            // 
            // butDel
            // 
            this.butDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDel.BackColor = System.Drawing.Color.Tomato;
            this.butDel.Enabled = false;
            this.butDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDel.Location = new System.Drawing.Point(6, 348);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(206, 24);
            this.butDel.TabIndex = 12;
            this.butDel.Text = "Удалить договор";
            this.butDel.UseVisualStyleBackColor = false;
            this.butDel.Click += new System.EventHandler(this.ButDel_Click);
            // 
            // butBuild
            // 
            this.butBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBuild.BackColor = System.Drawing.Color.LimeGreen;
            this.butBuild.Enabled = false;
            this.butBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBuild.Location = new System.Drawing.Point(6, 294);
            this.butBuild.Name = "butBuild";
            this.butBuild.Size = new System.Drawing.Size(101, 48);
            this.butBuild.TabIndex = 13;
            this.butBuild.Text = "Сформировать документ";
            this.butBuild.UseVisualStyleBackColor = false;
            this.butBuild.Click += new System.EventHandler(this.ButBuild_Click);
            // 
            // pContracts
            // 
            this.pContracts.BackColor = System.Drawing.SystemColors.GrayText;
            this.pContracts.Controls.Add(this.butOpen);
            this.pContracts.Controls.Add(this.label1);
            this.pContracts.Controls.Add(this.lBContracts);
            this.pContracts.Controls.Add(this.butBuild);
            this.pContracts.Controls.Add(this.butDirectory);
            this.pContracts.Controls.Add(this.butDel);
            this.pContracts.Dock = System.Windows.Forms.DockStyle.Right;
            this.pContracts.Enabled = false;
            this.pContracts.Location = new System.Drawing.Point(669, 0);
            this.pContracts.Name = "pContracts";
            this.pContracts.Size = new System.Drawing.Size(222, 421);
            this.pContracts.TabIndex = 14;
            // 
            // butOpen
            // 
            this.butOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpen.BackColor = System.Drawing.Color.LightSeaGreen;
            this.butOpen.Enabled = false;
            this.butOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOpen.Location = new System.Drawing.Point(113, 294);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(100, 48);
            this.butOpen.TabIndex = 14;
            this.butOpen.Text = "Открыть документ";
            this.butOpen.UseVisualStyleBackColor = false;
            this.butOpen.Click += new System.EventHandler(this.ButOpen_Click);
            // 
            // ContractsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(891, 421);
            this.Controls.Add(this.pContracts);
            this.Controls.Add(this.lContract);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pProducts);
            this.Controls.Add(this.pData);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butAddContract);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(907, 460);
            this.Name = "ContractsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Договора";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContractsForm_FormClosed);
            this.pData.ResumeLayout(false);
            this.pData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pProducts.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).EndInit();
            this.pContracts.ResumeLayout(false);
            this.pContracts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lBContracts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butAddContract;
        private System.Windows.Forms.Panel pData;
        private System.Windows.Forms.TextBox tBOtv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button butDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pProducts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBChet;
        private System.Windows.Forms.RadioButton rBPol;
        private System.Windows.Forms.DateTimePicker dTPData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dGVProducts;
        private System.Windows.Forms.Label lSumm;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button butCleanProducts;
        private System.Windows.Forms.Button butAddProduct;
        private System.Windows.Forms.ComboBox cBSeller;
        private System.Windows.Forms.ComboBox cBCustomer;
        private System.Windows.Forms.Label lContract;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butBuild;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Panel pContracts;
        private System.Windows.Forms.DateTimePicker dTPOkonch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butOpen;
    }
}