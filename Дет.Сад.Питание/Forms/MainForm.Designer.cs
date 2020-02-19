namespace Дет.Сад.Питание
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.butDirectory = new System.Windows.Forms.Button();
            this.butOverhead = new System.Windows.Forms.Button();
            this.butIncome = new System.Windows.Forms.Button();
            this.butConsumption = new System.Windows.Forms.Button();
            this.butPatterns = new System.Windows.Forms.Button();
            this.butContracts = new System.Windows.Forms.Button();
            this.butInvoices = new System.Windows.Forms.Button();
            this.butMenus = new System.Windows.Forms.Button();
            this.butDishes = new System.Windows.Forms.Button();
            this.butProducts = new System.Windows.Forms.Button();
            this.fBDialogPath = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // butDirectory
            // 
            this.butDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butDirectory.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.configuration_settings;
            this.butDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDirectory.Location = new System.Drawing.Point(590, 145);
            this.butDirectory.Name = "butDirectory";
            this.butDirectory.Size = new System.Drawing.Size(115, 105);
            this.butDirectory.TabIndex = 9;
            this.butDirectory.Text = "Настройки";
            this.butDirectory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butDirectory.UseVisualStyleBackColor = true;
            this.butDirectory.Click += new System.EventHandler(this.ButDirectory_Click);
            // 
            // butOverhead
            // 
            this.butOverhead.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butOverhead.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.Накладные;
            this.butOverhead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butOverhead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butOverhead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOverhead.Location = new System.Drawing.Point(444, 145);
            this.butOverhead.Name = "butOverhead";
            this.butOverhead.Size = new System.Drawing.Size(115, 105);
            this.butOverhead.TabIndex = 8;
            this.butOverhead.Text = "Накладные";
            this.butOverhead.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butOverhead.UseVisualStyleBackColor = true;
            this.butOverhead.Click += new System.EventHandler(this.ButOverhead_Click);
            // 
            // butIncome
            // 
            this.butIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butIncome.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.Приход;
            this.butIncome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butIncome.Location = new System.Drawing.Point(297, 145);
            this.butIncome.Name = "butIncome";
            this.butIncome.Size = new System.Drawing.Size(115, 105);
            this.butIncome.TabIndex = 7;
            this.butIncome.Text = "Накопительные по приходу";
            this.butIncome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butIncome.UseVisualStyleBackColor = true;
            this.butIncome.Click += new System.EventHandler(this.ButIncome_Click);
            // 
            // butConsumption
            // 
            this.butConsumption.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butConsumption.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.Расход;
            this.butConsumption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butConsumption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butConsumption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butConsumption.Location = new System.Drawing.Point(151, 145);
            this.butConsumption.Name = "butConsumption";
            this.butConsumption.Size = new System.Drawing.Size(115, 105);
            this.butConsumption.TabIndex = 6;
            this.butConsumption.Text = "Накопительная по расходу";
            this.butConsumption.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butConsumption.UseVisualStyleBackColor = true;
            this.butConsumption.Click += new System.EventHandler(this.ButConsumption_Click);
            // 
            // butPatterns
            // 
            this.butPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butPatterns.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.Шаблоны;
            this.butPatterns.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butPatterns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butPatterns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPatterns.Location = new System.Drawing.Point(12, 145);
            this.butPatterns.Name = "butPatterns";
            this.butPatterns.Size = new System.Drawing.Size(115, 105);
            this.butPatterns.TabIndex = 5;
            this.butPatterns.Text = "Варианты меню";
            this.butPatterns.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butPatterns.UseVisualStyleBackColor = true;
            this.butPatterns.Click += new System.EventHandler(this.ButPatterns_Click);
            // 
            // butContracts
            // 
            this.butContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butContracts.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.Договора;
            this.butContracts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butContracts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butContracts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butContracts.Location = new System.Drawing.Point(590, 12);
            this.butContracts.Name = "butContracts";
            this.butContracts.Size = new System.Drawing.Size(115, 105);
            this.butContracts.TabIndex = 4;
            this.butContracts.Text = "Договора";
            this.butContracts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butContracts.UseVisualStyleBackColor = true;
            this.butContracts.Click += new System.EventHandler(this.ButContracts_Click);
            // 
            // butInvoices
            // 
            this.butInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butInvoices.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.Счёт_фактура;
            this.butInvoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butInvoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butInvoices.Location = new System.Drawing.Point(444, 12);
            this.butInvoices.Name = "butInvoices";
            this.butInvoices.Size = new System.Drawing.Size(115, 105);
            this.butInvoices.TabIndex = 3;
            this.butInvoices.Text = "Счёт-фактуры";
            this.butInvoices.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butInvoices.UseVisualStyleBackColor = true;
            this.butInvoices.Click += new System.EventHandler(this.ButInvoices_Click);
            // 
            // butMenus
            // 
            this.butMenus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butMenus.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.меню;
            this.butMenus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butMenus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butMenus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMenus.Location = new System.Drawing.Point(297, 12);
            this.butMenus.Name = "butMenus";
            this.butMenus.Size = new System.Drawing.Size(115, 105);
            this.butMenus.TabIndex = 2;
            this.butMenus.Text = "Меню";
            this.butMenus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butMenus.UseVisualStyleBackColor = true;
            this.butMenus.Click += new System.EventHandler(this.ButMenus_Click);
            // 
            // butDishes
            // 
            this.butDishes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butDishes.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.Блюда;
            this.butDishes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butDishes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butDishes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDishes.Location = new System.Drawing.Point(151, 12);
            this.butDishes.Name = "butDishes";
            this.butDishes.Size = new System.Drawing.Size(115, 105);
            this.butDishes.TabIndex = 1;
            this.butDishes.Text = "Блюда";
            this.butDishes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butDishes.UseVisualStyleBackColor = true;
            this.butDishes.Click += new System.EventHandler(this.ButDishes_Click);
            // 
            // butProducts
            // 
            this.butProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butProducts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.butProducts.BackgroundImage = global::Дет.Сад.Питание.Properties.Resources.Продукты;
            this.butProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.butProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butProducts.Location = new System.Drawing.Point(12, 12);
            this.butProducts.Name = "butProducts";
            this.butProducts.Size = new System.Drawing.Size(115, 105);
            this.butProducts.TabIndex = 0;
            this.butProducts.Text = "Продукты";
            this.butProducts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butProducts.UseVisualStyleBackColor = false;
            this.butProducts.Click += new System.EventHandler(this.ButProducts_Click);
            // 
            // fBDialogPath
            // 
            this.fBDialogPath.Description = "Выберите папку для загрузки и сохранения документов";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(723, 266);
            this.Controls.Add(this.butDirectory);
            this.Controls.Add(this.butOverhead);
            this.Controls.Add(this.butIncome);
            this.Controls.Add(this.butConsumption);
            this.Controls.Add(this.butPatterns);
            this.Controls.Add(this.butContracts);
            this.Controls.Add(this.butInvoices);
            this.Controls.Add(this.butMenus);
            this.Controls.Add(this.butDishes);
            this.Controls.Add(this.butProducts);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(739, 305);
            this.MinimumSize = new System.Drawing.Size(739, 305);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню программы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butProducts;
        private System.Windows.Forms.Button butDishes;
        private System.Windows.Forms.Button butMenus;
        private System.Windows.Forms.Button butInvoices;
        private System.Windows.Forms.Button butContracts;
        private System.Windows.Forms.Button butPatterns;
        private System.Windows.Forms.Button butConsumption;
        private System.Windows.Forms.Button butIncome;
        private System.Windows.Forms.Button butOverhead;
        private System.Windows.Forms.Button butDirectory;
        private System.Windows.Forms.FolderBrowserDialog fBDialogPath;
    }
}

