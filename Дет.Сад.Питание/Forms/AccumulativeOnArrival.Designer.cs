namespace Дет.Сад.Питание.Forms
{
    partial class AccumulativeOnArrival
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccumulativeOnArrival));
            this.label1 = new System.Windows.Forms.Label();
            this.dGVProducts = new System.Windows.Forms.DataGridView();
            this.NameProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNakl = new System.Windows.Forms.Panel();
            this.tBInvoice = new System.Windows.Forms.TextBox();
            this.tBGruzName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBPriemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dTPData = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cLBContracts = new System.Windows.Forms.CheckedListBox();
            this.cLBDeliveryNotes = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pAccumulate = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dGVProductsAll = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butDirectory = new System.Windows.Forms.Button();
            this.butBuild = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cBCustomer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cBMount = new System.Windows.Forms.ComboBox();
            this.cBYear = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).BeginInit();
            this.pNakl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pAccumulate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductsAll)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите нужные накладные:";
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
            this.Sum});
            this.dGVProducts.Location = new System.Drawing.Point(9, 115);
            this.dGVProducts.Margin = new System.Windows.Forms.Padding(2);
            this.dGVProducts.Name = "dGVProducts";
            this.dGVProducts.ReadOnly = true;
            this.dGVProducts.Size = new System.Drawing.Size(379, 467);
            this.dGVProducts.TabIndex = 0;
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
            // pNakl
            // 
            this.pNakl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pNakl.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pNakl.Controls.Add(this.tBInvoice);
            this.pNakl.Controls.Add(this.dGVProducts);
            this.pNakl.Controls.Add(this.tBGruzName);
            this.pNakl.Controls.Add(this.label5);
            this.pNakl.Controls.Add(this.tBPriemName);
            this.pNakl.Controls.Add(this.label4);
            this.pNakl.Controls.Add(this.tBNumber);
            this.pNakl.Controls.Add(this.label3);
            this.pNakl.Controls.Add(this.dTPData);
            this.pNakl.Controls.Add(this.label8);
            this.pNakl.Controls.Add(this.label7);
            this.pNakl.Enabled = false;
            this.pNakl.Location = new System.Drawing.Point(206, 11);
            this.pNakl.Margin = new System.Windows.Forms.Padding(2);
            this.pNakl.Name = "pNakl";
            this.pNakl.Size = new System.Drawing.Size(395, 590);
            this.pNakl.TabIndex = 27;
            // 
            // tBInvoice
            // 
            this.tBInvoice.Location = new System.Drawing.Point(9, 57);
            this.tBInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.tBInvoice.Name = "tBInvoice";
            this.tBInvoice.Size = new System.Drawing.Size(171, 20);
            this.tBInvoice.TabIndex = 49;
            // 
            // tBGruzName
            // 
            this.tBGruzName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBGruzName.Location = new System.Drawing.Point(204, 20);
            this.tBGruzName.Margin = new System.Windows.Forms.Padding(2);
            this.tBGruzName.Name = "tBGruzName";
            this.tBGruzName.Size = new System.Drawing.Size(184, 20);
            this.tBGruzName.TabIndex = 48;
            this.tBGruzName.Text = "Абдрахманова Е.А.";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Груз принял:";
            // 
            // tBPriemName
            // 
            this.tBPriemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBPriemName.Location = new System.Drawing.Point(204, 54);
            this.tBPriemName.Margin = new System.Windows.Forms.Padding(2);
            this.tBPriemName.Name = "tBPriemName";
            this.tBPriemName.Size = new System.Drawing.Size(184, 20);
            this.tBPriemName.TabIndex = 46;
            this.tBPriemName.Text = "Абдрахманова Е.А.";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Кому выдана:";
            // 
            // tBNumber
            // 
            this.tBNumber.Location = new System.Drawing.Point(9, 20);
            this.tBNumber.Margin = new System.Windows.Forms.Padding(2);
            this.tBNumber.Name = "tBNumber";
            this.tBNumber.Size = new System.Drawing.Size(171, 20);
            this.tBNumber.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Номер накладной:";
            // 
            // dTPData
            // 
            this.dTPData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dTPData.Location = new System.Drawing.Point(9, 91);
            this.dTPData.Margin = new System.Windows.Forms.Padding(2);
            this.dTPData.Name = "dTPData";
            this.dTPData.Size = new System.Drawing.Size(379, 20);
            this.dTPData.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 79);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Дата создания:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "По счёт-фактуре:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cLBContracts);
            this.panel1.Controls.Add(this.cLBDeliveryNotes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 612);
            this.panel1.TabIndex = 28;
            // 
            // cLBContracts
            // 
            this.cLBContracts.FormattingEnabled = true;
            this.cLBContracts.Location = new System.Drawing.Point(10, 25);
            this.cLBContracts.Name = "cLBContracts";
            this.cLBContracts.Size = new System.Drawing.Size(182, 139);
            this.cLBContracts.TabIndex = 53;
            this.cLBContracts.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLBContracts_ItemCheck);
            // 
            // cLBDeliveryNotes
            // 
            this.cLBDeliveryNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cLBDeliveryNotes.FormattingEnabled = true;
            this.cLBDeliveryNotes.Location = new System.Drawing.Point(10, 199);
            this.cLBDeliveryNotes.Name = "cLBDeliveryNotes";
            this.cLBDeliveryNotes.Size = new System.Drawing.Size(182, 394);
            this.cLBDeliveryNotes.TabIndex = 52;
            this.cLBDeliveryNotes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLBDeliveryNotes_ItemCheck);
            this.cLBDeliveryNotes.SelectedIndexChanged += new System.EventHandler(this.CLBDeliveryNotes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Выберите договор:";
            // 
            // pAccumulate
            // 
            this.pAccumulate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pAccumulate.Controls.Add(this.label6);
            this.pAccumulate.Controls.Add(this.dGVProductsAll);
            this.pAccumulate.Enabled = false;
            this.pAccumulate.Location = new System.Drawing.Point(606, 0);
            this.pAccumulate.Name = "pAccumulate";
            this.pAccumulate.Size = new System.Drawing.Size(374, 485);
            this.pAccumulate.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Общий состав накопительной:";
            // 
            // dGVProductsAll
            // 
            this.dGVProductsAll.AllowUserToAddRows = false;
            this.dGVProductsAll.AllowUserToDeleteRows = false;
            this.dGVProductsAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVProductsAll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dGVProductsAll.BackgroundColor = System.Drawing.Color.Black;
            this.dGVProductsAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVProductsAll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dGVProductsAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProductsAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dGVProductsAll.Location = new System.Drawing.Point(15, 31);
            this.dGVProductsAll.Margin = new System.Windows.Forms.Padding(2);
            this.dGVProductsAll.Name = "dGVProductsAll";
            this.dGVProductsAll.ReadOnly = true;
            this.dGVProductsAll.Size = new System.Drawing.Size(345, 440);
            this.dGVProductsAll.TabIndex = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 108;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn2.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 58;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn3.HeaderText = "Количество";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 91;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn4.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 66;
            // 
            // butDirectory
            // 
            this.butDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDirectory.BackColor = System.Drawing.Color.DarkViolet;
            this.butDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDirectory.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butDirectory.Location = new System.Drawing.Point(806, 556);
            this.butDirectory.Name = "butDirectory";
            this.butDirectory.Size = new System.Drawing.Size(162, 37);
            this.butDirectory.TabIndex = 52;
            this.butDirectory.Text = "Открыть папку с документом";
            this.butDirectory.UseVisualStyleBackColor = false;
            this.butDirectory.Click += new System.EventHandler(this.ButDirectory_Click);
            // 
            // butBuild
            // 
            this.butBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBuild.BackColor = System.Drawing.Color.LimeGreen;
            this.butBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBuild.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butBuild.Location = new System.Drawing.Point(620, 556);
            this.butBuild.Name = "butBuild";
            this.butBuild.Size = new System.Drawing.Size(173, 37);
            this.butBuild.TabIndex = 51;
            this.butBuild.Text = "Сформировать документ";
            this.butBuild.UseVisualStyleBackColor = false;
            this.butBuild.Click += new System.EventHandler(this.ButBuild_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(618, 499);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Выберите получателя:";
            // 
            // cBCustomer
            // 
            this.cBCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cBCustomer.FormattingEnabled = true;
            this.cBCustomer.Location = new System.Drawing.Point(621, 516);
            this.cBCustomer.Name = "cBCustomer";
            this.cBCustomer.Size = new System.Drawing.Size(172, 21);
            this.cBCustomer.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(803, 499);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "Выберите дату составления:";
            // 
            // cBMount
            // 
            this.cBMount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cBMount.FormattingEnabled = true;
            this.cBMount.Location = new System.Drawing.Point(806, 516);
            this.cBMount.Name = "cBMount";
            this.cBMount.Size = new System.Drawing.Size(97, 21);
            this.cBMount.TabIndex = 54;
            // 
            // cBYear
            // 
            this.cBYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cBYear.FormattingEnabled = true;
            this.cBYear.Location = new System.Drawing.Point(909, 516);
            this.cBYear.Name = "cBYear";
            this.cBYear.Size = new System.Drawing.Size(57, 21);
            this.cBYear.TabIndex = 55;
            // 
            // AccumulativeOnArrival
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(980, 612);
            this.Controls.Add(this.cBYear);
            this.Controls.Add(this.cBMount);
            this.Controls.Add(this.butDirectory);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cBCustomer);
            this.Controls.Add(this.butBuild);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pAccumulate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pNakl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(996, 651);
            this.Name = "AccumulativeOnArrival";
            this.Text = "Накопительные по приходу";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccumulativeOnArrival_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProducts)).EndInit();
            this.pNakl.ResumeLayout(false);
            this.pNakl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pAccumulate.ResumeLayout(false);
            this.pAccumulate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductsAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGVProducts;
        private System.Windows.Forms.Panel pNakl;
        private System.Windows.Forms.TextBox tBInvoice;
        private System.Windows.Forms.TextBox tBGruzName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBPriemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dTPData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cLBDeliveryNotes;
        private System.Windows.Forms.Panel pAccumulate;
        private System.Windows.Forms.DataGridView dGVProductsAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butDirectory;
        private System.Windows.Forms.Button butBuild;
        private System.Windows.Forms.CheckedListBox cLBContracts;
        private System.Windows.Forms.ComboBox cBCustomer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cBMount;
        private System.Windows.Forms.ComboBox cBYear;
    }
}