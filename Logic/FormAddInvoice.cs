using System;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
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

        private void LoadClients()
        {
            string sql = "SELECT ClientID, ClientName FROM Clients";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxClient.Items.Add(new ComboboxItem
                    {
                        Text = reader["ClientName"].ToString(),
                        Value = (int)reader["ClientID"]
                    });
                }
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

        private void AddInvoice()
        {
            string sql = "INSERT INTO Invoices (ClientID, InvoiceDate, TotalSum) VALUES (@ClientID, @InvoiceDate, @TotalSum)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ClientID", ((ComboboxItem)comboBoxClient.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePickerInvoiceDate.Value);
                cmd.Parameters.AddWithValue("@TotalSum", decimal.Parse(textBoxTotalSum.Text));
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void UpdateInvoice()
        {
            string sql = "UPDATE Invoices SET ClientID = @ClientID, InvoiceDate = @InvoiceDate, TotalSum = @TotalSum WHERE InvoiceID = @InvoiceID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ClientID", ((ComboboxItem)comboBoxClient.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePickerInvoiceDate.Value);
                cmd.Parameters.AddWithValue("@TotalSum", decimal.Parse(textBoxTotalSum.Text));
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId.Value);
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
