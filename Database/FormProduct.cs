using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;
using System.IO;

namespace OnlineStore
{
    public partial class FormProduct : Form
    {
        private void LoadData()
        {
            string sql = "SELECT * FROM Products";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["productid"].HeaderText = "Номер";
            dataGridView1.Columns["productname"].HeaderText = "Наименование";
            dataGridView1.Columns["price"].HeaderText = "Цена";
        }
    }
}
