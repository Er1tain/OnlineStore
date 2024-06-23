using System;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
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
