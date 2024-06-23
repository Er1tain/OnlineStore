using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;
using System.IO;

namespace OnlineStore
{
    public partial class FormReportUndeliveredItems : Form
    {
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
    }
}
