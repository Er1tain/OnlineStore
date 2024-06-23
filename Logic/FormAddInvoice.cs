using System;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
{
    public partial class FormAddInvoice : Form
    {
        private NpgsqlConnection con;
        private int? invoiceId;

        public FormAddInvoice(NpgsqlConnection con, int? invoiceId = null, int? clientId = null, DateTime? invoiceDate = null, decimal? totalSum = null)
        {
            InitializeComponent();
            this.con = con;
            this.invoiceId = invoiceId;
            LoadClients();

            if (invoiceId.HasValue)
            {
                comboBoxClient.SelectedValue = clientId;
                dateTimePickerInvoiceDate.Value = invoiceDate ?? DateTime.Now;
                textBoxTotalSum.Text = totalSum?.ToString() ?? string.Empty;
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
