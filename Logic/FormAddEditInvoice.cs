using System;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
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

        private void LoadClients()
        {
            string sql = "SELECT ClientID, ClientName FROM Clients";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxClient.Items.Add(new
                    {
                        Text = reader["ClientName"].ToString(),
                        Value = (int)reader["ClientID"]
                    });
                }
            }

            comboBoxClient.DisplayMember = "Text";
            comboBoxClient.ValueMember = "Value";
        }

        private void LoadInvoiceData(int invoiceId)
        {
            string sql = "SELECT * FROM Invoices WHERE InvoiceID = @InvoiceID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBoxClient.SelectedValue = reader["ClientID"];
                        dateTimePickerInvoiceDate.Value = (DateTime)reader["InvoiceDate"];
                        textBoxTotalSum.Text = reader["TotalSum"].ToString();
                    }
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
                cmd.Parameters.AddWithValue("@ClientID", ((dynamic)comboBoxClient.SelectedItem).Value);
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
                cmd.Parameters.AddWithValue("@ClientID", ((dynamic)comboBoxClient.SelectedItem).Value);
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
