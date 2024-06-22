using System.Windows.Forms;

namespace OnlineStore;

public partial class Form1 : Form
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Button ProductsButton;
    private System.Windows.Forms.Button ClientsButton;
    private System.Windows.Forms.Button InvoiceButton;
    private System.Windows.Forms.Button ReportButton;

    private void InitializeComponent()
    {
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
