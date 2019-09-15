namespace Дет.Сад.Питание.Forms
{
    partial class AddProductInContract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductInContract));
            this.butDel = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.tBPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cBProduct = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.tBBalance = new System.Windows.Forms.TextBox();
            this.timError = new System.Windows.Forms.Timer(this.components);
            this.labelError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBUnit = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butDel
            // 
            this.butDel.BackColor = System.Drawing.Color.Tomato;
            this.butDel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butDel.Location = new System.Drawing.Point(164, 259);
            this.butDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(132, 42);
            this.butDel.TabIndex = 40;
            this.butDel.Text = "Отменить добавление";
            this.butDel.UseVisualStyleBackColor = false;
            this.butDel.Visible = false;
            this.butDel.Click += new System.EventHandler(this.ButDel_Click);
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.Color.LimeGreen;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butSave.Location = new System.Drawing.Point(16, 259);
            this.butSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(140, 42);
            this.butSave.TabIndex = 39;
            this.butSave.Text = "Добавить продукт";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // tBPrice
            // 
            this.tBPrice.Location = new System.Drawing.Point(24, 128);
            this.tBPrice.Name = "tBPrice";
            this.tBPrice.Size = new System.Drawing.Size(240, 20);
            this.tBPrice.TabIndex = 28;
            this.tBPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Цена";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(20, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 20);
            this.label12.TabIndex = 46;
            this.label12.Text = "Выберите продукт:";
            // 
            // cBProduct
            // 
            this.cBProduct.FormattingEnabled = true;
            this.cBProduct.Location = new System.Drawing.Point(24, 44);
            this.cBProduct.Name = "cBProduct";
            this.cBProduct.Size = new System.Drawing.Size(243, 21);
            this.cBProduct.TabIndex = 47;
            this.cBProduct.SelectedIndexChanged += new System.EventHandler(this.CBProduct_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tBUnit);
            this.panel1.Controls.Add(this.cBProduct);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tBBalance);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tBPrice);
            this.panel1.Location = new System.Drawing.Point(16, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 213);
            this.panel1.TabIndex = 48;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "Количество:";
            // 
            // tBBalance
            // 
            this.tBBalance.Location = new System.Drawing.Point(24, 173);
            this.tBBalance.Name = "tBBalance";
            this.tBBalance.Size = new System.Drawing.Size(243, 20);
            this.tBBalance.TabIndex = 45;
            this.tBBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // timError
            // 
            this.timError.Interval = 2000;
            this.timError.Tick += new System.EventHandler(this.TimError_Tick);
            // 
            // labelError
            // 
            this.labelError.BackColor = System.Drawing.Color.Tomato;
            this.labelError.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelError.Location = new System.Drawing.Point(0, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(311, 23);
            this.labelError.TabIndex = 50;
            this.labelError.Text = "Наименование";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelError.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Ед. изм.:";
            // 
            // tBUnit
            // 
            this.tBUnit.Location = new System.Drawing.Point(24, 86);
            this.tBUnit.Name = "tBUnit";
            this.tBUnit.ReadOnly = true;
            this.tBUnit.Size = new System.Drawing.Size(240, 20);
            this.tBUnit.TabIndex = 49;
            // 
            // AddProductInContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.butDel;
            this.ClientSize = new System.Drawing.Size(311, 305);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butSave);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddProductInContract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление продукта в договор";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddProductInContract_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.TextBox tBPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cBProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timError;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tBBalance;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBUnit;
    }
}