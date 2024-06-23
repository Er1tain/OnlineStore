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
        private void LoadData()
        {
            string sql = "SELECT * FROM Invoices";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["invoiceid"].HeaderText = "Номер";
            dataGridView1.Columns["clientid"].HeaderText = "ID Клиента";
            dataGridView1.Columns["invoicedate"].HeaderText = "Дата накладной";
            dataGridView1.Columns["totalsum"].HeaderText = "Итоговая сумма";
        }
    }
}
