using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;
using System.IO;

namespace OnlineStore
{
    public partial class FormInvoice : Form
    {
        private NpgsqlConnection con;
        private DataTable dt;
        private DataSet ds;

        public FormInvoice(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            LoadData();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            FormAddInvoice formAddInvoice = new FormAddInvoice(con);
            formAddInvoice.ShowDialog();
            LoadData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["invoiceid"].Value;
                string sql = "DELETE FROM Invoices WHERE InvoiceID = @InvoiceID";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@InvoiceID", id);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["invoiceid"].Value;
                int clientId = (int)dataGridView1.SelectedRows[0].Cells["clientid"].Value;
                DateTime invoiceDate = (DateTime)dataGridView1.SelectedRows[0].Cells["invoicedate"].Value;
                decimal totalSum = (decimal)dataGridView1.SelectedRows[0].Cells["totalsum"].Value;

                FormAddInvoice formAddInvoice = new FormAddInvoice(con, id, clientId, invoiceDate, totalSum);
                formAddInvoice.ShowDialog();
                LoadData();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Save an Excel File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                ExportToExcel(dt, saveFileDialog.FileName);
            }
        }

        private void ExportToExcel(DataTable dataTable, string filePath)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Invoices");
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                FileInfo fi = new FileInfo(filePath);
                pck.SaveAs(fi);
            }
        }

        private void manageItemsButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["invoiceid"].Value;
                FormInvoiceItems formInvoiceItems = new FormInvoiceItems(con, id);
                formInvoiceItems.ShowDialog();
                LoadData();
            }
        }
    }
}
