namespace Дет.Сад.Питание.Forms
{
    partial class AddEditDishForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditDishForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tBName = new System.Windows.Forms.TextBox();
            this.tBNorm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBVitamine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBProtein = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBFat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBCarbo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lBProducts = new System.Windows.Forms.ListBox();
            this.lBSostav = new System.Windows.Forms.ListBox();
            this.butPlus = new System.Windows.Forms.Button();
            this.butMin = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.timError = new System.Windows.Forms.Timer(this.components);
            this.pBSearch = new System.Windows.Forms.PictureBox();
            this.tBSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // tBName
            // 
            this.tBName.ForeColor = System.Drawing.Color.Black;
            this.tBName.Location = new System.Drawing.Point(16, 48);
            this.tBName.Name = "tBName";
            this.tBName.Size = new System.Drawing.Size(337, 20);
            this.tBName.TabIndex = 1;
            // 
            // tBNorm
            // 
            this.tBNorm.ForeColor = System.Drawing.Color.Black;
            this.tBNorm.Location = new System.Drawing.Point(16, 101);
            this.tBNorm.Name = "tBNorm";
            this.tBNorm.Size = new System.Drawing.Size(337, 20);
            this.tBNorm.TabIndex = 3;
            this.tBNorm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Норма на человека";
            // 
            // tBVitamine
            // 
            this.tBVitamine.ForeColor = System.Drawing.Color.Black;
            this.tBVitamine.Location = new System.Drawing.Point(16, 153);
            this.tBVitamine.Name = "tBVitamine";
            this.tBVitamine.Size = new System.Drawing.Size(337, 20);
            this.tBVitamine.TabIndex = 5;
            this.tBVitamine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Витамин С";
            // 
            // tBProtein
            // 
            this.tBProtein.ForeColor = System.Drawing.Color.Black;
            this.tBProtein.Location = new System.Drawing.Point(16, 204);
            this.tBProtein.Name = "tBProtein";
            this.tBProtein.Size = new System.Drawing.Size(337, 20);
            this.tBProtein.TabIndex = 7;
            this.tBProtein.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Белки";
            // 
            // tBFat
            // 
            this.tBFat.ForeColor = System.Drawing.Color.Black;
            this.tBFat.Location = new System.Drawing.Point(16, 254);
            this.tBFat.Name = "tBFat";
            this.tBFat.Size = new System.Drawing.Size(337, 20);
            this.tBFat.TabIndex = 9;
            this.tBFat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(13, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Жиры";
            // 
            // tBCarbo
            // 
            this.tBCarbo.ForeColor = System.Drawing.Color.Black;
            this.tBCarbo.Location = new System.Drawing.Point(16, 307);
            this.tBCarbo.Name = "tBCarbo";
            this.tBCarbo.Size = new System.Drawing.Size(337, 20);
            this.tBCarbo.TabIndex = 11;
            this.tBCarbo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(13, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Углеводы";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Все продукты:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(204, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Состав блюда:";
            // 
            // lBProducts
            // 
            this.lBProducts.ForeColor = System.Drawing.Color.Black;
            this.lBProducts.FormattingEnabled = true;
            this.lBProducts.Location = new System.Drawing.Point(16, 384);
            this.lBProducts.Name = "lBProducts";
            this.lBProducts.Size = new System.Drawing.Size(146, 108);
            this.lBProducts.TabIndex = 14;
            // 
            // lBSostav
            // 
            this.lBSostav.ForeColor = System.Drawing.Color.Black;
            this.lBSostav.FormattingEnabled = true;
            this.lBSostav.Location = new System.Drawing.Point(207, 384);
            this.lBSostav.Name = "lBSostav";
            this.lBSostav.Size = new System.Drawing.Size(146, 108);
            this.lBSostav.TabIndex = 15;
            // 
            // butPlus
            // 
            this.butPlus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.butPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPlus.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butPlus.ForeColor = System.Drawing.Color.Black;
            this.butPlus.Location = new System.Drawing.Point(171, 401);
            this.butPlus.Margin = new System.Windows.Forms.Padding(0);
            this.butPlus.Name = "butPlus";
            this.butPlus.Size = new System.Drawing.Size(30, 30);
            this.butPlus.TabIndex = 16;
            this.butPlus.Text = "+";
            this.butPlus.UseVisualStyleBackColor = false;
            this.butPlus.Click += new System.EventHandler(this.ButPlus_Click);
            // 
            // butMin
            // 
            this.butMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.butMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMin.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butMin.ForeColor = System.Drawing.Color.Black;
            this.butMin.Location = new System.Drawing.Point(170, 450);
            this.butMin.Margin = new System.Windows.Forms.Padding(0);
            this.butMin.Name = "butMin";
            this.butMin.Size = new System.Drawing.Size(30, 30);
            this.butMin.TabIndex = 17;
            this.butMin.Text = "-";
            this.butMin.UseVisualStyleBackColor = false;
            this.butMin.Click += new System.EventHandler(this.ButMin_Click);
            // 
            // butDelete
            // 
            this.butDelete.BackColor = System.Drawing.Color.Tomato;
            this.butDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butDelete.Location = new System.Drawing.Point(187, 512);
            this.butDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(166, 31);
            this.butDelete.TabIndex = 21;
            this.butDelete.Text = "Удалить блюдо";
            this.butDelete.UseVisualStyleBackColor = false;
            this.butDelete.Visible = false;
            this.butDelete.Click += new System.EventHandler(this.ButDelete_Click);
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.Color.LimeGreen;
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butSave.Location = new System.Drawing.Point(16, 512);
            this.butSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(163, 31);
            this.butSave.TabIndex = 20;
            this.butSave.Text = "Сохранить блюдо";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // labelError
            // 
            this.labelError.BackColor = System.Drawing.Color.Tomato;
            this.labelError.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelError.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelError.Location = new System.Drawing.Point(0, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(374, 23);
            this.labelError.TabIndex = 22;
            this.labelError.Text = "Наименование";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelError.Visible = false;
            // 
            // timError
            // 
            this.timError.Interval = 2000;
            this.timError.Tick += new System.EventHandler(this.TimError_Tick);
            // 
            // pBSearch
            // 
            this.pBSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBSearch.BackColor = System.Drawing.Color.Black;
            this.pBSearch.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.search;
            this.pBSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBSearch.Location = new System.Drawing.Point(15, 353);
            this.pBSearch.Name = "pBSearch";
            this.pBSearch.Size = new System.Drawing.Size(25, 28);
            this.pBSearch.TabIndex = 24;
            this.pBSearch.TabStop = false;
            // 
            // tBSearch
            // 
            this.tBSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBSearch.Location = new System.Drawing.Point(42, 358);
            this.tBSearch.Name = "tBSearch";
            this.tBSearch.Size = new System.Drawing.Size(120, 20);
            this.tBSearch.TabIndex = 23;
            this.tBSearch.TextChanged += new System.EventHandler(this.TBSearch_TextChanged);
            // 
            // AddEditDishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(374, 557);
            this.Controls.Add(this.pBSearch);
            this.Controls.Add(this.tBSearch);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.butMin);
            this.Controls.Add(this.butPlus);
            this.Controls.Add(this.lBSostav);
            this.Controls.Add(this.lBProducts);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tBCarbo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tBFat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBProtein);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBVitamine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBNorm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEditDishForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление блюда";
            ((System.ComponentModel.ISupportInitialize)(this.pBSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBName;
        private System.Windows.Forms.TextBox tBNorm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBVitamine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBProtein;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBFat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBCarbo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lBProducts;
        private System.Windows.Forms.ListBox lBSostav;
        private System.Windows.Forms.Button butPlus;
        private System.Windows.Forms.Button butMin;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Timer timError;
        private System.Windows.Forms.PictureBox pBSearch;
        private System.Windows.Forms.TextBox tBSearch;
    }
}