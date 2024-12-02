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
	public partial class frmThongKe : Form
	{
		string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=SHOESSHOP2;Integrated Security=True";


		public frmThongKe()
		{
			InitializeComponent();
		}

		private void frmThongKe_Load(object sender, EventArgs e)
		{
			LoadNhaCungCap();
		}

		private void LoadNhaCungCap()
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();

				SqlCommand sqlCommand = new SqlCommand("SELECT idNCC, tenNCC FROM NhaCungCap", sqlConnection);
				SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
				DataTable dt = new DataTable();
				da.Fill(dt);

				// Thiết lập ComboBox
				cboNCC.DataSource = dt;
				cboNCC.DisplayMember = "tenNCC"; // Hiển thị tên nhà cung cấp
				cboNCC.ValueMember = "idNCC";   // Lưu giá trị idNCC
			}
		}

		private void btnLoc_Click(object sender, EventArgs e)
		{
			// Kiểm tra nếu ngày bắt đầu lớn hơn ngày kết thúc
			if (dtpFrom.Value > dtpTo.Value)
			{
				// Hiển thị thông báo lỗi
				MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc. Vui lòng chọn lại ngày.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return; // Dừng hàm nếu ngày không hợp lệ
			}

			// Tiến hành lọc dữ liệu nếu ngày hợp lệ
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				// Câu lệnh SQL với điều kiện lọc theo ngày và nhà cung cấp
				string query =
					"SELECT NhapKho.idNhapKho, NhapKho.idNCC, NhapKho.ngayNhapKho, NhapKho.thanhTien " +
					"FROM NhapKho " +
					"WHERE NhapKho.ngayNhapKho BETWEEN @FromDate AND @ToDate";

				// Nếu nhà cung cấp được chọn trong ComboBox, thêm điều kiện lọc theo nhà cung cấp
				if (cboNCC.SelectedItem != null)
				{
					int idNCC = Convert.ToInt32(cboNCC.SelectedValue); // Giả sử bạn lưu idNCC trong ValueMember của ComboBox
					query += " AND NhapKho.idNCC = @idNCC";
				}

				// Khởi tạo SqlCommand và thêm tham số
				SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

				// Thêm tham số ngày bắt đầu và kết thúc
				sqlCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = dtpFrom.Value.Date;
				sqlCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = dtpTo.Value.Date;

				// Nếu nhà cung cấp được chọn, thêm tham số cho idNCC
				if (cboNCC.SelectedItem != null)
				{
					int idNCC = Convert.ToInt32(cboNCC.SelectedValue); // Lấy idNCC từ ComboBox
					sqlCommand.Parameters.Add("@idNCC", SqlDbType.Int).Value = idNCC;
				}

				// Thực thi câu lệnh SQL và điền dữ liệu vào DataGridView
				SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
				DataTable dt = new DataTable();
				da.Fill(dt);

				// Gán kết quả vào DataGridView
				dgvHoaDon.DataSource = dt;

				// Tính tổng số đơn hàng và tổng số tiền
				int totalOrders = dt.Rows.Count;
				decimal totalAmount = dt.AsEnumerable().Sum(row => row.Field<decimal>("thanhTien"));

				// Cập nhật tổng số đơn hàng và tổng số tiền lên Label
				lblTongSoDonHang.Text = $"Tổng số đơn hàng: {totalOrders}";
				lblTongSoTien.Text = $"Tổng số tiền: {totalAmount:C}";
			}
		}


		private void HienChiTietNhapKho(int idNhapKho)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				// Truy vấn thông tin chi tiết nhập kho
				string query =
					"SELECT SanPham.tenSanPham AS [Tên Sản Phẩm], SanPham.thuongHieu AS [Thương Hiệu], " +
					"ChiTietNhapKho.soLuong AS [Số Lượng], ChiTietNhapKho.giaNhap AS [Giá Nhập] " +
					"FROM ChiTietNhapKho " +
					"INNER JOIN SanPham ON ChiTietNhapKho.idSanPham = SanPham.idSanPham " +
					"WHERE ChiTietNhapKho.idNhapKho = @idNhapKho";

				SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
				sqlCommand.Parameters.AddWithValue("@idNhapKho", idNhapKho);

				SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
				DataTable dt = new DataTable();
				da.Fill(dt);

				// Kiểm tra nếu không có dữ liệu chi tiết
				if (dt.Rows.Count == 0)
				{
					MessageBox.Show("Không có thông tin chi tiết cho phiếu nhập kho này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				// Gán dữ liệu vào dgvChiTietGiay
				dgvChiTietGiay.DataSource = dt;

				// Tùy chỉnh hiển thị DataGridView
				dgvChiTietGiay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				dgvChiTietGiay.ReadOnly = true;
				dgvChiTietGiay.AllowUserToAddRows = false;
				dgvChiTietGiay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

				//MessageBox.Show($"Hiển thị chi tiết nhập kho - Mã: {idNhapKho}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			// Kiểm tra xem người dùng có click vào dòng dữ liệu hợp lệ không
			if (e.RowIndex >= 0)
			{
				// Kiểm tra giá trị của cột idNhapKho
				var cellValue = dgvHoaDon.Rows[e.RowIndex].Cells["idNhapKho"].Value;

				if (cellValue != null && cellValue != DBNull.Value)
				{
					// Lấy idNhapKho từ dòng được chọn
					int idNhapKho = Convert.ToInt32(cellValue);

					// Gọi hàm hiển thị chi tiết nhập kho
					HienChiTietNhapKho(idNhapKho);
				}
				else
				{
					MessageBox.Show("Không thể lấy mã nhập kho từ dòng được chọn. Dữ liệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		private void lblTongSoTien_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
