using System;
using System.Windows.Forms;
using Npgsql;

namespace ShaydarovEnterprise
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

        private void LoadProductData(int productId)
        {
            string sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductID", productId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBoxName.Text = reader["ProductName"].ToString();
                        textBoxPrice.Text = reader["Price"].ToString();
                    }
                }
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

        private void AddProduct()
        {
            string sql = "INSERT INTO Products (ProductName, Price) VALUES (@ProductName, @Price)";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductName", textBoxName.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(textBoxPrice.Text));
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void UpdateProduct()
        {
            string sql = "UPDATE Products SET ProductName = @ProductName, Price = @Price WHERE ProductID = @ProductID";
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ProductName", textBoxName.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(textBoxPrice.Text));
                cmd.Parameters.AddWithValue("@ProductID", productId.Value);
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
