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
	public partial class frmNhaCungCap : Form
	{
		string connectionString = @"Data Source=DESKTOP-E3V9138;Initial Catalog=SHOESSHOP2;Integrated Security=True;";

		private DataTable foodTable; // Khai báo foodTable ở phạm vi lớp

		public frmNhaCungCap()
		{
			InitializeComponent();
			LoadData(); // Nạp dữ liệu khi form được khởi tạo
		}

		// Phương thức nạp dữ liệu vào foodTable
		private void LoadData()
		{
			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand("SELECT * FROM NhaCungCap", conn);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			foodTable = new DataTable();
			adapter.Fill(foodTable); // Nạp dữ liệu từ CSDL vào foodTable
		}

		private void frmNhaCungCap_Load(object sender, EventArgs e)
		{
			// Tải danh sách nhà cung cấp
			LoadDanhSachNhaCungCap();
		}

		private void LoadDanhSachNhaCungCap()
		{
			SqlConnection conn = new SqlConnection(connectionString); // Tạo đối tượng kết nối tới SQL

			SqlCommand cmd = conn.CreateCommand(); // Tạo đối tượng thực thi lệnh SQL
			cmd.CommandText = "SELECT ncc.idNCC AS [idNCC], ncc.tenNCC AS [Tên nhà cung cấp], ncc.soDT AS [Số điện thoại], " +
							  "ncc.email AS [Email], ncc.diaChi AS [Địa chỉ], ncc.tinhTrangNhap AS [Tình trạng nhập] " +
							  "FROM NhaCungCap ncc";

			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable(); // Chứa dữ liệu trả về từ CSDL

			try
			{
				conn.Open(); // Mở kết nối

				// Lấy dữ liệu từ CSDL và đưa vào bảng (DataTable)
				adapter.Fill(dt);

				// Gán DataTable vào DataGridView
				dgvNCC.DataSource = dt;
			}
			catch (Exception ex)
			{
				// Xử lý lỗi, ví dụ như thông báo lỗi nếu kết nối hoặc câu lệnh không thành công
				MessageBox.Show("Có lỗi khi tải danh sách nhà cung cấp: " + ex.Message);
			}
			finally
			{
				// Đóng kết nối và giải phóng bộ nhớ
				conn.Close();
				conn.Dispose();
			}
		}

		private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dgvNCC.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn một dòng để xóa.");
				return;
			}

			int selectedFoodID = Convert.ToInt32(dgvNCC.SelectedRows[0].Cells["idNCC"].Value);

			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();

				// Bước 1: Cập nhật bảng NhapKho, đặt idNCC thành NULL (nếu cột cho phép NULL)
				using (SqlCommand sqlCommand = new SqlCommand("UPDATE NhapKho SET idNCC = NULL WHERE idNCC = @idNCC", sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@idNCC", selectedFoodID);
					sqlCommand.ExecuteNonQuery();
				}

				// Bước 2: Xóa dữ liệu trong bảng NhaCungCap
				using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM NhaCungCap WHERE idNCC = @idNCC", sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@idNCC", selectedFoodID);
					sqlCommand.ExecuteNonQuery();
				}
			}

			MessageBox.Show("Đã xóa nhà cung cấp thành công.");

			// Cập nhật lại dữ liệu trong DataGridView
			LoadDanhSachNhaCungCap();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			// Kiểm tra nếu foodTable không null và có dữ liệu
			if (foodTable == null || foodTable.Rows.Count == 0)
				return;

			// Lấy giá trị nhập vào TextBox
			string searchText = textBox1.Text;

			// Tạo biểu thức lọc dựa trên giá trị nhập vào TextBox
			string filterExpression = string.Format("tenNCC LIKE '%{0}%'", searchText);

			// Tạo DataView để áp dụng bộ lọc
			DataView dataView = new DataView(foodTable);
			dataView.RowFilter = filterExpression;  // Áp dụng bộ lọc

			// Cập nhật DataGridView để hiển thị dữ liệu lọc
			dgvNCC.DataSource = dataView;
		}

		private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Kiểm tra xem dòng được chọn có hợp lệ không
			if (e.RowIndex >= 0 && dgvNCC.Rows[e.RowIndex].Cells["idNCC"].Value != null)
			{
				DataGridViewRow selectedRow = dgvNCC.Rows[e.RowIndex];

				// Gán dữ liệu từ các ô của dòng được chọn vào các TextBox
				txtMaNCC.Text = selectedRow.Cells["idNCC"].Value?.ToString() ?? "";
				txtTenNCC.Text = selectedRow.Cells["Tên nhà cung cấp"].Value?.ToString() ?? "";
				txtSDT.Text = selectedRow.Cells["Số điện thoại"].Value?.ToString() ?? "";
				txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString() ?? "";
				txtDiaChi.Text = selectedRow.Cells["Địa chỉ"].Value?.ToString() ?? "";
				txtTinhTrangNhap.Text = selectedRow.Cells["Tình trạng nhập"].Value?.ToString() ?? "";
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			// Kiểm tra các TextBox có dữ liệu hợp lệ không
			if (string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtSDT.Text) ||
				string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtDiaChi.Text) ||
				string.IsNullOrEmpty(txtTinhTrangNhap.Text))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
				return;
			}

			// Xác định nếu là cập nhật hay thêm mới
			int idNCC = 0;
			if (int.TryParse(txtMaNCC.Text, out idNCC) && idNCC > 0)
			{
				// Nếu có idNCC, thực hiện sửa
				UpdateOrInsertNhaCungCap(idNCC, false);
			}
			else
			{
				// Nếu không có idNCC (hoặc không phải là số hợp lệ), thực hiện thêm mới
				UpdateOrInsertNhaCungCap(idNCC, true); // Gửi idNCC = 0 khi thêm mới
			}
		}

		private void UpdateOrInsertNhaCungCap(int idNCC, bool isInsert)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();

				// Thực hiện gọi stored procedure
				using (SqlCommand sqlCommand = new SqlCommand("sp_SuaLuuNhaCungCap", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					// Thêm các tham số, bỏ qua idNCC khi thêm mới (gửi NULL)
					sqlCommand.Parameters.AddWithValue("@idNCC", isInsert ? (object)DBNull.Value : idNCC); // NULL nếu thêm mới
					sqlCommand.Parameters.AddWithValue("@tenNCC", txtTenNCC.Text);
					sqlCommand.Parameters.AddWithValue("@soDT", txtSDT.Text);
					sqlCommand.Parameters.AddWithValue("@email", txtEmail.Text);
					sqlCommand.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
					sqlCommand.Parameters.AddWithValue("@tinhTrangNhap", txtTinhTrangNhap.Text);

					// Thực thi câu lệnh
					sqlCommand.ExecuteNonQuery();
				}
			}

			// Hiển thị thông báo
			MessageBox.Show(isInsert ? "Thêm nhà cung cấp thành công." : "Cập nhật nhà cung cấp thành công.");

			// Làm mới danh sách nhà cung cấp trong DataGridView
			LoadDanhSachNhaCungCap();
		}

		private void SaveChangesToDatabase(bool isUpdate, int idNCC)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();

				using (SqlCommand sqlCommand = new SqlCommand(isUpdate ? "sp_SuaLuuNhaCungCap" : "sp_ThemNhaCungCap", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					// Thêm hoặc cập nhật tham số
					if (isUpdate)
					{
						sqlCommand.Parameters.AddWithValue("@idNCC", idNCC);
					}
					else
					{
						sqlCommand.Parameters.AddWithValue("@idNCC", DBNull.Value); // NULL cho ID khi thêm mới
					}

					sqlCommand.Parameters.AddWithValue("@tenNCC", txtTenNCC.Text);
					sqlCommand.Parameters.AddWithValue("@soDT", txtSDT.Text);
					sqlCommand.Parameters.AddWithValue("@email", txtEmail.Text);
					sqlCommand.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
					sqlCommand.Parameters.AddWithValue("@tinhTrangNhap", txtTinhTrangNhap.Text);

					// Thực thi câu lệnh
					sqlCommand.ExecuteNonQuery();
				}
			}

			// Sau khi lưu thay đổi, làm mới DataGridView
			MessageBox.Show(isUpdate ? "Cập nhật nhà cung cấp thành công." : "Thêm nhà cung cấp thành công.");
			LoadDanhSachNhaCungCap();  // Làm mới DataGridView
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			// Xóa giá trị trong các TextBox
			txtMaNCC.Clear();
			txtTenNCC.Clear();
			txtSDT.Clear();
			txtEmail.Clear();
			txtDiaChi.Clear();
			txtTinhTrangNhap.Clear();

			txtTenNCC.Focus();
		}

		private void btnThongKe_Click(object sender, EventArgs e)
		{
			// Tạo một thể hiện mới của frmThongKe
			frmThongKe formThongKe = new frmThongKe();

			// Hiển thị form thống kê
			formThongKe.Show(); // Sử dụng Show() nếu bạn muốn form mở ở chế độ không chặn
								// formThongKe.ShowDialog(); // Sử dụng ShowDialog() nếu bạn muốn form mở ở chế độ chặn
		}
	}
}
