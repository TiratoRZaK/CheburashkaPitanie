namespace Дет.Сад.Питание.Forms
{
    partial class SetNorm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetNorm));
            this.tBNorm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tBNorm
            // 
            this.tBNorm.Location = new System.Drawing.Point(17, 46);
            this.tBNorm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tBNorm.Name = "tBNorm";
            this.tBNorm.Size = new System.Drawing.Size(303, 27);
            this.tBNorm.TabIndex = 0;
            this.tBNorm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNorm_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите норму добавляемого продукта:";
            // 
            // SetNorm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(337, 95);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBNorm);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(353, 134);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(353, 134);
            this.Name = "SetNorm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Установка нормы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBNorm;
        private System.Windows.Forms.Label label1;
    }
}