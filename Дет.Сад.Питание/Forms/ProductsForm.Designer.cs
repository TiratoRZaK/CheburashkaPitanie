namespace Дет.Сад.Питание
{
    partial class ProductsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsForm));
            this.dGVProductsList = new System.Windows.Forms.DataGridView();
            this.NameProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Norm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.butAddProduct = new System.Windows.Forms.Button();
            this.tBSearch = new System.Windows.Forms.TextBox();
            this.butRefresh = new System.Windows.Forms.Button();
            this.pBSearch = new System.Windows.Forms.PictureBox();
            this.butBuild = new System.Windows.Forms.Button();
            this.lLoad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVProductsList
            // 
            this.dGVProductsList.AllowUserToAddRows = false;
            this.dGVProductsList.AllowUserToDeleteRows = false;
            this.dGVProductsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVProductsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVProductsList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dGVProductsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVProductsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProductsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameProduct,
            this.Unit,
            this.Type,
            this.Norm,
            this.Price,
            this.Balance,
            this.Edit,
            this.Delete});
            this.dGVProductsList.Location = new System.Drawing.Point(20, 69);
            this.dGVProductsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dGVProductsList.Name = "dGVProductsList";
            this.dGVProductsList.ReadOnly = true;
            this.dGVProductsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dGVProductsList.Size = new System.Drawing.Size(1008, 478);
            this.dGVProductsList.TabIndex = 0;
            this.dGVProductsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVProductsList_CellClick);
            // 
            // NameProduct
            // 
            this.NameProduct.HeaderText = "Наименование";
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.FillWeight = 35.52061F;
            this.Unit.HeaderText = "Ед.изм.";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.FillWeight = 35.52061F;
            this.Type.HeaderText = "Тип продукта";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Norm
            // 
            this.Norm.FillWeight = 35F;
            this.Norm.HeaderText = "Норма";
            this.Norm.Name = "Norm";
            this.Norm.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.FillWeight = 35.52061F;
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.FillWeight = 35.52061F;
            this.Balance.HeaderText = "Кол-во";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
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
            // butAddProduct
            // 
            this.butAddProduct.BackColor = System.Drawing.Color.LimeGreen;
            this.butAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddProduct.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butAddProduct.Location = new System.Drawing.Point(22, 20);
            this.butAddProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butAddProduct.Name = "butAddProduct";
            this.butAddProduct.Size = new System.Drawing.Size(169, 27);
            this.butAddProduct.TabIndex = 1;
            this.butAddProduct.Text = "Добавить продукт";
            this.butAddProduct.UseVisualStyleBackColor = false;
            this.butAddProduct.Click += new System.EventHandler(this.ButAddProduct_Click);
            // 
            // tBSearch
            // 
            this.tBSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBSearch.Location = new System.Drawing.Point(807, 20);
            this.tBSearch.Name = "tBSearch";
            this.tBSearch.Size = new System.Drawing.Size(215, 27);
            this.tBSearch.TabIndex = 2;
            this.tBSearch.TextChanged += new System.EventHandler(this.TBSearch_TextChanged);
            // 
            // butRefresh
            // 
            this.butRefresh.BackColor = System.Drawing.Color.LimeGreen;
            this.butRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRefresh.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.butRefresh.Location = new System.Drawing.Point(226, 20);
            this.butRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(169, 27);
            this.butRefresh.TabIndex = 4;
            this.butRefresh.Text = "Обновить список";
            this.butRefresh.UseVisualStyleBackColor = false;
            this.butRefresh.Click += new System.EventHandler(this.ButRefresh_Click);
            // 
            // pBSearch
            // 
            this.pBSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBSearch.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.search;
            this.pBSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBSearch.Location = new System.Drawing.Point(780, 20);
            this.pBSearch.Name = "pBSearch";
            this.pBSearch.Size = new System.Drawing.Size(25, 28);
            this.pBSearch.TabIndex = 3;
            this.pBSearch.TabStop = false;
            // 
            // butBuild
            // 
            this.butBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBuild.BackColor = System.Drawing.Color.PeachPuff;
            this.butBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBuild.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butBuild.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.butBuild.Location = new System.Drawing.Point(439, 20);
            this.butBuild.Margin = new System.Windows.Forms.Padding(2);
            this.butBuild.Name = "butBuild";
            this.butBuild.Size = new System.Drawing.Size(299, 27);
            this.butBuild.TabIndex = 14;
            this.butBuild.Text = "Распечатать остатки продуктов";
            this.butBuild.UseVisualStyleBackColor = false;
            this.butBuild.Click += new System.EventHandler(this.ButBuild_Click);
            // 
            // lLoad
            // 
            this.lLoad.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lLoad.Font = new System.Drawing.Font("Segoe Script", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLoad.ForeColor = System.Drawing.Color.Black;
            this.lLoad.Location = new System.Drawing.Point(431, 252);
            this.lLoad.Name = "lLoad";
            this.lLoad.Size = new System.Drawing.Size(205, 56);
            this.lLoad.TabIndex = 16;
            this.lLoad.Text = "Загрузка ...";
            this.lLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lLoad.Visible = false;
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1046, 561);
            this.Controls.Add(this.lLoad);
            this.Controls.Add(this.butBuild);
            this.Controls.Add(this.butRefresh);
            this.Controls.Add(this.pBSearch);
            this.Controls.Add(this.tBSearch);
            this.Controls.Add(this.butAddProduct);
            this.Controls.Add(this.dGVProductsList);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "ProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Продукты";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductsForm_FormClosed);
            this.Load += new System.EventHandler(this.ProductsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVProductsList;
        private System.Windows.Forms.Button butAddProduct;
        private System.Windows.Forms.TextBox tBSearch;
        private System.Windows.Forms.PictureBox pBSearch;
        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.Button butBuild;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Norm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label lLoad;
    }
}