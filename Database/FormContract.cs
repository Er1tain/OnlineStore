using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;

namespace OnlineStore
{
    public partial class FormContract : Form
    {
        private void LoadData()
        {
            string sql = "SELECT * FROM Contracts";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["contractid"].HeaderText = "Номер";
            dataGridView1.Columns["clientid"].HeaderText = "ID Клиента";
            dataGridView1.Columns["contractdate"].HeaderText = "Дата договора";
            dataGridView1.Columns["prepayment"].HeaderText = "Предоплата";
        }
    }
}
