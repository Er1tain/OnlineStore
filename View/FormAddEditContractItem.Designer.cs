namespace OnlineStore
{
    partial class FormAddEditContractItem
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(120, 12);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(200, 24);
            this.comboBoxProduct.TabIndex = 0;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(120, 42);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(200, 22);
            this.textBoxQuantity.TabIndex = 1;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(120, 70);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(200, 22);
            this.textBoxAmount.TabIndex = 2;
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(12, 15);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(55, 16);
            this.labelProduct.TabIndex = 3;
            this.labelProduct.Text = "Товар:";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(12, 45);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(77, 16);
            this.labelQuantity.TabIndex = 4;
            this.labelQuantity.Text = "Количество:";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(12, 73);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(50, 16);
            this.labelAmount.TabIndex = 5;
            this.labelAmount.Text = "Сумма:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(120, 98);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(230, 98);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormAddEditContractItem
            // 
            this.ClientSize = new System.Drawing.Size(344, 138);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.comboBoxProduct);
            this.Name = "FormAddEditContractItem";
            this.Text = "Добавить / Изменить элемент договора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
