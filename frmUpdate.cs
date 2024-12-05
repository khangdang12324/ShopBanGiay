using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopBanGiay
{
    public partial class frmUpdate : Form
    {
        Shoes shoes;
        public delegate void GetData(Shoes sp);
        public GetData data;

        public frmUpdate()
        {
            InitializeComponent();
        }

        public frmUpdate(Shoes sp)
        {
            InitializeComponent();
            shoes = sp;
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            cbTrangThai.SelectedIndex = 0;


            txtMaSP.Text = shoes.ID.ToString();
            txtTenSP.Text = shoes.Name;
            txtMau.Text = shoes.Color;
            txtHang.Text = shoes.Brand;
            txtLoai.Text = shoes.Type;
            txtGia.Text = shoes.Price.ToString();
            nbSize.Value = shoes.Size;
            nbSoLuong.Value = shoes.Quantity;
            txtGhiChu.Text = shoes.Description;
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Cập nhật thông tin shoes từ form
            shoes.ID = int.Parse(txtMaSP.Text);
            shoes.Name = txtTenSP.Text;
            shoes.Color = txtMau.Text;
            shoes.Brand = txtHang.Text;
            shoes.Type = txtLoai.Text;
            if (decimal.TryParse(txtGia.Text, out decimal gia))
            {
                shoes.Price = gia;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho Giá!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            shoes.Size = (int)nbSize.Value;
            shoes.Quantity = (int)nbSoLuong.Value;
            shoes.Description = txtGhiChu.Text;
            shoes.State = cbTrangThai.Text;

            // Gọi delegate để gửi dữ liệu
            data?.Invoke(shoes);

            // Đóng form
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
