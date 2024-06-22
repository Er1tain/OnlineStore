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
        ClientsButton.Name = "ProductsButton";
        ClientsButton.Size = new System.Drawing.Size(200, 50);
        ClientsButton.TabIndex = 1;
        ClientsButton.Text = "Клиенты";
        Controls.Add(ClientsButton);

        
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
