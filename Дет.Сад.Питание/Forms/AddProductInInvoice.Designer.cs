namespace Дет.Сад.Питание.Forms
{
    partial class AddProductInInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProductInInvoice));
            this.labelError = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tBNewPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBOldPrice = new System.Windows.Forms.TextBox();
            this.cBProduct = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tBBalance = new System.Windows.Forms.TextBox();
            this.butDel = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.timError = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelError
            // 
            this.labelError.BackColor = System.Drawing.Color.Tomato;
            this.labelError.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelError.Location = new System.Drawing.Point(0, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(305, 23);
            this.labelError.TabIndex = 54;
            this.labelError.Text = "Наименование";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelError.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tBNewPrice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tBOldPrice);
            this.panel1.Controls.Add(this.cBProduct);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tBBalance);
            this.panel1.Location = new System.Drawing.Point(12, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 196);
            this.panel1.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(148, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Новая цена:";
            // 
            // tBNewPrice
            // 
            this.tBNewPrice.Enabled = false;
            this.tBNewPrice.ForeColor = System.Drawing.Color.Black;
            this.tBNewPrice.Location = new System.Drawing.Point(151, 145);
            this.tBNewPrice.Name = "tBNewPrice";
            this.tBNewPrice.Size = new System.Drawing.Size(116, 20);
            this.tBNewPrice.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Цена остатка:";
            // 
            // tBOldPrice
            // 
            this.tBOldPrice.Enabled = false;
            this.tBOldPrice.ForeColor = System.Drawing.Color.Black;
            this.tBOldPrice.Location = new System.Drawing.Point(24, 145);
            this.tBOldPrice.Name = "tBOldPrice";
            this.tBOldPrice.Size = new System.Drawing.Size(119, 20);
            this.tBOldPrice.TabIndex = 57;
            // 
            // cBProduct
            // 
            this.cBProduct.FormattingEnabled = true;
            this.cBProduct.Location = new System.Drawing.Point(24, 46);
            this.cBProduct.Name = "cBProduct";
            this.cBProduct.Size = new System.Drawing.Size(243, 21);
            this.cBProduct.TabIndex = 47;
            this.cBProduct.SelectedIndexChanged += new System.EventHandler(this.CBProduct_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "Количество:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(20, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 20);
            this.label12.TabIndex = 46;
            this.label12.Text = "Выберите продукт:";
            // 
            // tBBalance
            // 
            this.tBBalance.Location = new System.Drawing.Point(24, 95);
            this.tBBalance.Name = "tBBalance";
            this.tBBalance.Size = new System.Drawing.Size(243, 20);
            this.tBBalance.TabIndex = 45;
            this.tBBalance.TextChanged += new System.EventHandler(this.TBPrice_TextChanged);
            this.tBBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBBalance_KeyPress);
            // 
            // butDel
            // 
            this.butDel.BackColor = System.Drawing.Color.Tomato;
            this.butDel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butDel.Location = new System.Drawing.Point(161, 243);
            this.butDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(132, 42);
            this.butDel.TabIndex = 52;
            this.butDel.Text = "Отменить добавление";
            this.butDel.UseVisualStyleBackColor = false;
            this.butDel.Click += new System.EventHandler(this.ButDel_Click);
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.Color.LimeGreen;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butSave.Location = new System.Drawing.Point(13, 243);
            this.butSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(140, 42);
            this.butSave.TabIndex = 51;
            this.butSave.Text = "Добавить продукт";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // timError
            // 
            this.timError.Interval = 500;
            this.timError.Tick += new System.EventHandler(this.TimError_Tick);
            // 
            // AddProductInInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(305, 299);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butDel);
            this.Controls.Add(this.butSave);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductInInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление продукта в счёт-фактуру";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddProductInInvoice_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cBProduct;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tBBalance;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Timer timError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBNewPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBOldPrice;
    }
}