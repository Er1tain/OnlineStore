using System;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
{
    public partial class FormAddEditInvoiceItem : Form
    {
        private NpgsqlConnection con;
        private int invoiceId;
        private int? invoiceItemId;

        public FormAddEditInvoiceItem(NpgsqlConnection con, int invoiceId, int? invoiceItemId = null)
        {
            InitializeComponent();
            this.con = con;
            this.invoiceId = invoiceId;
            this.invoiceItemId = invoiceItemId;
            LoadProducts();

            if (invoiceItemId.HasValue)
            {
                LoadInvoiceItemData(invoiceItemId.Value);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите товар.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (invoiceItemId.HasValue)
            {
                UpdateInvoiceItem();
            }
            else
            {
                AddInvoiceItem();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
