namespace OnlineStore
{
    partial class FormAddInvoice
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.DateTimePicker dateTimePickerInvoiceDate;
        private System.Windows.Forms.TextBox textBoxTotalSum;
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

        private void InitializeComponent()
        {
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxTotalSum = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(252, 3);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(200, 39);
            this.comboBoxClient.TabIndex = 0;
            // 
            // dateTimePickerInvoiceDate
            // 
            this.dateTimePickerInvoiceDate.Location = new System.Drawing.Point(252, 62);
            this.dateTimePickerInvoiceDate.Name = "dateTimePickerInvoiceDate";
            this.dateTimePickerInvoiceDate.Size = new System.Drawing.Size(200, 38);
            this.dateTimePickerInvoiceDate.TabIndex = 1;
            // 
            // textBoxTotalSum
            // 
            this.textBoxTotalSum.Location = new System.Drawing.Point(252, 116);
            this.textBoxTotalSum.Name = "textBoxTotalSum";
            this.textBoxTotalSum.Size = new System.Drawing.Size(200, 38);
            this.textBoxTotalSum.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(252, 171);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(350, 171);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormAddInvoice
            // 
            this.ClientSize = new System.Drawing.Size(679, 335);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.textBoxTotalSum);
            this.Controls.Add(this.dateTimePickerInvoiceDate);
            this.Controls.Add(this.comboBoxClient);
            this.Name = "FormAddInvoice";
            this.Text = "Добавить накладную";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
