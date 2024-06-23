namespace OnlineStore
{
    partial class FormReportUnpaidItems
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;

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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.generateButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 350);
            this.dataGridView1.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(12, 430);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 30);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(130, 430);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 30);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Экспорт";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(670, 430);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 30);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(130, 12);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerStart.TabIndex = 4;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(570, 12);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerEnd.TabIndex = 5;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(12, 15);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(112, 16);
            this.labelStartDate.TabIndex = 6;
            this.labelStartDate.Text = "Дата начала:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(452, 15);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(112, 16);
            this.labelEndDate.TabIndex = 7;
            this.labelEndDate.Text = "Дата окончания:";
            // 
            // FormReportUnpaidItems
            // 
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.exitButton);
            this.Name = "FormReportUnpaidItems";
            this.Text = "Отчет по неоплаченным товарам";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
