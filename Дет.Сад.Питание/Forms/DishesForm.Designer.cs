namespace Дет.Сад.Питание.Forms
{
    partial class DishesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DishesForm));
            this.butRefresh = new System.Windows.Forms.Button();
            this.butAddDish = new System.Windows.Forms.Button();
            this.pBSearch = new System.Windows.Forms.PictureBox();
            this.tBSearch = new System.Windows.Forms.TextBox();
            this.dGVDishesList = new System.Windows.Forms.DataGridView();
            this.NameDish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Norm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vitamine_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carbohydrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pBSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDishesList)).BeginInit();
            this.SuspendLayout();
            // 
            // butRefresh
            // 
            this.butRefresh.BackColor = System.Drawing.Color.LimeGreen;
            this.butRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRefresh.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butRefresh.Location = new System.Drawing.Point(218, 14);
            this.butRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(169, 31);
            this.butRefresh.TabIndex = 6;
            this.butRefresh.Text = "Обновить список";
            this.butRefresh.UseVisualStyleBackColor = false;
            this.butRefresh.Click += new System.EventHandler(this.ButRefresh_Click);
            // 
            // butAddDish
            // 
            this.butAddDish.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddDish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddDish.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butAddDish.Location = new System.Drawing.Point(14, 14);
            this.butAddDish.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butAddDish.Name = "butAddDish";
            this.butAddDish.Size = new System.Drawing.Size(169, 31);
            this.butAddDish.TabIndex = 5;
            this.butAddDish.Text = "Добавить блюдо";
            this.butAddDish.UseVisualStyleBackColor = false;
            this.butAddDish.Click += new System.EventHandler(this.ButAddDish_Click);
            // 
            // pBSearch
            // 
            this.pBSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBSearch.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.search;
            this.pBSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBSearch.Location = new System.Drawing.Point(789, 16);
            this.pBSearch.Name = "pBSearch";
            this.pBSearch.Size = new System.Drawing.Size(25, 28);
            this.pBSearch.TabIndex = 8;
            this.pBSearch.TabStop = false;
            // 
            // tBSearch
            // 
            this.tBSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBSearch.Location = new System.Drawing.Point(816, 16);
            this.tBSearch.Name = "tBSearch";
            this.tBSearch.Size = new System.Drawing.Size(215, 27);
            this.tBSearch.TabIndex = 7;
            this.tBSearch.TextChanged += new System.EventHandler(this.TBSearch_TextChanged);
            // 
            // dGVDishesList
            // 
            this.dGVDishesList.AllowUserToAddRows = false;
            this.dGVDishesList.AllowUserToDeleteRows = false;
            this.dGVDishesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVDishesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVDishesList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dGVDishesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVDishesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDishesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameDish,
            this.Norm,
            this.Vitamine_C,
            this.Carbohydrate,
            this.Protein,
            this.Fat,
            this.Edit,
            this.Delete});
            this.dGVDishesList.Location = new System.Drawing.Point(14, 55);
            this.dGVDishesList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dGVDishesList.Name = "dGVDishesList";
            this.dGVDishesList.ReadOnly = true;
            this.dGVDishesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dGVDishesList.Size = new System.Drawing.Size(1017, 492);
            this.dGVDishesList.TabIndex = 9;
            this.dGVDishesList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDishesList_CellClick);
            // 
            // NameDish
            // 
            this.NameDish.FillWeight = 62.39625F;
            this.NameDish.HeaderText = "Наименование";
            this.NameDish.Name = "NameDish";
            this.NameDish.ReadOnly = true;
            // 
            // Norm
            // 
            this.Norm.FillWeight = 35F;
            this.Norm.HeaderText = "Норма";
            this.Norm.Name = "Norm";
            this.Norm.ReadOnly = true;
            // 
            // Vitamine_C
            // 
            this.Vitamine_C.FillWeight = 35.52061F;
            this.Vitamine_C.HeaderText = "Витамин С";
            this.Vitamine_C.Name = "Vitamine_C";
            this.Vitamine_C.ReadOnly = true;
            // 
            // Carbohydrate
            // 
            this.Carbohydrate.FillWeight = 35.52061F;
            this.Carbohydrate.HeaderText = "Углеводы";
            this.Carbohydrate.Name = "Carbohydrate";
            this.Carbohydrate.ReadOnly = true;
            // 
            // Protein
            // 
            this.Protein.FillWeight = 35.52061F;
            this.Protein.HeaderText = "Белки";
            this.Protein.Name = "Protein";
            this.Protein.ReadOnly = true;
            // 
            // Fat
            // 
            this.Fat.FillWeight = 35.52061F;
            this.Fat.HeaderText = "Жиры";
            this.Fat.Name = "Fat";
            this.Fat.ReadOnly = true;
            // 
            // Edit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.Edit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Edit.FillWeight = 35.52061F;
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Изменить";
            // 
            // Delete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.FillWeight = 35.52061F;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Удалить";
            // 
            // DishesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1046, 561);
            this.Controls.Add(this.butRefresh);
            this.Controls.Add(this.pBSearch);
            this.Controls.Add(this.tBSearch);
            this.Controls.Add(this.butAddDish);
            this.Controls.Add(this.dGVDishesList);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "DishesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Блюда";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DishesForm_FormClosed);
            this.Load += new System.EventHandler(this.DishesForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pBSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDishesList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.Button butAddDish;
        private System.Windows.Forms.PictureBox pBSearch;
        private System.Windows.Forms.TextBox tBSearch;
        private System.Windows.Forms.DataGridView dGVDishesList;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDish;
        private System.Windows.Forms.DataGridViewTextBoxColumn Norm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vitamine_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carbohydrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fat;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}