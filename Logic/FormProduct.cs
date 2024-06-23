using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;
using System.IO;

namespace OnlineStore
{
    public partial class FormProduct : Form
    {
        private NpgsqlConnection con;
        private DataTable dt;
        private DataSet ds;

        public FormProduct(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            LoadData();
        }

        private void LoadData()
        {
            string sql = "SELECT * FROM Products";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["productid"].HeaderText = "Номер";
            dataGridView1.Columns["productname"].HeaderText = "Наименование";
            dataGridView1.Columns["price"].HeaderText = "Цена";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            FormAddEditProduct formAddEditProduct = new FormAddEditProduct(con);
            formAddEditProduct.ShowDialog();
            LoadData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["productid"].Value;
                string sql = "DELETE FROM Products WHERE ProductID = @ProductID";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ProductID", id);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["productid"].Value;
                FormAddEditProduct formAddEditProduct = new FormAddEditProduct(con, id);
                formAddEditProduct.ShowDialog();
                LoadData();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Save an Excel File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                ExportToExcel(dt, saveFileDialog.FileName);
            }
        }

        private void ExportToExcel(DataTable dataTable, string filePath)
        {
            // Установка контекста лицензии
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet1");
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                FileInfo fi = new FileInfo(filePath);
                pck.SaveAs(fi);
            }
        }

    }
}
