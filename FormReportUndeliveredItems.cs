using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;
using System.IO;

namespace ShaydarovEnterprise
{
    public partial class FormReportUndeliveredItems : Form
    {
        private NpgsqlConnection con;
        private DataTable dt;

        public FormReportUndeliveredItems(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            GenerateReport(startDate, endDate);
        }

        private void GenerateReport(DateTime startDate, DateTime endDate)
        {
            string sql = @"
                SELECT 
                    ci.ProductID, 
                    p.ProductName, 
                    ci.Quantity, 
                    ci.Amount 
                FROM 
                    ContractItems ci
                JOIN 
                    Products p ON ci.ProductID = p.ProductID
                JOIN 
                    Contracts c ON ci.ContractID = c.ContractID
                WHERE 
                    c.ContractDate BETWEEN @startDate AND @endDate
                    AND NOT EXISTS (
                        SELECT 1 
                        FROM InvoiceItems ii 
                        WHERE ii.ProductID = ci.ProductID
                    );";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("startDate", startDate);
                cmd.Parameters.AddWithValue("endDate", endDate);
                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
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
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("UndeliveredItemsReport");
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                FileInfo fi = new FileInfo(filePath);
                pck.SaveAs(fi);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
