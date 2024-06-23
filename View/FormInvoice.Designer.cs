namespace OnlineStore
{
    partial class FormInvoice
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button manageItemsButton;

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
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.manageItemsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 400);
            this.dataGridView1.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 430);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 30);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(130, 430);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 30);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(250, 430);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 30);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Изменить";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(370, 430);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 30);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Экспорт";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(670, 430);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 30);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // manageItemsButton
            // 
            this.manageItemsButton.Location = new System.Drawing.Point(490, 430);
            this.manageItemsButton.Name = "manageItemsButton";
            this.manageItemsButton.Size = new System.Drawing.Size(150, 30);
            this.manageItemsButton.TabIndex = 6;
            this.manageItemsButton.Text = "Управление элементами";
            this.manageItemsButton.UseVisualStyleBackColor = true;
            this.manageItemsButton.Click += new System.EventHandler(this.manageItemsButton_Click);
            // 
            // FormInvoice
            // 
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.manageItemsButton);
            this.Name = "FormInvoice";
            this.Text = "Управление накладными";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
