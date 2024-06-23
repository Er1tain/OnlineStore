using System;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
{
    public partial class FormAddEditContract : Form
    {
        private void LoadClients()
        {
            string sql = "SELECT ClientID, ClientName FROM Clients";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxClient.Items.Add(new ComboboxItem
                    {
                        Text = reader["ClientName"].ToString(),
                        Value = (int)reader["ClientID"]
                    });
                }
            }

            comboBoxClient.DisplayMember = "Text";
            comboBoxClient.ValueMember = "Value";
        }

        private void LoadContractData(int contractId)
        {
            string sql = "SELECT * FROM Contracts WHERE ContractID = @ContractID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ContractID", contractId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBoxClient.SelectedValue = (int)reader["ClientID"];
                        dateTimePickerContractDate.Value = (DateTime)reader["ContractDate"];
                        textBoxPrepayment.Text = reader["Prepayment"].ToString();
                    }
                }
            }
        }

        private void AddContract()
        {
            string sql = "INSERT INTO Contracts (ClientID, ContractDate, Prepayment) VALUES (@ClientID, @ContractDate, @Prepayment)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ClientID", ((ComboboxItem)comboBoxClient.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@ContractDate", dateTimePickerContractDate.Value);
                cmd.Parameters.AddWithValue("@Prepayment", decimal.Parse(textBoxPrepayment.Text));
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void UpdateContract()
        {
            string sql = "UPDATE Contracts SET ClientID = @ClientID, ContractDate = @ContractDate, Prepayment = @Prepayment WHERE ContractID = @ContractID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ClientID", ((ComboboxItem)comboBoxClient.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@ContractDate", dateTimePickerContractDate.Value);
                cmd.Parameters.AddWithValue("@Prepayment", decimal.Parse(textBoxPrepayment.Text));
                cmd.Parameters.AddWithValue("@ContractID", contractId.Value);
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

    }

}
