using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ShopBanGiay
{
	public partial class frmDSMH : Form
	{
		string connectionString = @"Data Source=DESKTOP-E3V9138;Initial Catalog=SHOESSHOP2;Integrated Security=True;";

		public frmDSMH()
		{
			InitializeComponent();
		}

		private void frmDSMH_Load(object sender, EventArgs e)
		{
			LoadDataFromSQL();
			ThemDataVaoCbb();
			
		}

		private void LoadDataFromSQL()
		{
			string query = @"
                SELECT 
                    S.IDSanPham,
                    S.TenSanPham,
                    S.ThuongHieu,
                    S.Loai,
                    S.Gia,
                    SS.Size,
                    SC.Mau,
                    SI.Quantity,
                    S.enable
                FROM ShoeInventory SI
                JOIN SanPham S ON SI.IDSanPham = S.IDSanPham
                JOIN SizeSanPham SS ON SI.IDSize = SS.IDSize
                JOIN MauSanPham SC ON SI.IDMau = SC.IDMau;";

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();
					SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
					DataTable dataTable = new DataTable();
					adapter.Fill(dataTable);
					dataGridView1.DataSource = dataTable;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi: {ex.Message}");
				}
			}
		}
		void ThemDataVaoCbb()
		{
			// Xóa tất cả các mục hiện tại trong ComboBox
			comboBox1.Items.Clear();

			if (dataGridView1.Columns.Count > 0)
			{
				
				foreach (DataColumn col in ((DataTable)dataGridView1.DataSource).Columns)
				{
					comboBox1.Items.Add(col.ColumnName);
				}
			}
			else
			{
				MessageBox.Show("DataGridView không có dữ liệu hoặc cột.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}


		public static void GroupDataGridView(DataGridView dgv, string columnName)
		{
			
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedItem = comboBox1.SelectedItem.ToString();
			GroupDataGridView(dataGridView1, selectedItem);
		}
	}

}
