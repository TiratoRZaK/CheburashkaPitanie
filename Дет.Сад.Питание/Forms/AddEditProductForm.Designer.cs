namespace Дет.Сад.Питание.Forms
{
    partial class AddEditProductForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditProductForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBVitamine = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBProtein = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cBUnit = new System.Windows.Forms.ComboBox();
            this.cBType = new System.Windows.Forms.ComboBox();
            this.tBFat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBCarbo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.timError = new System.Windows.Forms.Timer(this.components);
            this.tBNorm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.panBalancePrice = new System.Windows.Forms.Panel();
            this.tBBalance = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tBSum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butEditPanel = new System.Windows.Forms.Button();
            this.tBPsevdoName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panBalancePrice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // tBName
            // 
            this.tBName.Location = new System.Drawing.Point(16, 56);
            this.tBName.Name = "tBName";
            this.tBName.Size = new System.Drawing.Size(196, 20);
            this.tBName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Единица измерения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Тип продукта";
            // 
            // tBVitamine
            // 
            this.tBVitamine.Location = new System.Drawing.Point(16, 318);
            this.tBVitamine.Name = "tBVitamine";
            this.tBVitamine.Size = new System.Drawing.Size(144, 20);
            this.tBVitamine.TabIndex = 9;
            this.tBVitamine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Витамин С";
            // 
            // tBProtein
            // 
            this.tBProtein.Location = new System.Drawing.Point(16, 370);
            this.tBProtein.Name = "tBProtein";
            this.tBProtein.Size = new System.Drawing.Size(144, 20);
            this.tBProtein.TabIndex = 11;
            this.tBProtein.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Белки";
            // 
            // cBUnit
            // 
            this.cBUnit.FormattingEnabled = true;
            this.cBUnit.Location = new System.Drawing.Point(16, 110);
            this.cBUnit.Name = "cBUnit";
            this.cBUnit.Size = new System.Drawing.Size(144, 21);
            this.cBUnit.TabIndex = 12;
            // 
            // cBType
            // 
            this.cBType.FormattingEnabled = true;
            this.cBType.Location = new System.Drawing.Point(16, 161);
            this.cBType.Name = "cBType";
            this.cBType.Size = new System.Drawing.Size(338, 21);
            this.cBType.TabIndex = 13;
            // 
            // tBFat
            // 
            this.tBFat.Location = new System.Drawing.Point(210, 321);
            this.tBFat.Name = "tBFat";
            this.tBFat.Size = new System.Drawing.Size(144, 20);
            this.tBFat.TabIndex = 15;
            this.tBFat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Жиры";
            // 
            // tBCarbo
            // 
            this.tBCarbo.Location = new System.Drawing.Point(210, 370);
            this.tBCarbo.Name = "tBCarbo";
            this.tBCarbo.Size = new System.Drawing.Size(144, 20);
            this.tBCarbo.TabIndex = 17;
            this.tBCarbo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Углеводы";
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.Color.LimeGreen;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butSave.Location = new System.Drawing.Point(16, 398);
            this.butSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(169, 31);
            this.butSave.TabIndex = 18;
            this.butSave.Text = "Сохранить продукт";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // butDel
            // 
            this.butDel.BackColor = System.Drawing.Color.Tomato;
            this.butDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butDel.Location = new System.Drawing.Point(185, 398);
            this.butDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(169, 31);
            this.butDel.TabIndex = 19;
            this.butDel.Text = "Удалить продукт";
            this.butDel.UseVisualStyleBackColor = false;
            this.butDel.Visible = false;
            this.butDel.Click += new System.EventHandler(this.ButDel_Click);
            // 
            // timError
            // 
            this.timError.Interval = 2000;
            this.timError.Tick += new System.EventHandler(this.TimError_Tick);
            // 
            // tBNorm
            // 
            this.tBNorm.Location = new System.Drawing.Point(210, 111);
            this.tBNorm.Name = "tBNorm";
            this.tBNorm.Size = new System.Drawing.Size(144, 20);
            this.tBNorm.TabIndex = 22;
            this.tBNorm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(207, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Норма на день";
            // 
            // labelError
            // 
            this.labelError.BackColor = System.Drawing.Color.Tomato;
            this.labelError.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelError.Location = new System.Drawing.Point(0, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(373, 23);
            this.labelError.TabIndex = 23;
            this.labelError.Text = "Наименование";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelError.Visible = false;
            // 
            // panBalancePrice
            // 
            this.panBalancePrice.BackColor = System.Drawing.Color.Tomato;
            this.panBalancePrice.Controls.Add(this.tBBalance);
            this.panBalancePrice.Controls.Add(this.label10);
            this.panBalancePrice.Controls.Add(this.tBSum);
            this.panBalancePrice.Controls.Add(this.label4);
            this.panBalancePrice.Enabled = false;
            this.panBalancePrice.Location = new System.Drawing.Point(151, 188);
            this.panBalancePrice.Name = "panBalancePrice";
            this.panBalancePrice.Size = new System.Drawing.Size(203, 111);
            this.panBalancePrice.TabIndex = 24;
            // 
            // tBBalance
            // 
            this.tBBalance.Location = new System.Drawing.Point(31, 80);
            this.tBBalance.Name = "tBBalance";
            this.tBBalance.Size = new System.Drawing.Size(144, 20);
            this.tBBalance.TabIndex = 26;
            this.tBBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(28, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Количество";
            // 
            // tBSum
            // 
            this.tBSum.Location = new System.Drawing.Point(31, 29);
            this.tBSum.Name = "tBSum";
            this.tBSum.Size = new System.Drawing.Size(144, 20);
            this.tBSum.TabIndex = 24;
            this.tBSum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(28, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Сумма";
            // 
            // butEditPanel
            // 
            this.butEditPanel.BackColor = System.Drawing.Color.Red;
            this.butEditPanel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butEditPanel.Location = new System.Drawing.Point(16, 217);
            this.butEditPanel.Name = "butEditPanel";
            this.butEditPanel.Size = new System.Drawing.Size(119, 52);
            this.butEditPanel.TabIndex = 25;
            this.butEditPanel.Text = "Изменить количество и сумму продукта";
            this.butEditPanel.UseVisualStyleBackColor = false;
            this.butEditPanel.Click += new System.EventHandler(this.ButEditPanel_Click);
            // 
            // tBPsevdoName
            // 
            this.tBPsevdoName.Location = new System.Drawing.Point(236, 56);
            this.tBPsevdoName.Name = "tBPsevdoName";
            this.tBPsevdoName.Size = new System.Drawing.Size(118, 20);
            this.tBPsevdoName.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(233, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Псевдоним";
            // 
            // AddEditProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(373, 447);
            this.Controls.Add(this.tBPsevdoName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.butEditPanel);
            this.Controls.Add(this.panBalancePrice);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.tBNorm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.tBCarbo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tBFat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cBType);
            this.Controls.Add(this.cBUnit);
            this.Controls.Add(this.tBProtein);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBVitamine);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEditProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление нового продукта";
            this.panBalancePrice.ResumeLayout(false);
            this.panBalancePrice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBVitamine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBProtein;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cBUnit;
        private System.Windows.Forms.ComboBox cBType;
        private System.Windows.Forms.TextBox tBFat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBCarbo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Timer timError;
        private System.Windows.Forms.TextBox tBNorm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Panel panBalancePrice;
        private System.Windows.Forms.Button butEditPanel;
        private System.Windows.Forms.TextBox tBBalance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBSum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBPsevdoName;
        private System.Windows.Forms.Label label11;
    }
}