using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopBanGiay
{
    public partial class frmChinh : Form
    {
        public List<Shoes> shoesList = new List<Shoes>();
        private BindingSource bindingSource = new BindingSource();
        string connectionString = @"Data Source=LAPTOP-KHANGDAN;Initial Catalog=SHOESSHOP2;Integrated Security=True";
      
         List<KhachHang> dskhachHang = new List<KhachHang>();
         KhachHang khachHang;

		List<HoaDon1> dsHoadon = new List<HoaDon1>();
		HoaDon1 Hoadon;


		public frmChinh()
        {
            InitializeComponent();
        }
        public void SetKhachHang(KhachHang kh)
        {
            MessageBox.Show(kh.Name);
            txtHoTenKH.Text = kh.Name;
            txtDiaChiKH.Text = kh.Address;
            mkSdtKH.Text = kh.PhoneNumber;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(txtHoTenKH.Text == null ||  txtDiaChiKH.Text == null || mkSdtKH.Text == null)
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng");
                return; 
            }
            int idKH = dskhachHang.Count + 1;
            KhachHang kh = new KhachHang();
            kh.IDCustomer = idKH.ToString();
            kh.Name = txtHoTenKH.Text;
            kh.PhoneNumber = mkSdtKH.Text;
            kh.Address = txtDiaChiKH.Text;
            dskhachHang.Add(kh);
            txtDiaChiKH.Text = null;
            txtHoTenKH.Text = null ;
            mkSdtKH.Text = null;
            MessageBox.Show("Thêm thành công");
            
        }
        private void buttonChonKH_Click(object sender, EventArgs e)
        {
            using (ChonKH frmnc = new ChonKH(dskhachHang))
            {

                frmnc.StartPosition = FormStartPosition.CenterParent;

                frmnc.data = new ChonKH.GetData(SetKhachHang);
                frmnc.ShowDialog(this);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            TestConnection(connectionString);

           // LoadDataFromSQL();

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
                                SI.Quantity
                            FROM ShoeInventory SI
                            JOIN SanPham S ON SI.IDSanPham = S.IDSanPham
                            JOIN SizeSanPham SS ON SI.IDSize = SS.IDSize
                            JOIN MauSanPham SC ON SI.IDMau = SC.IDMau;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Sử dụng SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    // Đổ dữ liệu vào DataTable
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gán dữ liệu vào DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }
        private void LoadData(string searchText = "")
        {
            // Câu truy vấn cơ bản
            string query = @"
        SELECT 
            S.IDSanPham,
            S.TenSanPham ,
            S.ThuongHieu,
            S.Loai,
            S.Gia,
            SS.Size,
            SC.Mau,
            SI.Quantity
        FROM ShoeInventory SI
        JOIN SanPham S ON SI.IDSanPham = S.IDSanPham
        JOIN SizeSanPham SS ON SI.IDSize = SS.IDSize
        JOIN MauSanPham SC ON SI.IDMau = SC.IDMau";

            // Thêm điều kiện tìm kiếm nếu có từ khóa
            if (!string.IsNullOrEmpty(searchText))
            {
                query += " WHERE (S.TenSanPham LIKE @SearchText OR S.ThuongHieu LIKE @SearchText OR CAST(S.IDSanPham AS VARCHAR) LIKE @SearchText)";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số tìm kiếm
                        if (!string.IsNullOrEmpty(searchText))
                        {
                            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                        }

                        // Tạo DataAdapter và DataTable để lấy dữ liệu
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Gán dữ liệu vào BindingSource
                        bindingSource.DataSource = dataTable;

                        // Liên kết dữ liệu với DataGridView
                        dataGridView1.DataSource = bindingSource;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //TestServer
        void TestConnection(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Ket noi thanh cong");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kết nối thất bại: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    conn.Close(); // Đảm bảo kết nối được đóng
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmTimKiemNangCao frmnc = new frmTimKiemNangCao())
            {

                frmnc.StartPosition = FormStartPosition.CenterParent;


                frmnc.ShowDialog(this);
            }
        }
        public void GetData(int n)
        {
            txtSearch.Text = n.ToString();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
           
        }






        private void btnListReset_Click(object sender, EventArgs e)
        {
            LoadDataFromSQL();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {



            string searchText = txtSearch.Text.Trim().ToLower();

            LoadData(searchText);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            LoadData(searchText);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];


            }
        }

        private void ctmsChitietDH_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ThemVaoGioHang(sender, e);
        }
        void ThemVaoGioHang(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ hàng được chọn trong dataGridView1
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                string shoeID = selectedRow.Cells["IDSanPham"].Value.ToString();
                string shoeName = selectedRow.Cells["TenSanPham"].Value.ToString();
                string brand = selectedRow.Cells["ThuongHieu"].Value.ToString();
                decimal price = Convert.ToDecimal(selectedRow.Cells["Gia"].Value);
                string shoeSize = selectedRow.Cells["Size"].Value.ToString();
                string shoeColor = selectedRow.Cells["Mau"].Value.ToString();

                bool found = false;

                // Kiểm tra xem sản phẩm với cả ShoeID và ShoeSize đã tồn tại trong dataGridView2 chưa
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == shoeID &&
                        row.Cells[4].Value != null && row.Cells[4].Value.ToString() == shoeSize) // So sánh cả ShoeID và ShoeSize
                    {
                        // Nếu sản phẩm đã tồn tại, tăng số lượng và cập nhật tổng tiền
                        if (row.Cells[6].Value != null)
                        {
                            int currentQuantity = Convert.ToInt32(row.Cells[6].Value);
                            row.Cells[6].Value = currentQuantity + 1;
                            row.Cells[7].Value = price * (currentQuantity + 1);
                        }
                        found = true;
                        break;
                    }
                }

                // Nếu sản phẩm chưa tồn tại, thêm mới vào dataGridView2
                if (!found)
                {
                    dataGridView2.Rows.Add(shoeID, shoeName, brand, price, shoeSize, shoeColor, 1, price);
                }

                // Giảm số lượng trong dataGridView1
                int currentStock = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                if (currentStock > 0)
                {
                    selectedRow.Cells["Quantity"].Value = currentStock - 1;

                    // Nếu hết hàng, bạn có thể ẩn hoặc vô hiệu hóa hàng này (nếu cần)
                    //if (currentStock - 1 == 0)
                    //{
                    //    selectedRow.DefaultCellStyle.ForeColor = Color.Gray; // Đổi màu hàng (hoặc hành động khác)
                    //    selectedRow.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Strikeout); // Gạch ngang hàng
                    //}
                }
                else
                {
                    MessageBox.Show("Sản phẩm đã hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null) // Kiểm tra có hàng nào được chọn
            {
                DataGridViewRow selectedRow = dataGridView1.CurrentRow;

                // Lấy giá trị Quantity từ hàng hiện tại
                int availableQuantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

                if (availableQuantity >= numericUpDown3.Value) // Kiểm tra đủ số lượng để thêm vào giỏ
                {
                    for (int i = 0; i < numericUpDown3.Value; i++)
                    {
                        ThemVaoGioHang(selectedRow); // Thêm sản phẩm vào giỏ hàng
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng không đủ để thêm vào giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trước khi thêm vào giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void ThemVaoGioHang(DataGridViewRow selectedRow)
        {
            string shoeID = selectedRow.Cells["IDSanPham"].Value.ToString();
            string shoeName = selectedRow.Cells["TenSanPham"].Value.ToString();
            string brand = selectedRow.Cells["ThuongHieu"].Value.ToString();
            decimal price = Convert.ToDecimal(selectedRow.Cells["Gia"].Value);
            string shoeSize = selectedRow.Cells["Size"].Value.ToString();
            string shoeColor = selectedRow.Cells["Mau"].Value.ToString();

            bool found = false;

            // Kiểm tra sản phẩm đã tồn tại trong dataGridView2 chưa
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == shoeID &&
                    row.Cells[4].Value != null && row.Cells[4].Value.ToString() == shoeSize)
                {

                    int currentQuantity = Convert.ToInt32(row.Cells[6].Value);
                    row.Cells[6].Value = currentQuantity + 1;
                    row.Cells[7].Value = price * (currentQuantity + 1);
                    found = true;
                    break;
                }
            }


            if (!found)
            {
                dataGridView2.Rows.Add(shoeID, shoeName, brand, price, shoeSize, shoeColor, 1, price);
            }

            // Giảm số lượng trong dataGridView1
            int currentStock = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
            if (currentStock > 0)
            {
                selectedRow.Cells["Quantity"].Value = currentStock - 1;

            }
            else
            {
                MessageBox.Show("Sản phẩm đã hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
                TraGiayVeKho(selectedRow);
                dataGridView2.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void TraGiayVeKho(DataGridViewRow rowInCart)
        {
            if (rowInCart.Cells[0].Value != null) // Bỏ qua hàng trống
            {
                string shoeID = rowInCart.Cells[0].Value.ToString();
                string shoeSize = rowInCart.Cells[4].Value.ToString();
                int quantityToReturn = Convert.ToInt32(rowInCart.Cells[6].Value);

                // Tìm hàng tương ứng trong dataGridView1
                foreach (DataGridViewRow rowInStock in dataGridView1.Rows)
                {
                    if (rowInStock.Cells["IDSanPham"].Value != null &&
                        rowInStock.Cells["IDSanPham"].Value.ToString() == shoeID &&
                        rowInStock.Cells["Size"].Value.ToString() == shoeSize)
                    {
                        // Cập nhật số lượng trong dataGridView1
                        int currentQuantity = Convert.ToInt32(rowInStock.Cells["Quantity"].Value);
                        rowInStock.Cells["Quantity"].Value = currentQuantity + quantityToReturn;
                        break;
                    }
                }
            }
        }

        private void ThanhToanGioHang()
        {
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int IDSanPham))
                    {
                        string Size = row.Cells[4].Value?.ToString() ?? string.Empty;
                        string Mau = row.Cells[5].Value?.ToString() ?? string.Empty;
                        int quantityChange = row.Cells[6].Value != null ? Convert.ToInt32(row.Cells[6].Value) : 0;

                        using (SqlCommand cmd = new SqlCommand("UpdateShoeInventory1", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@ShoeID", IDSanPham);
                            cmd.Parameters.AddWithValue("@ShoeSize", Size);
                            cmd.Parameters.AddWithValue("@ShoeColor", Mau);
                            cmd.Parameters.AddWithValue("@QuantityChange", quantityChange);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Thanh toán thành công! Số lượng trong kho đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa giỏ hàng
                dataGridView2.Rows.Clear();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            ThanhToanGioHang();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = txtHoTenKH.Text;
        }

        private void txtDiaChiKH_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = txtDiaChiKH.Text;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = DateTime.Now.ToString();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            decimal sum = 0;

           
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                
                if (row.Cells["Column8"].Value != null)
                {
                    
                    decimal cellValue;
                    if (decimal.TryParse(row.Cells["Column8"].Value.ToString(), out cellValue))
                    {
                        sum += cellValue;
                    }
                }
            }

            
            txtTongTienHang.Text = sum.ToString();
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
           
            decimal tongTienHang;
            if (decimal.TryParse(txtTongTienHang.Text, out tongTienHang))
            {
                decimal giamGia = tongTienHang * nbGiamGia.Value / 100;  
                decimal thue = tongTienHang * nbThue.Value / 100;        

            
                decimal tongThanhToan = tongTienHang - giamGia + thue + decimal.Parse(txtPhiGiaoHang.Text);
                txtTongThanhToan.Text = tongThanhToan.ToString();
            }
            
        }


        private void txtPhiGiaoHang_TextChanged(object sender, EventArgs e)
        {

        }

		private void button6_Click(object sender, EventArgs e)
		{
            
			// Lấy dữ liệu từ các Controls
			string ngayLap = textBox4.Text;
			string tongTienHang = txtTongTienHang.Text;
			string phiGiaoHang = txtPhiGiaoHang.Text;
			decimal giamGia = nbGiamGia.Value;
			decimal thue = nbThue.Value;
			string trangThai = comboBox1.SelectedItem?.ToString() ?? "Chưa chọn";
			string tongThanhToan = txtTongThanhToan.Text;
			string ghiChu = richTextBox1.Text;

			// Tạo hóa đơn để in
			PrintDocument printDoc = new PrintDocument();
			printDoc.PrintPage += (s, ev) =>
			{
				Graphics g = ev.Graphics;
				Font font = new Font("Arial", 12);
				int y = 100;

				// Tiêu đề hóa đơn
				g.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, 300, y);
				y += 50;


				// Thông tin hóa đơn
				g.DrawString($"Ngày lập: {ngayLap}", font, Brushes.Black, 50, y); y += 30;
				g.DrawString($"Tổng tiền hàng: {tongTienHang} VND", font, Brushes.Black, 50, y); y += 30;
				g.DrawString($"Phí giao hàng: {phiGiaoHang} VND", font, Brushes.Black, 50, y); y += 30;
				g.DrawString($"Giảm giá: {giamGia}% | Thuế: {thue}%", font, Brushes.Black, 50, y); y += 30;
				g.DrawString($"Tổng thanh toán: {tongThanhToan} VND", font, Brushes.Black, 50, y); y += 30;
				g.DrawString($"Trạng thái: {trangThai}", font, Brushes.Black, 50, y); y += 30;

				// Ghi chú
				g.DrawString("Ghi chú:", font, Brushes.Black, 50, y);
				g.DrawString(ghiChu, font, Brushes.Black, 150, y); y += 50;

				g.DrawString("Cảm ơn quý khách đã mua hàng!", new Font("Arial", 14, FontStyle.Italic), Brushes.Black, 250, y);
			};

			// Hiển thị Preview trước khi in
			PrintPreviewDialog previewDialog = new PrintPreviewDialog
			{
				Document = printDoc
			};

			previewDialog.ShowDialog();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			// Kết nối cơ sở dữ liệu
			string connectionString = @"Data Source=DESKTOP-E3V9138;Initial Catalog=SHOESSHOP2;Integrated Security=True;";
			SqlConnection connection = new SqlConnection(connectionString);

			try
			{
				connection.Open();
				dsHoadon.Add(Hoadon);

				// Lấy tổng tiền từ TextBox
				decimal tongTien = decimal.Parse(txtTongTienHang.Text);
				DateTime ngayLap = DateTime.Now;
				string tinhTrang = "Chưa thanh toán";

				// Câu lệnh SQL để lưu hóa đơn
				string insertQuery = @"
                    INSERT INTO Hoadon1 (NgayLap, TongTien, TinhTrang)
                    VALUES (@NgayLap, @TongTien, @TinhTrang)";

				SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
				insertCmd.Parameters.AddWithValue("@NgayLap", ngayLap);
				insertCmd.Parameters.AddWithValue("@TongTien", tongTien);
				insertCmd.Parameters.AddWithValue("@TinhTrang", tinhTrang);

				int rowsAffected = insertCmd.ExecuteNonQuery();
				if (rowsAffected > 0)
				{
					MessageBox.Show("Hóa đơn đã được lưu với trạng thái 'Chưa thanh toán'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Lỗi khi lưu hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi kết nối hoặc thực thi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				connection.Close();
			}
		}

		private void button7_Click_1(object sender, EventArgs e)
		{

		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
