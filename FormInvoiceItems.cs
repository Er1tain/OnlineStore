using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
{
    public partial class FormInvoiceItems : Form
    {
        private NpgsqlConnection con;
        private int invoiceId;
        private DataTable dt;
        private DataSet ds;

        public FormInvoiceItems(NpgsqlConnection con, int invoiceId)
        {
            InitializeComponent();
            this.con = con;
            this.invoiceId = invoiceId;
            LoadData();
        }

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

        private void addButton_Click(object sender, EventArgs e)
        {
            FormAddEditInvoiceItem formAddEditInvoiceItem = new FormAddEditInvoiceItem(con, invoiceId);
            formAddEditInvoiceItem.ShowDialog();
            LoadData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["InvoiceItemID"].Value;
                string sql = "DELETE FROM InvoiceItems WHERE InvoiceItemID = @InvoiceItemID";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@InvoiceItemID", id);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["InvoiceItemID"].Value;
                FormAddEditInvoiceItem formAddEditInvoiceItem = new FormAddEditInvoiceItem(con, invoiceId, id);
                formAddEditInvoiceItem.ShowDialog();
                LoadData();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
