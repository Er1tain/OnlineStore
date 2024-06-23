using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
{
    public partial class FormInvoiceItems : Form
    {
        private void LoadData()
        {
            string sql = "SELECT ii.InvoiceItemID, p.ProductName, ii.Quantity, ii.Amount FROM InvoiceItems ii JOIN Products p ON ii.ProductID = p.ProductID WHERE ii.InvoiceID = @InvoiceID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["InvoiceItemID"].Visible = false;
                dataGridView1.Columns["ProductName"].HeaderText = "Товар";
                dataGridView1.Columns["Quantity"].HeaderText = "Количество";
                dataGridView1.Columns["Amount"].HeaderText = "Сумма";
            }
        }
    }
}
