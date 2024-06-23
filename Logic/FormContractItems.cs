using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
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
