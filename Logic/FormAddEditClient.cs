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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
