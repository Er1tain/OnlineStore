using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using OfficeOpenXml;

namespace ShaydarovEnterprise
{
    public partial class FormContract : Form
    {
        private NpgsqlConnection con;
        private DataTable dt;
        private DataSet ds;

        public FormContract(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            LoadData();
        }

        private void LoadData()
        {
            string sql = "SELECT * FROM Contracts";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["contractid"].HeaderText = "Номер";
            dataGridView1.Columns["clientid"].HeaderText = "ID Клиента";
            dataGridView1.Columns["contractdate"].HeaderText = "Дата договора";
            dataGridView1.Columns["prepayment"].HeaderText = "Предоплата";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            FormAddEditContract formAddEditContract = new FormAddEditContract(con);
            formAddEditContract.ShowDialog();
            LoadData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["contractid"].Value;
                string sql = "DELETE FROM Contracts WHERE ContractID = @ContractID";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ContractID", id);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["contractid"].Value;
                FormAddEditContract formAddEditContract = new FormAddEditContract(con, id);
                formAddEditContract.ShowDialog();
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
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Contracts");
                ws.Cells["A1"].LoadFromDataTable(dataTable, true);
                FileInfo fi = new FileInfo(filePath);
                pck.SaveAs(fi);
            }
        }

        private void manageItemsButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["contractid"].Value;
                FormContractItems formContractItems = new FormContractItems(con, id);
                formContractItems.ShowDialog();
                LoadData();
            }
        }
    }
}
