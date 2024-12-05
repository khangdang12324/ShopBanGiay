using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ShopBanGiay
{
    public partial class frmAdd : Form
    {
        List<Shoes> dssp = new List<Shoes>();
        string connectionString = @"Data Source=LAPTOP-OR4AEC92\MSSQLSERVER01;Initial Catalog=SHOESSHOP2;Integrated Security=True;";
        public frmAdd()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            
            
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {

        }

        private void tbAddMH_Click(object sender, EventArgs e)
        {
            int newShoeID = GetShoeID(); 
            txtMaSP.Text = newShoeID.ToString(); 
        }

        int GetShoeID()
        {
            int id = 0; // Giá trị mặc định nếu không có dữ liệu
            string connectionString = @"Server=LAPTOP-OR4AEC92\MSSQLSERVER01;Database=SHOESSHOP;Trusted_Connection=True";
            string query = @"SELECT MAX(IDSanPham) AS MaxShoeID FROM SanPham;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar(); // Lấy giá trị đơn từ cơ sở dữ liệu

                    if (result != DBNull.Value) // Kiểm tra kết quả khác null
                    {
                        id = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return id + 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Shoes sp = new Shoes();

            sp.ID = int.Parse(txtMaSP.Text);
            sp.Name = txtTenHang.Text;
            sp.Brand = txtHang.Text;
            sp.Color = txtMauSP.Text;
            sp.Size = (int)nbSize.Value;
            sp.Price = (decimal)nbPrice.Value;
            sp.Quantity = (int)nbSoluong.Value;
            sp.Type = txtLoai.Text;
            sp.Description = txtGhiChuSP.Text;

            dssp.Add(sp);
            dataGridView1.DataSource = dssp;
        }
           

        private void txtMauSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void nbSize_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThemVaoSQL_Click(object sender, EventArgs e)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var item in dssp)
                {
                    using (SqlCommand command = new SqlCommand("usp_ThemSanPhamVaoInventory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@TenSanPham", item.Name);
                        command.Parameters.AddWithValue("@ThuongHieu", item.Brand);
                        command.Parameters.AddWithValue("@Loai", item.Type);
                        command.Parameters.AddWithValue("@Gia", item.Price);
                        command.Parameters.AddWithValue("@Sizes", item.Size);
                        command.Parameters.AddWithValue("@Maus", item.Color);
                        command.Parameters.AddWithValue("@Quantities", item.Quantity);

                        // Thực thi lệnh
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show($"Thêm sản phẩm '{item.Name}' thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi thêm sản phẩm '{item.Name}': {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
