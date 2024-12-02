using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopBanGiay
{
	public partial class frmDoanhThu : Form
	{
		public frmDoanhThu()
		{
			InitializeComponent();
		}
		private void LoadBieuDoDoanhThu()
		{
			chartDT.Series.Clear();
			chartDT.Series.Add("DoanhThu");

			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=master;Integrated Security=True";
			string query = "SELECT FORMAT(NgayBan, 'MM/yyyy') AS Thang, SUM(TongTien) AS TongDoanhThu FROM HoaDon GROUP BY FORMAT(NgayBan, 'MM/yyyy') ORDER BY FORMAT(NgayBan, 'MM/yyyy')";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(query, connection))
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							string thang = reader["Thang"].ToString();
							decimal tongDoanhThu = Convert.ToDecimal(reader["TongDoanhThu"]);
							chartDT.Series["DoanhThu"].Points.AddXY(thang, tongDoanhThu);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải biểu đồ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void chartDT_Click(object sender, EventArgs e)
		{

		}

		private void frmDoanhThu_Load(object sender, EventArgs e)
		{
			LoadDoanhThu();
			LoadBieuDoDoanhThu();
		}
		private void LoadDoanhThu()
		{
			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=master;Integrated Security=True";
			string query = "SELECT IDHoaDon, NgayBan, TongTien FROM HoaDon"; // Đảm bảo tên bảng chính xác

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(query, connection))
					using (SqlDataAdapter adapter = new SqlDataAdapter(command))
					{
						DataTable dataTable = new DataTable();
						adapter.Fill(dataTable);
						dtgvDT.DataSource = dataTable;
					}
				}
				TinhTongDoanhThu();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void btnLoc_Click(object sender, EventArgs e)
		{
			DateTime tuNgay = dtpTuNgay.Value;
			DateTime denNgay = dtpDenNgay.Value;

			if (tuNgay > denNgay)
			{
				MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=master;Integrated Security=True";

			string query = "SELECT IDHoaDon, NgayBan, TongTien FROM HoaDon WHERE NgayBan BETWEEN @TuNgay AND @DenNgay";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@TuNgay", tuNgay);
						command.Parameters.AddWithValue("@DenNgay", denNgay);

						using (SqlDataAdapter adapter = new SqlDataAdapter(command))
						{
							DataTable dataTable = new DataTable();
							adapter.Fill(dataTable);
							dtgvDT.DataSource = dataTable;
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			TinhTongDoanhThu();
		}
		private void TinhTongDoanhThu()
		{
			decimal tongDoanhThu = 0;

			foreach (DataGridViewRow row in dtgvDT.Rows)
			{
				if (row.Cells["TongTien"].Value != null)
				{
					tongDoanhThu += Convert.ToDecimal(row.Cells["TongTien"].Value);
				}
			}

			txtTongDT.Text = tongDoanhThu.ToString("N0") + " VNĐ"; // Định dạng số
		}

		private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
		{
			btnLoc_Click(sender, e); // Gọi lại hàm lọc
		}

		private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
		{
			btnLoc_Click(sender, e); // Gọi lại hàm lọc
		}

		private void dtgvDoanhThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dtgvDT.Columns[e.ColumnIndex].Name == "NgayBan" && e.Value != null)
			{
				e.Value = Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy");
			}
			else if (dtgvDT.Columns[e.ColumnIndex].Name == "TongTien" && e.Value != null)
			{
				e.Value = Convert.ToDecimal(e.Value).ToString("N0") + " VNĐ";
			}
		}

		private void dtgvDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void txtTongDT_TextChanged(object sender, EventArgs e)
		{

		}

	}
}
