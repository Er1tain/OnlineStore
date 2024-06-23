namespace OnlineStore
{
    partial class FormAddEditInvoice
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.DateTimePicker dateTimePickerInvoiceDate;
        private System.Windows.Forms.TextBox textBoxTotalSum;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label labelInvoiceDate;
        private System.Windows.Forms.Label labelTotalSum;
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
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxTotalSum = new System.Windows.Forms.TextBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.labelInvoiceDate = new System.Windows.Forms.Label();
            this.labelTotalSum = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(120, 12);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(200, 24);
            this.comboBoxClient.TabIndex = 0;
            // 
            // dateTimePickerInvoiceDate
            // 
            this.dateTimePickerInvoiceDate.Location = new System.Drawing.Point(120, 42);
            this.dateTimePickerInvoiceDate.Name = "dateTimePickerInvoiceDate";
            this.dateTimePickerInvoiceDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerInvoiceDate.TabIndex = 1;
            // 
            // textBoxTotalSum
            // 
            this.textBoxTotalSum.Location = new System.Drawing.Point(120, 70);
            this.textBoxTotalSum.Name = "textBoxTotalSum";
            this.textBoxTotalSum.Size = new System.Drawing.Size(200, 22);
            this.textBoxTotalSum.TabIndex = 2;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(12, 15);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(63, 16);
            this.labelClient.TabIndex = 3;
            this.labelClient.Text = "Клиент:";
            // 
            // labelInvoiceDate
            // 
            this.labelInvoiceDate.AutoSize = true;
            this.labelInvoiceDate.Location = new System.Drawing.Point(12, 45);
            this.labelInvoiceDate.Name = "labelInvoiceDate";
            this.labelInvoiceDate.Size = new System.Drawing.Size(102, 16);
            this.labelInvoiceDate.TabIndex = 4;
            this.labelInvoiceDate.Text = "Дата накладной:";
            // 
            // labelTotalSum
            // 
            this.labelTotalSum.AutoSize = true;
            this.labelTotalSum.Location = new System.Drawing.Point(12, 73);
            this.labelTotalSum.Name = "labelTotalSum";
            this.labelTotalSum.Size = new System.Drawing.Size(50, 16);
            this.labelTotalSum.TabIndex = 5;
            this.labelTotalSum.Text = "Сумма:";
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
            // FormAddEditInvoice
            // 
            this.ClientSize = new System.Drawing.Size(344, 138);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.labelTotalSum);
            this.Controls.Add(this.labelInvoiceDate);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.textBoxTotalSum);
            this.Controls.Add(this.dateTimePickerInvoiceDate);
            this.Controls.Add(this.comboBoxClient);
            this.Name = "FormAddEditInvoice";
            this.Text = "Добавить / Изменить накладную";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
