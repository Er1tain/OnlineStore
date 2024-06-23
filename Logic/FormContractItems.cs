using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
{
    public partial class FormContractItems : Form
    {
        private NpgsqlConnection con;
        private int contractId;
        private DataTable dt;
        private DataSet ds;

        public FormContractItems(NpgsqlConnection con, int contractId)
        {
            InitializeComponent();
            this.con = con;
            this.contractId = contractId;
            LoadData();
        }

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

        private void addButton_Click(object sender, EventArgs e)
        {
            FormAddEditContractItem formAddEditContractItem = new FormAddEditContractItem(con, contractId);
            formAddEditContractItem.ShowDialog();
            LoadData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["ContractItemID"].Value;
                string sql = "DELETE FROM ContractItems WHERE ContractItemID = @ContractItemID";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ContractItemID", id);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["ContractItemID"].Value;
                FormAddEditContractItem formAddEditContractItem = new FormAddEditContractItem(con, contractId, id);
                formAddEditContractItem.ShowDialog();
                LoadData();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
