namespace Дет.Сад.Питание.Forms
{
    partial class AccumulativeOnConsumption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccumulativeOnConsumption));
            this.clBMenus = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butCheckClear = new System.Windows.Forms.Button();
            this.butCheckAll = new System.Windows.Forms.Button();
            this.lLoad = new System.Windows.Forms.Label();
            this.cBYear = new System.Windows.Forms.ComboBox();
            this.cBMount = new System.Windows.Forms.ComboBox();
            this.butAddMenus = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clBMenus
            // 
            this.clBMenus.FormattingEnabled = true;
            this.clBMenus.Location = new System.Drawing.Point(17, 24);
            this.clBMenus.Name = "clBMenus";
            this.clBMenus.Size = new System.Drawing.Size(264, 274);
            this.clBMenus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите меню:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butCheckClear);
            this.panel1.Controls.Add(this.butCheckAll);
            this.panel1.Controls.Add(this.lLoad);
            this.panel1.Controls.Add(this.cBYear);
            this.panel1.Controls.Add(this.cBMount);
            this.panel1.Controls.Add(this.butAddMenus);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.clBMenus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 450);
            this.panel1.TabIndex = 2;
            // 
            // butCheckClear
            // 
            this.butCheckClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCheckClear.ForeColor = System.Drawing.Color.Black;
            this.butCheckClear.Location = new System.Drawing.Point(157, 304);
            this.butCheckClear.Name = "butCheckClear";
            this.butCheckClear.Size = new System.Drawing.Size(124, 23);
            this.butCheckClear.TabIndex = 61;
            this.butCheckClear.Text = "Снять все";
            this.butCheckClear.UseVisualStyleBackColor = true;
            this.butCheckClear.Click += new System.EventHandler(this.butCheckClear_Click);
            // 
            // butCheckAll
            // 
            this.butCheckAll.ForeColor = System.Drawing.Color.Black;
            this.butCheckAll.Location = new System.Drawing.Point(17, 304);
            this.butCheckAll.Name = "butCheckAll";
            this.butCheckAll.Size = new System.Drawing.Size(134, 23);
            this.butCheckAll.TabIndex = 60;
            this.butCheckAll.Text = "Выбрать все";
            this.butCheckAll.UseVisualStyleBackColor = true;
            this.butCheckAll.Click += new System.EventHandler(this.butCheckAll_Click);
            // 
            // lLoad
            // 
            this.lLoad.BackColor = System.Drawing.Color.White;
            this.lLoad.Font = new System.Drawing.Font("Segoe Script", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLoad.ForeColor = System.Drawing.Color.Black;
            this.lLoad.Location = new System.Drawing.Point(61, 138);
            this.lLoad.Name = "lLoad";
            this.lLoad.Size = new System.Drawing.Size(175, 56);
            this.lLoad.TabIndex = 59;
            this.lLoad.Text = "Загрузка ...";
            this.lLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lLoad.Visible = false;
            // 
            // cBYear
            // 
            this.cBYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBYear.FormattingEnabled = true;
            this.cBYear.Location = new System.Drawing.Point(157, 353);
            this.cBYear.Name = "cBYear";
            this.cBYear.Size = new System.Drawing.Size(124, 21);
            this.cBYear.TabIndex = 58;
            // 
            // cBMount
            // 
            this.cBMount.FormattingEnabled = true;
            this.cBMount.Location = new System.Drawing.Point(21, 353);
            this.cBMount.Name = "cBMount";
            this.cBMount.Size = new System.Drawing.Size(130, 21);
            this.cBMount.TabIndex = 57;
            // 
            // butAddMenus
            // 
            this.butAddMenus.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddMenus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddMenus.Location = new System.Drawing.Point(17, 393);
            this.butAddMenus.Name = "butAddMenus";
            this.butAddMenus.Size = new System.Drawing.Size(264, 45);
            this.butAddMenus.TabIndex = 2;
            this.butAddMenus.Text = "Сформировать накопительную";
            this.butAddMenus.UseVisualStyleBackColor = false;
            this.butAddMenus.Click += new System.EventHandler(this.ButAddMenus_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 336);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 13);
            this.label10.TabIndex = 56;
            this.label10.Text = "Выберите месяц и год:";
            // 
            // AccumulativeOnConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(300, 450);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(316, 489);
            this.MinimumSize = new System.Drawing.Size(316, 489);
            this.Name = "AccumulativeOnConsumption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Накопительные по расходу";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccumulativeOnConsumption_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clBMenus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butAddMenus;
        private System.Windows.Forms.ComboBox cBYear;
        private System.Windows.Forms.ComboBox cBMount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lLoad;
        private System.Windows.Forms.Button butCheckClear;
        private System.Windows.Forms.Button butCheckAll;
    }
}