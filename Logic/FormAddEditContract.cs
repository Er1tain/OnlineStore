using System;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
{
    public partial class FormAddEditContract : Form
    {
        private NpgsqlConnection con;
        private int? contractId;

        public FormAddEditContract(NpgsqlConnection con, int? contractId = null)
        {
            InitializeComponent();
            this.con = con;
            this.contractId = contractId;
            LoadClients();

            if (contractId.HasValue)
            {
                LoadContractData(contractId.Value);
            }
        }

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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (comboBoxClient.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (contractId.HasValue)
            {
                UpdateContract();
            }
            else
            {
                AddContract();
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
