namespace OnlineStore
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button clientsButton;
        private System.Windows.Forms.Button contractsButton;
        private System.Windows.Forms.Button productsButton;
        private System.Windows.Forms.Button paymentsButton;
        private System.Windows.Forms.Button invoicesButton;
        private System.Windows.Forms.Button undeliveredReportButton;
        private System.Windows.Forms.Button unpaidReportButton;
        private System.Windows.Forms.Button exitButton;

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
            this.clientsButton = new System.Windows.Forms.Button();
            this.contractsButton = new System.Windows.Forms.Button();
            this.productsButton = new System.Windows.Forms.Button();
            this.paymentsButton = new System.Windows.Forms.Button();
            this.invoicesButton = new System.Windows.Forms.Button();
            this.undeliveredReportButton = new System.Windows.Forms.Button();
            this.unpaidReportButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientsButton
            // 
            this.clientsButton.Location = new System.Drawing.Point(12, 12);
            this.clientsButton.Name = "clientsButton";
            this.clientsButton.Size = new System.Drawing.Size(200, 50);
            this.clientsButton.TabIndex = 0;
            this.clientsButton.Text = "Клиенты";
            this.clientsButton.UseVisualStyleBackColor = true;
            this.clientsButton.Click += new System.EventHandler(this.clientsButton_Click);
            // 
            // contractsButton
            // 
            this.contractsButton.Location = new System.Drawing.Point(12, 68);
            this.contractsButton.Name = "contractsButton";
            this.contractsButton.Size = new System.Drawing.Size(200, 50);
            this.contractsButton.TabIndex = 1;
            this.contractsButton.Text = "Договоры";
            this.contractsButton.UseVisualStyleBackColor = true;
            this.contractsButton.Click += new System.EventHandler(this.contractsButton_Click);
            // 
            // productsButton
            // 
            this.productsButton.Location = new System.Drawing.Point(12, 124);
            this.productsButton.Name = "productsButton";
            this.productsButton.Size = new System.Drawing.Size(200, 50);
            this.productsButton.TabIndex = 2;
            this.productsButton.Text = "Товары";
            this.productsButton.UseVisualStyleBackColor = true;
            this.productsButton.Click += new System.EventHandler(this.productsButton_Click);
            // 
            // paymentsButton
            // 
            this.paymentsButton.Location = new System.Drawing.Point(12, 180);
            this.paymentsButton.Name = "paymentsButton";
            this.paymentsButton.Size = new System.Drawing.Size(200, 50);
            this.paymentsButton.TabIndex = 3;
            this.paymentsButton.Text = "Оплаты";
            this.paymentsButton.UseVisualStyleBackColor = true;
            this.paymentsButton.Click += new System.EventHandler(this.paymentsButton_Click);
            // 
            // invoicesButton
            // 
            this.invoicesButton.Location = new System.Drawing.Point(12, 236);
            this.invoicesButton.Name = "invoicesButton";
            this.invoicesButton.Size = new System.Drawing.Size(200, 50);
            this.invoicesButton.TabIndex = 4;
            this.invoicesButton.Text = "Накладные";
            this.invoicesButton.UseVisualStyleBackColor = true;
            this.invoicesButton.Click += new System.EventHandler(this.invoicesButton_Click);
            // 
            // undeliveredReportButton
            // 
            this.undeliveredReportButton.Location = new System.Drawing.Point(12, 292);
            this.undeliveredReportButton.Name = "undeliveredReportButton";
            this.undeliveredReportButton.Size = new System.Drawing.Size(200, 50);
            this.undeliveredReportButton.TabIndex = 5;
            this.undeliveredReportButton.Text = "Отчет по неотгруженным";
            this.undeliveredReportButton.UseVisualStyleBackColor = true;
            this.undeliveredReportButton.Click += new System.EventHandler(this.undeliveredReportButton_Click);
            // 
            // unpaidReportButton
            // 
            this.unpaidReportButton.Location = new System.Drawing.Point(12, 348);
            this.unpaidReportButton.Name = "unpaidReportButton";
            this.unpaidReportButton.Size = new System.Drawing.Size(200, 50);
            this.unpaidReportButton.TabIndex = 6;
            this.unpaidReportButton.Text = "Отчет по неоплаченным";
            this.unpaidReportButton.UseVisualStyleBackColor = true;
            this.unpaidReportButton.Click += new System.EventHandler(this.unpaidReportButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 404);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(200, 50);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(224, 466);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.unpaidReportButton);
            this.Controls.Add(this.undeliveredReportButton);
            this.Controls.Add(this.invoicesButton);
            this.Controls.Add(this.paymentsButton);
            this.Controls.Add(this.productsButton);
            this.Controls.Add(this.contractsButton);
            this.Controls.Add(this.clientsButton);
            this.Name = "MainForm";
            this.Text = "Главное окно";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
