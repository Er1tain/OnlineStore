using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;
using System.IO;

namespace OnlineStore
{
    public partial class FormReportUnpaidItems : Form
    {
        private NpgsqlConnection con;
        private DataTable dt;

        public FormReportUnpaidItems(NpgsqlConnection con)
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
                    i.InvoiceDate, 
                    SUM(ii.Amount) AS UnpaidAmount 
                FROM 
                    Invoices i
                JOIN 
                    InvoiceItems ii ON i.InvoiceID = ii.InvoiceID
                LEFT JOIN 
                    Payments p ON p.ContractID = i.InvoiceID
                WHERE 
                    i.InvoiceDate BETWEEN @startDate AND @endDate
                    AND p.PaymentID IS NULL
                GROUP BY 
                    i.InvoiceDate;";

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
            // Установка контекста лицензии
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
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
