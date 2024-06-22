using System;
using System.Windows.Forms;

namespace OnlineStore;

public partial class Form1 : Form
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Button ProductsButton = new System.Windows.Forms.Button();
    private System.Windows.Forms.Button ClientsButton = new System.Windows.Forms.Button();
    private System.Windows.Forms.Button InvoiceButton = new System.Windows.Forms.Button();
    private System.Windows.Forms.Button ReportButton = new System.Windows.Forms.Button();

    private void InitializeComponent()
    {
        //Кнопка для выбора приобретаемых товаров
        ProductsButton.Location = new System.Drawing.Point(12, 12);
        ProductsButton.Name = "ProductsButton";
        ProductsButton.Size = new System.Drawing.Size(200, 50);
        ProductsButton.TabIndex = 0;
        ProductsButton.Text = "Товары";
        Controls.Add(ProductsButton);

        //Кнопка для отображения списка клиентов
        ClientsButton.Location = new System.Drawing.Point(12, 68);
        ClientsButton.Name = "ClientsButton";
        ClientsButton.Size = new System.Drawing.Size(200, 50);
        ClientsButton.TabIndex = 1;
        ClientsButton.Text = "Клиенты";
        Controls.Add(ClientsButton);

        //Кнопка просмотра накладных
        InvoiceButton.Location = new System.Drawing.Point(12, 124);
        InvoiceButton.Name = "InvoiceButton";
        InvoiceButton.Size = new System.Drawing.Size(200, 50);
        InvoiceButton.TabIndex = 2;
        InvoiceButton.Text = "Накладные";
        Controls.Add(InvoiceButton);

        //Кнопка формирования отчёта
        ReportButton.Location = new System.Drawing.Point(12, 180);
        ReportButton.Name = "InvoiceButton";
        ReportButton.Size = new System.Drawing.Size(200, 50);
        ReportButton.TabIndex = 2;
        ReportButton.Text = "Накладные";
        Controls.Add(ReportButton);

        
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Главное окно";

    }

    public Form1()
    {
        InitializeComponent();
    }
}
