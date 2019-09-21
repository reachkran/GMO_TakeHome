namespace GMO_Application
{
    partial class Master_DetailForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxProd = new System.Windows.Forms.TextBox();
            this.labelProd = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxProd);
            this.panel1.Controls.Add(this.labelProd);
            this.panel1.Controls.Add(this.labelDescription);
            this.panel1.Controls.Add(this.textBoxDescription);
            this.panel1.Controls.Add(this.comboBoxProduct);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(26, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 424);
            this.panel1.TabIndex = 0;
            // 
            // textBoxProd
            // 
            this.textBoxProd.Location = new System.Drawing.Point(223, 135);
            this.textBoxProd.Multiline = true;
            this.textBoxProd.Name = "textBoxProd";
            this.textBoxProd.Size = new System.Drawing.Size(361, 20);
            this.textBoxProd.TabIndex = 5;
            // 
            // labelProd
            // 
            this.labelProd.AutoSize = true;
            this.labelProd.Location = new System.Drawing.Point(107, 135);
            this.labelProd.Name = "labelProd";
            this.labelProd.Size = new System.Drawing.Size(72, 13);
            this.labelProd.TabIndex = 4;
            this.labelProd.Text = "ProductName";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(107, 164);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxDescription.Location = new System.Drawing.Point(223, 161);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(361, 120);
            this.textBoxDescription.TabIndex = 2;
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(223, 43);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(267, 21);
            this.comboBoxProduct.TabIndex = 1;
            this.comboBoxProduct.SelectionChangeCommitted += new System.EventHandler(this.comboBoxProduct_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products";
            // 
            // Master_DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 431);
            this.Controls.Add(this.panel1);
            this.Name = "Master_DetailForm";
            this.Text = "Master_DetailForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxProd;
        private System.Windows.Forms.Label labelProd;
    }
}