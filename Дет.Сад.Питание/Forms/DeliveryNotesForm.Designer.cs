namespace Дет.Сад.Питание.Forms
{
    partial class DeliveryNotesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryNotesForm));
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
            this.pData = new System.Windows.Forms.Panel();
            this.tBGruzName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBPriemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBInvoices = new System.Windows.Forms.ComboBox();
            this.dTPData = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lDeliveryNote = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pDeliveryNotes = new System.Windows.Forms.Panel();
            this.lLoad = new System.Windows.Forms.Label();
            this.butOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lBDeliveryNotes = new System.Windows.Forms.ListBox();
            this.butBuild = new System.Windows.Forms.Button();
            this.butDirectory = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.butAddDeliveryNote = new System.Windows.Forms.Button();
            this.pCheckDoc = new System.Windows.Forms.Panel();
            this.lCheckDoc = new System.Windows.Forms.Label();
            this.pProducts.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).BeginInit();
            this.pData.SuspendLayout();
            this.pDeliveryNotes.SuspendLayout();
            this.pCheckDoc.SuspendLayout();
            this.SuspendLayout();
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
            this.pProducts.Location = new System.Drawing.Point(10, 144);
            this.pProducts.Margin = new System.Windows.Forms.Padding(2);
            this.pProducts.Name = "pProducts";
            this.pProducts.Size = new System.Drawing.Size(689, 336);
            this.pProducts.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lSumm);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Location = new System.Drawing.Point(10, 303);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(665, 27);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // lSumm
            // 
            this.lSumm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lSumm.BackColor = System.Drawing.Color.White;
            this.lSumm.ForeColor = System.Drawing.Color.Black;
            this.lSumm.Location = new System.Drawing.Point(242, 11);
            this.lSumm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lSumm.Name = "lSumm";
            this.lSumm.Size = new System.Drawing.Size(418, 10);
            this.lSumm.TabIndex = 4;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(3, 11);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(94, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Итоговая сумма:";
            // 
            // butCleanProducts
            // 
            this.butCleanProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCleanProducts.BackColor = System.Drawing.Color.Tomato;
            this.butCleanProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCleanProducts.Location = new System.Drawing.Point(608, 260);
            this.butCleanProducts.Margin = new System.Windows.Forms.Padding(2);
            this.butCleanProducts.Name = "butCleanProducts";
            this.butCleanProducts.Size = new System.Drawing.Size(68, 38);
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
            this.butAddProduct.Location = new System.Drawing.Point(607, 10);
            this.butAddProduct.Margin = new System.Windows.Forms.Padding(2);
            this.butAddProduct.Name = "butAddProduct";
            this.butAddProduct.Size = new System.Drawing.Size(68, 39);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dGVProducts.Location = new System.Drawing.Point(10, 10);
            this.dGVProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dGVProducts.Name = "dGVProducts";
            this.dGVProducts.ReadOnly = true;
            this.dGVProducts.Size = new System.Drawing.Size(580, 289);
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
            this.NameProduct.Width = 108;
            // 
            // Price
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 58;
            // 
            // Balance
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle4;
            this.Balance.HeaderText = "Количество";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            this.Balance.Width = 91;
            // 
            // Sum
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.Sum.DefaultCellStyle = dataGridViewCellStyle5;
            this.Sum.HeaderText = "Сумма";
            this.Sum.Name = "Sum";
            this.Sum.ReadOnly = true;
            this.Sum.Width = 66;
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
            // pData
            // 
            this.pData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pData.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pData.Controls.Add(this.tBGruzName);
            this.pData.Controls.Add(this.label5);
            this.pData.Controls.Add(this.tBPriemName);
            this.pData.Controls.Add(this.label4);
            this.pData.Controls.Add(this.tBNumber);
            this.pData.Controls.Add(this.label3);
            this.pData.Controls.Add(this.cBInvoices);
            this.pData.Controls.Add(this.dTPData);
            this.pData.Controls.Add(this.label8);
            this.pData.Controls.Add(this.label7);
            this.pData.Location = new System.Drawing.Point(10, 48);
            this.pData.Margin = new System.Windows.Forms.Padding(2);
            this.pData.Name = "pData";
            this.pData.Size = new System.Drawing.Size(689, 92);
            this.pData.TabIndex = 25;
            // 
            // tBGruzName
            // 
            this.tBGruzName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBGruzName.Location = new System.Drawing.Point(234, 60);
            this.tBGruzName.Margin = new System.Windows.Forms.Padding(2);
            this.tBGruzName.Name = "tBGruzName";
            this.tBGruzName.Size = new System.Drawing.Size(240, 20);
            this.tBGruzName.TabIndex = 48;
            this.tBGruzName.Text = "Абдрахманова Е.А.";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Груз принял:";
            // 
            // tBPriemName
            // 
            this.tBPriemName.Location = new System.Drawing.Point(11, 60);
            this.tBPriemName.Margin = new System.Windows.Forms.Padding(2);
            this.tBPriemName.Name = "tBPriemName";
            this.tBPriemName.Size = new System.Drawing.Size(161, 20);
            this.tBPriemName.TabIndex = 46;
            this.tBPriemName.Text = "Абдрахманова Е.А.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Кому выдана:";
            // 
            // tBNumber
            // 
            this.tBNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBNumber.Location = new System.Drawing.Point(522, 21);
            this.tBNumber.Margin = new System.Windows.Forms.Padding(2);
            this.tBNumber.Name = "tBNumber";
            this.tBNumber.Size = new System.Drawing.Size(153, 20);
            this.tBNumber.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Номер накладной:";
            // 
            // cBInvoices
            // 
            this.cBInvoices.FormattingEnabled = true;
            this.cBInvoices.Location = new System.Drawing.Point(10, 21);
            this.cBInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.cBInvoices.Name = "cBInvoices";
            this.cBInvoices.Size = new System.Drawing.Size(162, 21);
            this.cBInvoices.TabIndex = 42;
            // 
            // dTPData
            // 
            this.dTPData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dTPData.Location = new System.Drawing.Point(234, 21);
            this.dTPData.Margin = new System.Windows.Forms.Padding(2);
            this.dTPData.Name = "dTPData";
            this.dTPData.Size = new System.Drawing.Size(240, 20);
            this.dTPData.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Дата создания:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Выберите счёт-фактуру:";
            // 
            // lDeliveryNote
            // 
            this.lDeliveryNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lDeliveryNote.AutoSize = true;
            this.lDeliveryNote.Enabled = false;
            this.lDeliveryNote.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lDeliveryNote.Location = new System.Drawing.Point(136, 17);
            this.lDeliveryNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lDeliveryNote.Name = "lDeliveryNote";
            this.lDeliveryNote.Size = new System.Drawing.Size(96, 13);
            this.lDeliveryNote.TabIndex = 21;
            this.lDeliveryNote.Text = "Новая накладная";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Выбранная накладная:";
            // 
            // pDeliveryNotes
            // 
            this.pDeliveryNotes.BackColor = System.Drawing.SystemColors.GrayText;
            this.pDeliveryNotes.Controls.Add(this.pCheckDoc);
            this.pDeliveryNotes.Controls.Add(this.lLoad);
            this.pDeliveryNotes.Controls.Add(this.butOpen);
            this.pDeliveryNotes.Controls.Add(this.label1);
            this.pDeliveryNotes.Controls.Add(this.lBDeliveryNotes);
            this.pDeliveryNotes.Controls.Add(this.butBuild);
            this.pDeliveryNotes.Controls.Add(this.butDirectory);
            this.pDeliveryNotes.Controls.Add(this.butDel);
            this.pDeliveryNotes.Dock = System.Windows.Forms.DockStyle.Right;
            this.pDeliveryNotes.Enabled = false;
            this.pDeliveryNotes.Location = new System.Drawing.Point(703, 0);
            this.pDeliveryNotes.Margin = new System.Windows.Forms.Padding(2);
            this.pDeliveryNotes.Name = "pDeliveryNotes";
            this.pDeliveryNotes.Size = new System.Drawing.Size(222, 490);
            this.pDeliveryNotes.TabIndex = 22;
            // 
            // lLoad
            // 
            this.lLoad.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lLoad.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLoad.ForeColor = System.Drawing.Color.Black;
            this.lLoad.Location = new System.Drawing.Point(14, 144);
            this.lLoad.Name = "lLoad";
            this.lLoad.Size = new System.Drawing.Size(196, 56);
            this.lLoad.TabIndex = 16;
            this.lLoad.Text = "Загрузка ...";
            this.lLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lLoad.Visible = false;
            // 
            // butOpen
            // 
            this.butOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpen.BackColor = System.Drawing.Color.LightSeaGreen;
            this.butOpen.Enabled = false;
            this.butOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOpen.Location = new System.Drawing.Point(124, 350);
            this.butOpen.Margin = new System.Windows.Forms.Padding(2);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(90, 40);
            this.butOpen.TabIndex = 14;
            this.butOpen.Text = "Открыть документ";
            this.butOpen.UseVisualStyleBackColor = false;
            this.butOpen.Click += new System.EventHandler(this.ButOpen_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите накладную:";
            // 
            // lBDeliveryNotes
            // 
            this.lBDeliveryNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lBDeliveryNotes.FormattingEnabled = true;
            this.lBDeliveryNotes.Location = new System.Drawing.Point(12, 22);
            this.lBDeliveryNotes.Margin = new System.Windows.Forms.Padding(2);
            this.lBDeliveryNotes.Name = "lBDeliveryNotes";
            this.lBDeliveryNotes.Size = new System.Drawing.Size(199, 290);
            this.lBDeliveryNotes.TabIndex = 0;
            this.lBDeliveryNotes.SelectedIndexChanged += new System.EventHandler(this.LBDeliveryNotes_SelectedIndexChanged);
            // 
            // butBuild
            // 
            this.butBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBuild.BackColor = System.Drawing.Color.LimeGreen;
            this.butBuild.Enabled = false;
            this.butBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBuild.Location = new System.Drawing.Point(15, 350);
            this.butBuild.Margin = new System.Windows.Forms.Padding(2);
            this.butBuild.Name = "butBuild";
            this.butBuild.Size = new System.Drawing.Size(95, 40);
            this.butBuild.TabIndex = 13;
            this.butBuild.Text = "Сформировать документ";
            this.butBuild.UseVisualStyleBackColor = false;
            this.butBuild.Click += new System.EventHandler(this.ButBuild_Click);
            // 
            // butDirectory
            // 
            this.butDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDirectory.BackColor = System.Drawing.Color.BlueViolet;
            this.butDirectory.Enabled = false;
            this.butDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDirectory.Location = new System.Drawing.Point(15, 434);
            this.butDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.butDirectory.Name = "butDirectory";
            this.butDirectory.Size = new System.Drawing.Size(199, 40);
            this.butDirectory.TabIndex = 2;
            this.butDirectory.Text = "Открыть папку с документом";
            this.butDirectory.UseVisualStyleBackColor = false;
            this.butDirectory.Click += new System.EventHandler(this.ButDirectory_Click);
            // 
            // butDel
            // 
            this.butDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDel.BackColor = System.Drawing.Color.Tomato;
            this.butDel.Enabled = false;
            this.butDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDel.Location = new System.Drawing.Point(15, 399);
            this.butDel.Margin = new System.Windows.Forms.Padding(2);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(199, 26);
            this.butDel.TabIndex = 12;
            this.butDel.Text = "Удалить накладную";
            this.butDel.UseVisualStyleBackColor = false;
            this.butDel.Click += new System.EventHandler(this.ButDel_Click);
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.BackColor = System.Drawing.Color.BlueViolet;
            this.butSave.Enabled = false;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butSave.Location = new System.Drawing.Point(549, 10);
            this.butSave.Margin = new System.Windows.Forms.Padding(4);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(150, 24);
            this.butSave.TabIndex = 24;
            this.butSave.Text = "Сохранить накладную";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // butAddDeliveryNote
            // 
            this.butAddDeliveryNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddDeliveryNote.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddDeliveryNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddDeliveryNote.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butAddDeliveryNote.Location = new System.Drawing.Point(369, 10);
            this.butAddDeliveryNote.Margin = new System.Windows.Forms.Padding(4);
            this.butAddDeliveryNote.Name = "butAddDeliveryNote";
            this.butAddDeliveryNote.Size = new System.Drawing.Size(172, 24);
            this.butAddDeliveryNote.TabIndex = 23;
            this.butAddDeliveryNote.Text = "Добавить новую накладную";
            this.butAddDeliveryNote.UseVisualStyleBackColor = false;
            this.butAddDeliveryNote.Click += new System.EventHandler(this.ButAddDeliveryNote_Click);
            // 
            // pCheckDoc
            // 
            this.pCheckDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pCheckDoc.BackColor = System.Drawing.Color.Transparent;
            this.pCheckDoc.Controls.Add(this.lCheckDoc);
            this.pCheckDoc.Location = new System.Drawing.Point(12, 322);
            this.pCheckDoc.Name = "pCheckDoc";
            this.pCheckDoc.Size = new System.Drawing.Size(199, 18);
            this.pCheckDoc.TabIndex = 20;
            this.pCheckDoc.Visible = false;
            // 
            // lCheckDoc
            // 
            this.lCheckDoc.AutoSize = true;
            this.lCheckDoc.ForeColor = System.Drawing.Color.White;
            this.lCheckDoc.Location = new System.Drawing.Point(40, 2);
            this.lCheckDoc.Name = "lCheckDoc";
            this.lCheckDoc.Size = new System.Drawing.Size(121, 13);
            this.lCheckDoc.TabIndex = 0;
            this.lCheckDoc.Text = "Документ отсутствует";
            // 
            // DeliveryNotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(925, 490);
            this.Controls.Add(this.pProducts);
            this.Controls.Add(this.pData);
            this.Controls.Add(this.lDeliveryNote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pDeliveryNotes);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butAddDeliveryNote);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(941, 529);
            this.Name = "DeliveryNotesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Накладные";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeliveryNotesForm_FormClosed);
            this.pProducts.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).EndInit();
            this.pData.ResumeLayout(false);
            this.pData.PerformLayout();
            this.pDeliveryNotes.ResumeLayout(false);
            this.pDeliveryNotes.PerformLayout();
            this.pCheckDoc.ResumeLayout(false);
            this.pCheckDoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pProducts;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lSumm;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button butCleanProducts;
        private System.Windows.Forms.Button butAddProduct;
        private System.Windows.Forms.DataGridView dGVProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Panel pData;
        private System.Windows.Forms.TextBox tBNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBInvoices;
        private System.Windows.Forms.DateTimePicker dTPData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lDeliveryNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pDeliveryNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lBDeliveryNotes;
        private System.Windows.Forms.Button butBuild;
        private System.Windows.Forms.Button butDirectory;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butAddDeliveryNote;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.TextBox tBGruzName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBPriemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lLoad;
        private System.Windows.Forms.Panel pCheckDoc;
        private System.Windows.Forms.Label lCheckDoc;
    }
}