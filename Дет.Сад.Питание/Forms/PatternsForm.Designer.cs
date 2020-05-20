namespace Дет.Сад.Питание.Forms
{
    partial class PatternsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatternsForm));
            this.lBPatterns = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butDel = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.lBZ = new System.Windows.Forms.ListBox();
            this.lBO = new System.Windows.Forms.ListBox();
            this.lBP = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.butAddZ = new System.Windows.Forms.Button();
            this.butDelZ = new System.Windows.Forms.Button();
            this.butAddO = new System.Windows.Forms.Button();
            this.butDelO = new System.Windows.Forms.Button();
            this.butAddP = new System.Windows.Forms.Button();
            this.butDelP = new System.Windows.Forms.Button();
            this.cLBDishes = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBName = new System.Windows.Forms.TextBox();
            this.butSave = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lBPatterns
            // 
            this.lBPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lBPatterns.FormattingEnabled = true;
            this.lBPatterns.Location = new System.Drawing.Point(10, 28);
            this.lBPatterns.Name = "lBPatterns";
            this.lBPatterns.Size = new System.Drawing.Size(176, 342);
            this.lBPatterns.TabIndex = 0;
            this.lBPatterns.SelectedIndexChanged += new System.EventHandler(this.LBPatterns_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вврианты меню:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butDel);
            this.panel1.Controls.Add(this.butNew);
            this.panel1.Controls.Add(this.lBPatterns);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 450);
            this.panel1.TabIndex = 2;
            // 
            // butDel
            // 
            this.butDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDel.BackColor = System.Drawing.Color.Tomato;
            this.butDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDel.Location = new System.Drawing.Point(10, 412);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(176, 26);
            this.butDel.TabIndex = 44;
            this.butDel.Text = "Удалить вариант из списка";
            this.butDel.UseVisualStyleBackColor = false;
            this.butDel.Click += new System.EventHandler(this.ButDel_Click);
            // 
            // butNew
            // 
            this.butNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butNew.BackColor = System.Drawing.Color.LimeGreen;
            this.butNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNew.Location = new System.Drawing.Point(10, 379);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(176, 26);
            this.butNew.TabIndex = 43;
            this.butNew.Text = "Создать новый вариант";
            this.butNew.UseVisualStyleBackColor = false;
            this.butNew.Click += new System.EventHandler(this.ButNew_Click);
            // 
            // lBZ
            // 
            this.lBZ.FormattingEnabled = true;
            this.lBZ.Location = new System.Drawing.Point(214, 39);
            this.lBZ.Name = "lBZ";
            this.lBZ.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lBZ.Size = new System.Drawing.Size(178, 95);
            this.lBZ.TabIndex = 3;
            // 
            // lBO
            // 
            this.lBO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lBO.FormattingEnabled = true;
            this.lBO.Location = new System.Drawing.Point(409, 39);
            this.lBO.Name = "lBO";
            this.lBO.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lBO.Size = new System.Drawing.Size(178, 95);
            this.lBO.TabIndex = 4;
            // 
            // lBP
            // 
            this.lBP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lBP.FormattingEnabled = true;
            this.lBP.Location = new System.Drawing.Point(606, 39);
            this.lBP.Name = "lBP";
            this.lBP.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lBP.Size = new System.Drawing.Size(178, 95);
            this.lBP.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(638, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 24);
            this.label11.TabIndex = 41;
            this.label11.Text = "ПОЛДНИК";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(247, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 24);
            this.label5.TabIndex = 39;
            this.label5.Text = "ЗАВТРАК";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(409, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 24);
            this.label10.TabIndex = 40;
            this.label10.Text = "ОБЕД";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butAddZ
            // 
            this.butAddZ.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddZ.Location = new System.Drawing.Point(214, 152);
            this.butAddZ.Name = "butAddZ";
            this.butAddZ.Size = new System.Drawing.Size(75, 23);
            this.butAddZ.TabIndex = 42;
            this.butAddZ.Text = "Добавить";
            this.butAddZ.UseVisualStyleBackColor = false;
            this.butAddZ.Click += new System.EventHandler(this.ButAddZ_Click);
            // 
            // butDelZ
            // 
            this.butDelZ.BackColor = System.Drawing.Color.Tomato;
            this.butDelZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelZ.Location = new System.Drawing.Point(317, 152);
            this.butDelZ.Name = "butDelZ";
            this.butDelZ.Size = new System.Drawing.Size(75, 23);
            this.butDelZ.TabIndex = 43;
            this.butDelZ.Text = "Убрать";
            this.butDelZ.UseVisualStyleBackColor = false;
            this.butDelZ.Click += new System.EventHandler(this.ButDelZ_Click);
            // 
            // butAddO
            // 
            this.butAddO.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddO.Location = new System.Drawing.Point(409, 152);
            this.butAddO.Name = "butAddO";
            this.butAddO.Size = new System.Drawing.Size(75, 23);
            this.butAddO.TabIndex = 44;
            this.butAddO.Text = "Добавить";
            this.butAddO.UseVisualStyleBackColor = false;
            this.butAddO.Click += new System.EventHandler(this.ButAddO_Click);
            // 
            // butDelO
            // 
            this.butDelO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDelO.BackColor = System.Drawing.Color.Tomato;
            this.butDelO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelO.Location = new System.Drawing.Point(512, 152);
            this.butDelO.Name = "butDelO";
            this.butDelO.Size = new System.Drawing.Size(75, 23);
            this.butDelO.TabIndex = 45;
            this.butDelO.Text = "Убрать";
            this.butDelO.UseVisualStyleBackColor = false;
            this.butDelO.Click += new System.EventHandler(this.ButDelO_Click);
            // 
            // butAddP
            // 
            this.butAddP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddP.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddP.Location = new System.Drawing.Point(606, 152);
            this.butAddP.Name = "butAddP";
            this.butAddP.Size = new System.Drawing.Size(75, 23);
            this.butAddP.TabIndex = 46;
            this.butAddP.Text = "Добавить";
            this.butAddP.UseVisualStyleBackColor = false;
            this.butAddP.Click += new System.EventHandler(this.ButAddP_Click);
            // 
            // butDelP
            // 
            this.butDelP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDelP.BackColor = System.Drawing.Color.Tomato;
            this.butDelP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelP.Location = new System.Drawing.Point(709, 152);
            this.butDelP.Name = "butDelP";
            this.butDelP.Size = new System.Drawing.Size(75, 23);
            this.butDelP.TabIndex = 47;
            this.butDelP.Text = "Убрать";
            this.butDelP.UseVisualStyleBackColor = false;
            this.butDelP.Click += new System.EventHandler(this.ButDelP_Click);
            // 
            // cLBDishes
            // 
            this.cLBDishes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cLBDishes.FormattingEnabled = true;
            this.cLBDishes.Location = new System.Drawing.Point(214, 201);
            this.cLBDishes.MultiColumn = true;
            this.cLBDishes.Name = "cLBDishes";
            this.cLBDishes.Size = new System.Drawing.Size(484, 169);
            this.cLBDishes.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Выберите блюда из списка:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Наименование варианта меню:";
            // 
            // tBName
            // 
            this.tBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBName.Location = new System.Drawing.Point(214, 409);
            this.tBName.Name = "tBName";
            this.tBName.Size = new System.Drawing.Size(316, 20);
            this.tBName.TabIndex = 51;
            // 
            // butSave
            // 
            this.butSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSave.BackColor = System.Drawing.Color.MediumBlue;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSave.Location = new System.Drawing.Point(546, 393);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(238, 41);
            this.butSave.TabIndex = 52;
            this.butSave.Text = "Сохранить вариант меню";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // butClear
            // 
            this.butClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butClear.BackColor = System.Drawing.Color.MediumPurple;
            this.butClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butClear.Location = new System.Drawing.Point(709, 201);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(75, 169);
            this.butClear.TabIndex = 53;
            this.butClear.Text = "Убрать все галочки";
            this.butClear.UseVisualStyleBackColor = false;
            this.butClear.Click += new System.EventHandler(this.ButClear_Click);
            // 
            // PatternsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.tBName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cLBDishes);
            this.Controls.Add(this.butDelP);
            this.Controls.Add(this.butAddP);
            this.Controls.Add(this.butDelO);
            this.Controls.Add(this.butAddO);
            this.Controls.Add(this.butDelZ);
            this.Controls.Add(this.butAddZ);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lBP);
            this.Controls.Add(this.lBO);
            this.Controls.Add(this.lBZ);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "PatternsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Варианты меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PatternsForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lBPatterns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lBZ;
        private System.Windows.Forms.ListBox lBO;
        private System.Windows.Forms.ListBox lBP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button butAddZ;
        private System.Windows.Forms.Button butDelZ;
        private System.Windows.Forms.Button butAddO;
        private System.Windows.Forms.Button butDelO;
        private System.Windows.Forms.Button butAddP;
        private System.Windows.Forms.Button butDelP;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.CheckedListBox cLBDishes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBName;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butClear;
    }
}