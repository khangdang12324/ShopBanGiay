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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopBanGiay
{
	public partial class frmKhachHang : Form
	{
		public frmKhachHang()
		{
			InitializeComponent();
		}
        string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=SHOESSHOP2;Integrated Security=True";
        private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void textBox3_TextChanged(object sender, EventArgs e)
        {
			string tenKhachHang = txtTim.Text.Trim(); // Lấy giá trị nhập từ TextBox

			// Gọi phương thức tìm kiếm
			TimKiemKhachHangTheoTen(tenKhachHang);
		}
		private void TimKiemKhachHangTheoTen(string tenKhachHang)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();

					string query = @"
                SELECT 
                    KH.IDKhachHang, KH.TenKhachHang, KH.soDT, KH.DiaChi, 
                    SS.Size, 
                    SC.Mau AS ShoeColor, 
                    SI.Quantity
                FROM 
                    KhachHang KH
                LEFT JOIN 
                    ShoeInventory SI ON KH.IDKhachHang = KH.IDKhachHang
                LEFT JOIN 
                    SanPham S ON SI.IDSanPham = S.IDSanPham
                LEFT JOIN 
                    SizeSanPham SS ON SI.IDSize = SS.IDSize
                LEFT JOIN 
                    MauSanPham SC ON SI.IDMau = SC.IDMau
                WHERE 
                    KH.TenKhachHang LIKE @TenKhachHang;";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						// Thêm tham số tìm kiếm
						cmd.Parameters.AddWithValue("@TenKhachHang", "%" + tenKhachHang + "%");

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							DataTable dt = new DataTable();
							dt.Load(reader); // Tải dữ liệu vào DataTable
							dtgvDSKH.DataSource = dt; // Gán dữ liệu vào DataGridView
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void dtgvDSKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       /*     if (e.RowIndex >= 0)
            {

                DataGridViewRow selectedRow = dtgvDSKH.Rows[e.RowIndex];

                txtMaKH.Text = selectedRow.Cells[0].Value?.ToString();
                txtTenKH.Text = selectedRow.Cells[1].Value?.ToString();
                mtkSDTKH.Text = selectedRow.Cells[2].Value?.ToString();
                txtDiaChi.Text = selectedRow.Cells[3].Value?.ToString();
                txtSizeGiay.Text = selectedRow.Cells[4].Value?.ToString();
            }*/
            
        }
        private void LoadDataFromSQL()
        {



            string query = @"
       SELECT 
        KH.IDKhachHang, KH.TenKhachHang, KH.soDT, KH.DiaChi, 
        SS.Size, 
        SC.Mau AS ShoeColor, 
        SI.Quantity
    FROM 
        KhachHang KH
    LEFT JOIN 
        ShoeInventory SI ON KH.IDKhachHang = KH.IDKhachHang -- Replace 'CustomerID' with the correct column
    LEFT JOIN 
        SanPham S ON SI.IDSanPham = S.IDSanPham
    LEFT JOIN 
        SizeSanPham SS ON SI.IDSize = SS.IDSize
    LEFT JOIN 
        MauSanPham SC ON SI.IDMau = SC.IDMau;
    ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dtgvDSKH.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(mtkSDTKH.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dataTable = (DataTable)dtgvDSKH.DataSource;
            DataRow newRow = dataTable.NewRow();
            newRow["TenKhachHang"]= txtTenKH.Text;
            newRow["soDT"] = mtkSDTKH.Text;
            newRow["DiaChi"] = mtkSDTKH.Text;
         
            string tenKhachHang = txtTenKH.Text;
            string soDienThoai = mtkSDTKH.Text;
            string diaChi = txtDiaChi.Text;

            dtgvDSKH.Rows.Add(tenKhachHang, soDienThoai, diaChi);

            txtTenKH.Clear();
            mtkSDTKH.Clear();
            txtDiaChi.Clear();

            txtTenKH.Focus();
        
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
			LoadSizeToComboBox();

			LoadDataFromSQL();
        }
        private int selectedRowIndex = -1;

		private void btnCapNhat_Click(object sender, EventArgs e)
		{
			if (selectedRowIndex < 0)
			{
				MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(txtTenKH.Text) ||
				string.IsNullOrWhiteSpace(mtkSDTKH.Text) ||
				string.IsNullOrWhiteSpace(txtDiaChi.Text))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Lấy IDKhachHang từ dòng được chọn
			DataGridViewRow selectedRow = dtgvDSKH.Rows[selectedRowIndex];
			int idKhachHang = Convert.ToInt32(selectedRow.Cells["IDKhachHang"].Value);

			// Chuỗi kết nối (thay đổi cho phù hợp với cơ sở dữ liệu của bạn)
			string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=SHOESSHOP2;Integrated Security=True";

			// Câu lệnh SQL UPDATE
			string query = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, soDT = @soDT, DiaChi = @DiaChi WHERE IDKhachHang = @IDKhachHang";

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						// Gán giá trị cho các tham số
						command.Parameters.AddWithValue("@TenKhachHang", txtTenKH.Text);
						command.Parameters.AddWithValue("@soDT", mtkSDTKH.Text);
						command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
						command.Parameters.AddWithValue("@IDKhachHang", idKhachHang);

						// Thực thi câu lệnh
						int rowsAffected = command.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							// Cập nhật thành công
							MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

							// Cập nhật lại DataGridView
							selectedRow.Cells["TenKhachHang"].Value = txtTenKH.Text;
							selectedRow.Cells["soDT"].Value = mtkSDTKH.Text;
							selectedRow.Cells["DiaChi"].Value = txtDiaChi.Text;

							// Xóa các ô nhập
							txtTenKH.Clear();
							mtkSDTKH.Clear();
							txtDiaChi.Clear();

							selectedRowIndex = -1;
						}
						else
						{
							MessageBox.Show("Không tìm thấy khách hàng để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Đã xảy ra lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dtgvDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
           
                selectedRowIndex = e.RowIndex;
             
                
                DataGridViewRow selectedRow = dtgvDSKH.Rows[e.RowIndex];

                txtTenKH.Text = selectedRow.Cells["TenKhachHang"].Value?.ToString();
                mtkSDTKH.Text = selectedRow.Cells["soDT"].Value?.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value?.ToString();
				txtSizeGiay.Text = selectedRow.Cells["Size"].Value?.ToString();
			}
        }
        private DataTable danhSachGiayGoc; 

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
        private void LoadAllSanPham()
        {
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        conn.Open();
            //        string query = "SELECT DISTINCT Size FROM SizeSanPham;";
            //        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            //        DataTable dt = new DataTable();
            //        adapter.Fill(dt);

            //        dtgvDSKH.DataSource = dt;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message);
            //    }
            //}
            

            if (cbLocSize.Items.Count > 0)
            {
                cbLocSize.SelectedIndex = 0;
            }
        }


		private void LoadSanPhamBySize(string size)
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();

					string query = @"
                SELECT 
                    KH.IDKhachHang, KH.TenKhachHang, KH.soDT, KH.DiaChi, 
                    SS.Size, 
                    SC.Mau AS ShoeColor, 
                    SI.Quantity
                FROM 
                    KhachHang KH
                LEFT JOIN 
                    ShoeInventory SI ON KH.IDKhachHang = KH.IDKhachHang 
                LEFT JOIN 
                    SanPham S ON SI.IDSanPham = S.IDSanPham
                LEFT JOIN 
                    SizeSanPham SS ON SI.IDSize = SS.IDSize
                LEFT JOIN 
                    MauSanPham SC ON SI.IDMau = SC.IDMau
                WHERE 
                    SS.Size = @Size;"; // Điều kiện lọc theo Size

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						// Thêm tham số lọc Size
						cmd.Parameters.AddWithValue("@Size", size);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							DataTable dataTable = new DataTable();
							dataTable.Load(reader); // Tải dữ liệu vào DataTable
							dtgvDSKH.DataSource = dataTable; // Gán dữ liệu vào DataGridView
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi tải dữ liệu theo size: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}






		private void LoadSizeToComboBox()
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();

					string query = "SELECT DISTINCT Size FROM SizeSanPham;"; // Truy vấn lấy danh sách Size
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								cbLocSize.Items.Add(reader["Size"].ToString()); // Thêm Size vào ComboBox
							}
						}
					}

					if (cbLocSize.Items.Count > 0)
					{
						cbLocSize.SelectedIndex = 0; // Chọn giá trị đầu tiên làm mặc định
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi tải danh sách Size: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}



		private void cbLocSize_SelectedIndexChanged(object sender, EventArgs e)
        {
			// Kiểm tra ComboBox đã chọn Size hợp lệ chưa
			if (cbLocSize.SelectedItem == null)
			{
				MessageBox.Show("Vui lòng chọn một size để lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string selectedSize = cbLocSize.SelectedItem.ToString();

			// Gọi phương thức để tải dữ liệu theo Size được chọn
			LoadSanPhamBySize(selectedSize);

		}


        private void cbLocSize_Click(object sender, EventArgs e)
        {
			

		}

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            string tenKhachHang = txtTenKH.Text.Trim();
            string soDT = mtkSDTKH.Text.Trim();

            if (string.IsNullOrEmpty(tenKhachHang) && string.IsNullOrEmpty(soDT))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng hoặc số điện thoại.");
                return;
            }

            TimKiemKhachHang(tenKhachHang, soDT);
        }
        private void TimKiemKhachHang(string tenKhachHang, string soDT)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
    SELECT 
        KH.IDKhachHang, KH.TenKhachHang, KH.soDT, KH.DiaChi, 
        SS.Size, 
        SC.Mau AS ShoeColor, 
        SI.Quantity
    FROM 
        KhachHang KH
    LEFT JOIN 
        ShoeInventory SI ON KH.IDKhachHang = IDKhachHang
    LEFT JOIN 
        SanPham S ON SI.IDSanPham = S.IDSanPham
    LEFT JOIN 
        SizeSanPham SS ON SI.IDSize = SS.IDSize
    LEFT JOIN 
        MauSanPham SC ON SI.IDMau = SC.IDMau
    WHERE 
        (KH.TenKhachHang LIKE @TenKhachHang OR @TenKhachHang = '')
        AND (KH.soDT LIKE @SoDT OR @SoDT = '');";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to avoid SQL Injection
                        cmd.Parameters.AddWithValue("@TenKhachHang", "%" + tenKhachHang + "%");
                        cmd.Parameters.AddWithValue("@SoDT", "%" + soDT + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader); // Load data into DataTable

                            if (dt.Rows.Count > 0)
                            {
                                dtgvDSKH.DataSource = dt; // Assign data to DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy khách hàng.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

		private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (dtgvDSKH.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn ít nhất một khách hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa những khách hàng đã chọn?",
												   "Xác nhận",
												   MessageBoxButtons.YesNo,
												   MessageBoxIcon.Question);

			if (confirm == DialogResult.No)
				return;

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();

					foreach (DataGridViewRow row in dtgvDSKH.SelectedRows)
					{
						if (row.Cells["IDKhachHang"].Value != null)
						{
							string idKhachHang = row.Cells["IDKhachHang"].Value.ToString();

							string query = "DELETE FROM KhachHang WHERE IDKhachHang = @IDKhachHang";

							using (SqlCommand cmd = new SqlCommand(query, conn))
							{
								cmd.Parameters.AddWithValue("@IDKhachHang", idKhachHang);
								cmd.ExecuteNonQuery(); // Xóa dữ liệu trong cơ sở dữ liệu
							}

							dtgvDSKH.Rows.Remove(row); // Xóa dòng trong DataGridView
						}
					}

					MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

        private void btnThem_Click_1(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(txtTenKH.Text) ||
	  string.IsNullOrWhiteSpace(mtkSDTKH.Text) ||
	  string.IsNullOrWhiteSpace(txtDiaChi.Text))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Lấy dữ liệu từ các TextBox
			string tenKhachHang = txtTenKH.Text.Trim();
			string soDienThoai = mtkSDTKH.Text.Trim();
			string diaChi = txtDiaChi.Text.Trim();

			// Thêm dữ liệu vào cơ sở dữ liệu
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();
					string query = @"
                INSERT INTO KhachHang (TenKhachHang, soDT, DiaChi)
                VALUES (@TenKhachHang, @SoDT, @DiaChi);";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@TenKhachHang", tenKhachHang);
						cmd.Parameters.AddWithValue("@SoDT", soDienThoai);
						cmd.Parameters.AddWithValue("@DiaChi", diaChi);

						cmd.ExecuteNonQuery(); // Thực thi lệnh SQL
					}

					// Cập nhật giao diện DataGridView
					LoadDataFromSQL();

					// Xóa dữ liệu trong TextBox
					txtTenKH.Clear();
					mtkSDTKH.Clear();
					txtDiaChi.Clear();

					MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi thêm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
    }
}
