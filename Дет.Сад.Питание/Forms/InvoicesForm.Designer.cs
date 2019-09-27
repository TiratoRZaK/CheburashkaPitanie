namespace Дет.Сад.Питание.Forms
{
    partial class InvoicesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoicesForm));
            this.pInvoices = new System.Windows.Forms.Panel();
            this.butOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lBInvoices = new System.Windows.Forms.ListBox();
            this.butBuild = new System.Windows.Forms.Button();
            this.butDirectory = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.lInvoice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butAddInvoice = new System.Windows.Forms.Button();
            this.pData = new System.Windows.Forms.Panel();
            this.tBNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBContracts = new System.Windows.Forms.ComboBox();
            this.dTPData = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.lLoad = new System.Windows.Forms.Label();
            this.pInvoices.SuspendLayout();
            this.pData.SuspendLayout();
            this.pProducts.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // pInvoices
            // 
            this.pInvoices.BackColor = System.Drawing.SystemColors.GrayText;
            this.pInvoices.Controls.Add(this.lLoad);
            this.pInvoices.Controls.Add(this.butOpen);
            this.pInvoices.Controls.Add(this.label1);
            this.pInvoices.Controls.Add(this.lBInvoices);
            this.pInvoices.Controls.Add(this.butBuild);
            this.pInvoices.Controls.Add(this.butDirectory);
            this.pInvoices.Controls.Add(this.butDel);
            this.pInvoices.Dock = System.Windows.Forms.DockStyle.Right;
            this.pInvoices.Enabled = false;
            this.pInvoices.Location = new System.Drawing.Point(660, 0);
            this.pInvoices.Name = "pInvoices";
            this.pInvoices.Size = new System.Drawing.Size(219, 450);
            this.pInvoices.TabIndex = 15;
            // 
            // butOpen
            // 
            this.butOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOpen.BackColor = System.Drawing.Color.LightSeaGreen;
            this.butOpen.Enabled = false;
            this.butOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOpen.Location = new System.Drawing.Point(114, 323);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(88, 48);
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
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите счёт-фактуру:";
            // 
            // lBInvoices
            // 
            this.lBInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lBInvoices.FormattingEnabled = true;
            this.lBInvoices.Location = new System.Drawing.Point(14, 30);
            this.lBInvoices.Name = "lBInvoices";
            this.lBInvoices.Size = new System.Drawing.Size(189, 277);
            this.lBInvoices.TabIndex = 0;
            this.lBInvoices.SelectedIndexChanged += new System.EventHandler(this.LBInvoices_SelectedIndexChanged);
            // 
            // butBuild
            // 
            this.butBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBuild.BackColor = System.Drawing.Color.LimeGreen;
            this.butBuild.Enabled = false;
            this.butBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBuild.Location = new System.Drawing.Point(14, 323);
            this.butBuild.Name = "butBuild";
            this.butBuild.Size = new System.Drawing.Size(94, 48);
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
            this.butDirectory.Location = new System.Drawing.Point(14, 412);
            this.butDirectory.Name = "butDirectory";
            this.butDirectory.Size = new System.Drawing.Size(188, 24);
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
            this.butDel.Location = new System.Drawing.Point(14, 377);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(188, 24);
            this.butDel.TabIndex = 12;
            this.butDel.Text = "Удалить счёт-фактуру";
            this.butDel.UseVisualStyleBackColor = false;
            this.butDel.Click += new System.EventHandler(this.ButDel_Click);
            // 
            // lInvoice
            // 
            this.lInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lInvoice.AutoSize = true;
            this.lInvoice.Enabled = false;
            this.lInvoice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lInvoice.Location = new System.Drawing.Point(151, 21);
            this.lInvoice.Name = "lInvoice";
            this.lInvoice.Size = new System.Drawing.Size(109, 13);
            this.lInvoice.TabIndex = 15;
            this.lInvoice.Text = "Новая счёт-фактура";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(20, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Текущая счёт-фактура:";
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.BackColor = System.Drawing.Color.BlueViolet;
            this.butSave.Enabled = false;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butSave.Location = new System.Drawing.Point(518, 12);
            this.butSave.Margin = new System.Windows.Forms.Padding(5);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(121, 43);
            this.butSave.TabIndex = 17;
            this.butSave.Text = "Сохранить счёт-фактуру";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // butAddInvoice
            // 
            this.butAddInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddInvoice.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddInvoice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butAddInvoice.Location = new System.Drawing.Point(381, 12);
            this.butAddInvoice.Margin = new System.Windows.Forms.Padding(5);
            this.butAddInvoice.Name = "butAddInvoice";
            this.butAddInvoice.Size = new System.Drawing.Size(127, 43);
            this.butAddInvoice.TabIndex = 16;
            this.butAddInvoice.Text = "Добавить новую счёт-фактуру";
            this.butAddInvoice.UseVisualStyleBackColor = false;
            this.butAddInvoice.Click += new System.EventHandler(this.ButAddInvoice_Click);
            // 
            // pData
            // 
            this.pData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pData.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pData.Controls.Add(this.tBNumber);
            this.pData.Controls.Add(this.label3);
            this.pData.Controls.Add(this.cBContracts);
            this.pData.Controls.Add(this.dTPData);
            this.pData.Controls.Add(this.label8);
            this.pData.Controls.Add(this.label7);
            this.pData.Location = new System.Drawing.Point(23, 63);
            this.pData.Name = "pData";
            this.pData.Size = new System.Drawing.Size(616, 61);
            this.pData.TabIndex = 18;
            // 
            // tBNumber
            // 
            this.tBNumber.Location = new System.Drawing.Point(424, 28);
            this.tBNumber.Name = "tBNumber";
            this.tBNumber.Size = new System.Drawing.Size(174, 20);
            this.tBNumber.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Номер счёт-фактуры:";
            // 
            // cBContracts
            // 
            this.cBContracts.FormattingEnabled = true;
            this.cBContracts.Location = new System.Drawing.Point(13, 27);
            this.cBContracts.Name = "cBContracts";
            this.cBContracts.Size = new System.Drawing.Size(214, 21);
            this.cBContracts.TabIndex = 42;
            // 
            // dTPData
            // 
            this.dTPData.Location = new System.Drawing.Point(239, 28);
            this.dTPData.Name = "dTPData";
            this.dTPData.Size = new System.Drawing.Size(171, 20);
            this.dTPData.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Дата создания:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Выберите договор:";
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
            this.pProducts.Location = new System.Drawing.Point(23, 130);
            this.pProducts.Name = "pProducts";
            this.pProducts.Size = new System.Drawing.Size(616, 306);
            this.pProducts.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lSumm);
            this.groupBox2.Controls.Add(this.label);
            this.groupBox2.Location = new System.Drawing.Point(13, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 35);
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
            this.lSumm.Size = new System.Drawing.Size(255, 13);
            this.lSumm.TabIndex = 4;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(4, 14);
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
            this.butCleanProducts.Location = new System.Drawing.Point(507, 207);
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
            this.butAddProduct.Location = new System.Drawing.Point(506, 13);
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
            this.dGVProducts.Size = new System.Drawing.Size(471, 244);
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
            // lLoad
            // 
            this.lLoad.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lLoad.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLoad.ForeColor = System.Drawing.Color.Black;
            this.lLoad.Location = new System.Drawing.Point(15, 136);
            this.lLoad.Name = "lLoad";
            this.lLoad.Size = new System.Drawing.Size(187, 56);
            this.lLoad.TabIndex = 16;
            this.lLoad.Text = "Загрузка ...";
            this.lLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lLoad.Visible = false;
            // 
            // InvoicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.pProducts);
            this.Controls.Add(this.pData);
            this.Controls.Add(this.lInvoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pInvoices);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butAddInvoice);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(895, 489);
            this.Name = "InvoicesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Счёт-фактуры";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InvoicesForm_FormClosed);
            this.pInvoices.ResumeLayout(false);
            this.pInvoices.PerformLayout();
            this.pData.ResumeLayout(false);
            this.pData.PerformLayout();
            this.pProducts.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pInvoices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lBInvoices;
        private System.Windows.Forms.Button butBuild;
        private System.Windows.Forms.Button butDirectory;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Label lInvoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butAddInvoice;
        private System.Windows.Forms.Panel pData;
        private System.Windows.Forms.TextBox tBNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBContracts;
        private System.Windows.Forms.DateTimePicker dTPData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Label lLoad;
    }
}