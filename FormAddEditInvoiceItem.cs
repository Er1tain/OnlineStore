using System;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
{
    public partial class FormAddEditInvoiceItem : Form
    {
        private NpgsqlConnection con;
        private int invoiceId;
        private int? invoiceItemId;

        public FormAddEditInvoiceItem(NpgsqlConnection con, int invoiceId, int? invoiceItemId = null)
        {
            InitializeComponent();
            this.con = con;
            this.invoiceId = invoiceId;
            this.invoiceItemId = invoiceItemId;
            LoadProducts();

            if (invoiceItemId.HasValue)
            {
                LoadInvoiceItemData(invoiceItemId.Value);
            }
        }

        private void LoadProducts()
        {
            string sql = "SELECT ProductID, ProductName FROM Products";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxProduct.Items.Add(new ComboboxItem
                    {
                        Text = reader["ProductName"].ToString(),
                        Value = (int)reader["ProductID"]
                    });
                }
            }

            comboBoxProduct.DisplayMember = "Text";
            comboBoxProduct.ValueMember = "Value";
        }

        private void LoadInvoiceItemData(int invoiceItemId)
        {
            string sql = "SELECT * FROM InvoiceItems WHERE InvoiceItemID = @InvoiceItemID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@InvoiceItemID", invoiceItemId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBoxProduct.SelectedValue = (int)reader["ProductID"];
                        textBoxQuantity.Text = reader["Quantity"].ToString();
                        textBoxAmount.Text = reader["Amount"].ToString();
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите товар.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (invoiceItemId.HasValue)
            {
                UpdateInvoiceItem();
            }
            else
            {
                AddInvoiceItem();
            }
        }

        private void AddInvoiceItem()
        {
            string sql = "INSERT INTO InvoiceItems (InvoiceID, ProductID, Quantity, Amount) VALUES (@InvoiceID, @ProductID, @Quantity, @Amount)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                cmd.Parameters.AddWithValue("@ProductID", ((ComboboxItem)comboBoxProduct.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBoxQuantity.Text));
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBoxAmount.Text));
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void UpdateInvoiceItem()
        {
            string sql = "UPDATE InvoiceItems SET ProductID = @ProductID, Quantity = @Quantity, Amount = @Amount WHERE InvoiceItemID = @InvoiceItemID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductID", ((ComboboxItem)comboBoxProduct.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBoxQuantity.Text));
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBoxAmount.Text));
                cmd.Parameters.AddWithValue("@InvoiceItemID", invoiceItemId.Value);
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
