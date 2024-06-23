using System;
using System.Windows.Forms;
using Npgsql;

namespace OnlineStore
{
    public partial class FormAddEditProduct : Form
    {
        private NpgsqlConnection con;
        private int? productId;

        public FormAddEditProduct(NpgsqlConnection con, int? productId = null)
        {
            InitializeComponent();
            this.con = con;
            this.productId = productId;

            if (productId.HasValue)
            {
                LoadProductData(productId.Value);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (productId.HasValue)
            {
                UpdateProduct();
            }
            else
            {
                AddProduct();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
