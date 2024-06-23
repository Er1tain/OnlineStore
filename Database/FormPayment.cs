using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
{
    public partial class FormPayment : Form
    {
        private void LoadData()
        {
            string sql = "SELECT * FROM Payments";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["paymentid"].HeaderText = "Номер";
            dataGridView1.Columns["contractid"].HeaderText = "ID Договора";
            dataGridView1.Columns["paymentdate"].HeaderText = "Дата оплаты";
            dataGridView1.Columns["amount"].HeaderText = "Сумма";
            dataGridView1.Columns["paymenttype"].HeaderText = "Тип оплаты";
        }
    }
}
