using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
{
    public partial class FormContractItems : Form
    {
        private void LoadData()
        {
            string sql = "SELECT ci.ContractItemID, p.ProductName, ci.Quantity, ci.Amount FROM ContractItems ci JOIN Products p ON ci.ProductID = p.ProductID WHERE ci.ContractID = @ContractID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ContractID", contractId);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["ContractItemID"].Visible = false;
                dataGridView1.Columns["ProductName"].HeaderText = "Товар";
                dataGridView1.Columns["Quantity"].HeaderText = "Количество";
                dataGridView1.Columns["Amount"].HeaderText = "Сумма";
            }
        }
    }
}
