using System;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
{
    public partial class FormAddEditClient : Form
    {
        private NpgsqlConnection con;
        private int? clientId;

        public FormAddEditClient(NpgsqlConnection con, int? clientId = null)
        {
            InitializeComponent();
            this.con = con;
            this.clientId = clientId;

            if (clientId.HasValue)
            {
                LoadClientData(clientId.Value);
            }
        }

        private void LoadClientData(int clientId)
        {
            string sql = "SELECT * FROM Clients WHERE ClientID = @ClientID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ClientID", clientId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBoxName.Text = reader["ClientName"].ToString();
                        textBoxPhone.Text = reader["Phone"].ToString();
                        textBoxAddress.Text = reader["Address"].ToString();
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (clientId.HasValue)
            {
                UpdateClient();
            }
            else
            {
                AddClient();
            }
        }

        private void AddClient()
        {
            string sql = "INSERT INTO Clients (ClientName, Phone, Address) VALUES (@ClientName, @Phone, @Address)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ClientName", textBoxName.Text);
                cmd.Parameters.AddWithValue("@Phone", textBoxPhone.Text);
                cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void UpdateClient()
        {
            string sql = "UPDATE Clients SET ClientName = @ClientName, Phone = @Phone, Address = @Address WHERE ClientID = @ClientID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ClientName", textBoxName.Text);
                cmd.Parameters.AddWithValue("@Phone", textBoxPhone.Text);
                cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("@ClientID", clientId.Value);
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
