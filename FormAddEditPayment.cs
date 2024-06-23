using System;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
{
    public partial class FormAddEditPayment : Form
    {
        private NpgsqlConnection con;
        private int? paymentId;

        public FormAddEditPayment(NpgsqlConnection con, int? paymentId = null)
        {
            InitializeComponent();
            this.con = con;
            this.paymentId = paymentId;
            LoadContracts(); // Загрузка договоров при инициализации формы

            if (paymentId.HasValue)
            {
                LoadPaymentData(paymentId.Value);
            }
        }

        private void LoadContracts()
        {
            string sql = "SELECT ContractID FROM Contracts";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxContract.Items.Add(new
                    {
                        Text = reader["ContractID"].ToString(),
                        Value = (int)reader["ContractID"]
                    });
                }
            }

            comboBoxContract.DisplayMember = "Text";
            comboBoxContract.ValueMember = "Value";
        }

        private void LoadPaymentData(int paymentId)
        {
            string sql = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@PaymentID", paymentId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        comboBoxContract.SelectedValue = reader["ContractID"];
                        dateTimePickerPaymentDate.Value = (DateTime)reader["PaymentDate"];
                        textBoxAmount.Text = reader["Amount"].ToString();
                        comboBoxPaymentType.SelectedItem = reader["PaymentType"].ToString();
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (paymentId.HasValue)
            {
                UpdatePayment();
            }
            else
            {
                AddPayment();
            }
        }

        private void AddPayment()
        {
            string sql = "INSERT INTO Payments (ContractID, PaymentDate, Amount, PaymentType) VALUES (@ContractID, @PaymentDate, @Amount, @PaymentType)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ContractID", ((dynamic)comboBoxContract.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@PaymentDate", dateTimePickerPaymentDate.Value);
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBoxAmount.Text));
                cmd.Parameters.AddWithValue("@PaymentType", comboBoxPaymentType.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void UpdatePayment()
        {
            string sql = "UPDATE Payments SET ContractID = @ContractID, PaymentDate = @PaymentDate, Amount = @Amount, PaymentType = @PaymentType WHERE PaymentID = @PaymentID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ContractID", ((dynamic)comboBoxContract.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@PaymentDate", dateTimePickerPaymentDate.Value);
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBoxAmount.Text));
                cmd.Parameters.AddWithValue("@PaymentType", comboBoxPaymentType.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@PaymentID", paymentId.Value);
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
