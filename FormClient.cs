using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;

namespace ShaydarovEnterprise
{
    public partial class FormClient : Form
    {
        private NpgsqlConnection con;
        private DataTable dt;
        private DataSet ds;

        public FormClient(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            LoadData();
        }

        private void LoadData()
        {
            string sql = "SELECT * FROM Clients";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["clientid"].HeaderText = "Номер";
            dataGridView1.Columns["clientname"].HeaderText = "Наименование";
            dataGridView1.Columns["phone"].HeaderText = "Телефон";
            dataGridView1.Columns["address"].HeaderText = "Адрес";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            FormAddEditClient formAddEditClient = new FormAddEditClient(con);
            formAddEditClient.ShowDialog();
            LoadData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["clientid"].Value;
                string sql = "DELETE FROM Clients WHERE ClientID = @ClientID";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ClientID", id);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["clientid"].Value;
                FormAddEditClient formAddEditClient = new FormAddEditClient(con, id);
                formAddEditClient.ShowDialog();
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
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Clients");
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                FileInfo fi = new FileInfo(filePath);
                pck.SaveAs(fi);
            }
        }
    }
}
