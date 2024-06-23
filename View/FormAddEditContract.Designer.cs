namespace OnlineStore
{
    partial class FormAddEditContract
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.DateTimePicker dateTimePickerContractDate;
        private System.Windows.Forms.TextBox textBoxPrepayment;
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
            this.dateTimePickerContractDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxPrepayment = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(280, 12);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(200, 39);
            this.comboBoxClient.TabIndex = 0;
            // 
            // dateTimePickerContractDate
            // 
            this.dateTimePickerContractDate.Location = new System.Drawing.Point(280, 65);
            this.dateTimePickerContractDate.Name = "dateTimePickerContractDate";
            this.dateTimePickerContractDate.Size = new System.Drawing.Size(200, 38);
            this.dateTimePickerContractDate.TabIndex = 1;
            // 
            // textBoxPrepayment
            // 
            this.textBoxPrepayment.Location = new System.Drawing.Point(280, 118);
            this.textBoxPrepayment.Name = "textBoxPrepayment";
            this.textBoxPrepayment.Size = new System.Drawing.Size(200, 38);
            this.textBoxPrepayment.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(250, 206);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(379, 217);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormAddEditContract
            // 
            this.ClientSize = new System.Drawing.Size(670, 420);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.textBoxPrepayment);
            this.Controls.Add(this.dateTimePickerContractDate);
            this.Controls.Add(this.comboBoxClient);
            this.Name = "FormAddEditContract";
            this.Text = "Добавить/Редактировать договор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
