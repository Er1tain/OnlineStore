using System;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
