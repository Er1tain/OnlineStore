using System;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
