namespace OnlineStore;

public partial class FormProducts : Form{
    private System.ComponentModel.IContainer components = null;

    private Label CountProducts = new Label();
    private TextBox InputCountProducts = new TextBox();

    private Label NameProducts = new Label();
    private TextBox InputNameProducts = new TextBox();

    private void InitializeComponent()
    {
        //Позиционируем подписи и соответствующие поля ввода
        NameProducts.Location = new Point(245, 70);
        NameProducts.Name = "NameProducts";
        NameProducts.Text = "Наименование\nтовара";
        NameProducts.Size = new Size(170, 38);
        Controls.Add(NameProducts);

        InputNameProducts.Location = new Point(305, 70);
        InputNameProducts.Name = "NameProducts";
        InputNameProducts.Size = new Size(200, 38);
        InputNameProducts.TextAlign = HorizontalAlignment.Center;
        Controls.Add(InputNameProducts);


        CountProducts.Location = new Point(245, 120);
        CountProducts.Name = "CountProducts";
        CountProducts.Text = "кол-во\nтовара";
        CountProducts.Size = new Size(170, 38);
        Controls.Add(CountProducts);

        InputCountProducts.Location = new Point(305, 120);
        InputCountProducts.Name = "CountProducts";
        InputCountProducts.Size = new Size(200, 38);
        InputCountProducts.TextAlign = HorizontalAlignment.Center;
        Controls.Add(InputCountProducts);

        components = new System.ComponentModel.Container();
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Text = "Товары";
        
    }
    public FormProducts()
    {   
        InitializeComponent();
    }
}