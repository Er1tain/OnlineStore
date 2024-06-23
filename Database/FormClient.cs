using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;

namespace OnlineStore
{
    public partial class FormClient : Form
    {
        private void LoadData()
        {
            string sql = "SELECT * FROM Clients";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["clientid"].HeaderText = "Номер";
            dataGridView1.Columns["clientname"].HeaderText = "Наименование";
            dataGridView1.Columns["phone"].HeaderText = "Телефон";
            dataGridView1.Columns["address"].HeaderText = "Адрес";
        }
    }
}
