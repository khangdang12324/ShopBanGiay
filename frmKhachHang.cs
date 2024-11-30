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
            LoadDataFromSQL();
            //LoadSizeToComboBox(); 
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

            DataGridViewRow selectedRow = dtgvDSKH.Rows[selectedRowIndex];

            selectedRow.Cells["TenKhachHang"].Value = txtTenKH.Text;
            selectedRow.Cells["soDT"].Value = mtkSDTKH.Text;
            selectedRow.Cells["DiaChi"].Value = txtDiaChi.Text;

            MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtTenKH.Clear();
            mtkSDTKH.Clear();
            txtDiaChi.Clear();

      
            selectedRowIndex = -1;
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
            SS.Size = @Size;"; 

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Size", size);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                          
                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("IDKhachHang", typeof(string));
                            dataTable.Columns.Add("TenKhachHang", typeof(string));
                            dataTable.Columns.Add("soDT", typeof(string));
                            dataTable.Columns.Add("DiaChi", typeof(string));
                            dataTable.Columns.Add("Size", typeof(string));
                            dataTable.Columns.Add("ShoeColor", typeof(string));
                            dataTable.Columns.Add("Quantity", typeof(int));

                            
                            while (reader.Read())
                            {
                                DataRow row = dataTable.NewRow();
                                row["IDKhachHang"] = reader["IDKhachHang"].ToString();
                                row["TenKhachHang"] = reader["TenKhachHang"].ToString();
                                row["soDT"] = reader["soDT"].ToString();
                                row["DiaChi"] = reader["DiaChi"].ToString();
                                row["Size"] = reader["Size"].ToString();
                                row["ShoeColor"] = reader["ShoeColor"].ToString();
                                row["Quantity"] = Convert.ToInt32(reader["Quantity"]);

                                dataTable.Rows.Add(row);
                            }

                            
                            dtgvDSKH.DataSource = dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
		private void RefreshSizeComboBox()
		{
			// Lưu giá trị đã chọn hiện tại
			string selectedValue = cbLocSize.SelectedItem?.ToString();

			// Clear ComboBox trước khi thêm
			cbLocSize.Items.Clear();

			// Dùng HashSet để đảm bảo không có giá trị trùng lặp
			HashSet<string> sizeSet = new HashSet<string>();

			foreach (DataGridViewRow row in dtgvDSKH.Rows)
			{
				if (row.Cells["Size"].Value != null)
				{
					string sizeValue = row.Cells["Size"].Value.ToString().Trim();

					// Chỉ thêm giá trị nếu chưa tồn tại
					if (!string.IsNullOrEmpty(sizeValue) && sizeSet.Add(sizeValue))
					{
						cbLocSize.Items.Add(sizeValue);
					}
				}
			}

			// Khôi phục giá trị đã chọn nếu nó tồn tại trong danh sách
			if (selectedValue != null && cbLocSize.Items.Contains(selectedValue))
			{
				cbLocSize.SelectedItem = selectedValue;
			}
			else if (cbLocSize.Items.Count > 0)
			{
				cbLocSize.SelectedIndex = 0; // Chọn mục đầu tiên nếu có
			}
		}




		private void LoadSizeToComboBox()
        {
			try
			{
				RefreshSizeComboBox();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while loading sizes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


        private void cbLocSize_SelectedIndexChanged(object sender, EventArgs e)
        {

			if (cbLocSize.SelectedItem != null)
			{
				string selectedSize = cbLocSize.SelectedItem.ToString();
				LoadSanPhamBySize(selectedSize); // Hiển thị sản phẩm theo size
			}
		}


        private void cbLocSize_Click(object sender, EventArgs e)
        {
			RefreshSizeComboBox();

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



    }
}
