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
    }
}
