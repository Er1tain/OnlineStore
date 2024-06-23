namespace OnlineStore
{
    partial class FormAddEditPayment
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxContract;
        private System.Windows.Forms.DateTimePicker dateTimePickerPaymentDate;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.ComboBox comboBoxPaymentType;
        private System.Windows.Forms.Label labelContract;
        private System.Windows.Forms.Label labelPaymentDate;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelPaymentType;
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
            this.comboBoxContract = new System.Windows.Forms.ComboBox();
            this.dateTimePickerPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.comboBoxPaymentType = new System.Windows.Forms.ComboBox();
            this.labelContract = new System.Windows.Forms.Label();
            this.labelPaymentDate = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelPaymentType = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxContract
            // 
            this.comboBoxContract.FormattingEnabled = true;
            this.comboBoxContract.Location = new System.Drawing.Point(341, -3);
            this.comboBoxContract.Name = "comboBoxContract";
            this.comboBoxContract.Size = new System.Drawing.Size(200, 39);
            this.comboBoxContract.TabIndex = 0;
            // 
            // dateTimePickerPaymentDate
            // 
            this.dateTimePickerPaymentDate.Location = new System.Drawing.Point(356, 45);
            this.dateTimePickerPaymentDate.Name = "dateTimePickerPaymentDate";
            this.dateTimePickerPaymentDate.Size = new System.Drawing.Size(200, 38);
            this.dateTimePickerPaymentDate.TabIndex = 1;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(341, 89);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(200, 38);
            this.textBoxAmount.TabIndex = 2;
            // 
            // comboBoxPaymentType
            // 
            this.comboBoxPaymentType.FormattingEnabled = true;
            this.comboBoxPaymentType.Items.AddRange(new object[] {
            "Наличный",
            "Безналичный"});
            this.comboBoxPaymentType.Location = new System.Drawing.Point(341, 133);
            this.comboBoxPaymentType.Name = "comboBoxPaymentType";
            this.comboBoxPaymentType.Size = new System.Drawing.Size(200, 39);
            this.comboBoxPaymentType.TabIndex = 3;
            // 
            // labelContract
            // 
            this.labelContract.AutoSize = true;
            this.labelContract.Location = new System.Drawing.Point(12, 15);
            this.labelContract.Name = "labelContract";
            this.labelContract.Size = new System.Drawing.Size(134, 32);
            this.labelContract.TabIndex = 4;
            this.labelContract.Text = "Договор:";
            // 
            // labelPaymentDate
            // 
            this.labelPaymentDate.AutoSize = true;
            this.labelPaymentDate.Location = new System.Drawing.Point(12, 45);
            this.labelPaymentDate.Name = "labelPaymentDate";
            this.labelPaymentDate.Size = new System.Drawing.Size(193, 32);
            this.labelPaymentDate.TabIndex = 5;
            this.labelPaymentDate.Text = "Дата оплаты:";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(12, 73);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(112, 32);
            this.labelAmount.TabIndex = 6;
            this.labelAmount.Text = "Сумма:";
            // 
            // labelPaymentType
            // 
            this.labelPaymentType.AutoSize = true;
            this.labelPaymentType.Location = new System.Drawing.Point(12, 101);
            this.labelPaymentType.Name = "labelPaymentType";
            this.labelPaymentType.Size = new System.Drawing.Size(175, 32);
            this.labelPaymentType.TabIndex = 7;
            this.labelPaymentType.Text = "Тип оплаты:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(120, 128);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(230, 128);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormAddEditPayment
            // 
            this.ClientSize = new System.Drawing.Size(666, 291);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.labelPaymentType);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelPaymentDate);
            this.Controls.Add(this.labelContract);
            this.Controls.Add(this.comboBoxPaymentType);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.dateTimePickerPaymentDate);
            this.Controls.Add(this.comboBoxContract);
            this.Name = "FormAddEditPayment";
            this.Text = "Добавить / Изменить оплату";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
