using System;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
{
    public partial class MainForm : Form
    {
        private NpgsqlConnection con;

        public MainForm()
        {
            InitializeComponent();
            string connString = "Server=localhost;Port=5432;UserId=postgres;Password=3Dj43MT1;Database=toystore";
            con = new NpgsqlConnection(connString);
            con.Open();
        }

        private void clientsButton_Click(object sender, EventArgs e)
        {
            FormClient formClient = new FormClient(con);
            formClient.ShowDialog();
        }

        private void contractsButton_Click(object sender, EventArgs e)
        {
            FormContract formContract = new FormContract(con);
            formContract.ShowDialog();
        }

        private void productsButton_Click(object sender, EventArgs e)
        {
            FormProduct formProduct = new FormProduct(con);
            formProduct.ShowDialog();
        }

        private void paymentsButton_Click(object sender, EventArgs e)
        {
            FormPayment formPayment = new FormPayment(con);
            formPayment.ShowDialog();
        }

        private void invoicesButton_Click(object sender, EventArgs e)
        {
            FormInvoice formInvoice = new FormInvoice(con);
            formInvoice.ShowDialog();
        }

        private void undeliveredReportButton_Click(object sender, EventArgs e)
        {
            FormReportUndeliveredItems formReportUndeliveredItems = new FormReportUndeliveredItems(con);
            formReportUndeliveredItems.ShowDialog();
        }

        private void unpaidReportButton_Click(object sender, EventArgs e)
        {
            FormReportUnpaidItems formReportUnpaidItems = new FormReportUnpaidItems(con);
            formReportUnpaidItems.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
