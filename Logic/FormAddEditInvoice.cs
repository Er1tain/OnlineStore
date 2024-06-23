using System;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
{
    public partial class FormAddEditInvoice : Form
    {
        private NpgsqlConnection con;
        private int? invoiceId;

        public FormAddEditInvoice(NpgsqlConnection con, int? invoiceId = null)
        {
            InitializeComponent();
            this.con = con;
            this.invoiceId = invoiceId;
            LoadClients(); // Загрузка клиентов при инициализации формы

            if (invoiceId.HasValue)
            {
                LoadInvoiceData(invoiceId.Value);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (invoiceId.HasValue)
            {
                UpdateInvoice();
            }
            else
            {
                AddInvoice();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
