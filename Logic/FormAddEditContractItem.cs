using System;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
{
    public partial class FormAddEditContractItem : Form
    {
        private NpgsqlConnection con;
        private int? contractItemId;
        private int contractId;

        public FormAddEditContractItem(NpgsqlConnection con, int contractId, int? contractItemId = null)
        {
            InitializeComponent();
            this.con = con;
            this.contractId = contractId;
            this.contractItemId = contractItemId;
            LoadProducts();

            if (contractItemId.HasValue)
            {
                LoadContractItemData(contractItemId.Value);
            }
        }

        private void LoadProducts()
        {
            string sql = "SELECT ProductID, ProductName FROM Products";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxProduct.Items.Add(new
                    {
                        Text = reader["ProductName"].ToString(),
                        Value = (int)reader["ProductID"]
                    });
                }
            }

            comboBoxProduct.DisplayMember = "Text";
            comboBoxProduct.ValueMember = "Value";
        }

        private void LoadContractItemData(int contractItemId)
        {
            string sql = "SELECT * FROM ContractItems WHERE ContractItemID = @ContractItemID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ContractItemID", contractItemId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBoxProduct.SelectedValue = reader["ProductID"];
                        textBoxQuantity.Text = reader["Quantity"].ToString();
                        textBoxAmount.Text = reader["Amount"].ToString();
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (contractItemId.HasValue)
            {
                UpdateContractItem();
            }
            else
            {
                AddContractItem();
            }
        }

        private void AddContractItem()
        {
            string sql = "INSERT INTO ContractItems (ContractID, ProductID, Quantity, Amount) VALUES (@ContractID, @ProductID, @Quantity, @Amount)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ContractID", contractId);
                cmd.Parameters.AddWithValue("@ProductID", ((dynamic)comboBoxProduct.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBoxQuantity.Text));
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBoxAmount.Text));
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void UpdateContractItem()
        {
            string sql = "UPDATE ContractItems SET ProductID = @ProductID, Quantity = @Quantity, Amount = @Amount WHERE ContractItemID = @ContractItemID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductID", ((dynamic)comboBoxProduct.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBoxQuantity.Text));
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBoxAmount.Text));
                cmd.Parameters.AddWithValue("@ContractItemID", contractItemId.Value);
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
