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
    public partial class ChonKH : Form
    {
        private List<KhachHang> dskh;

        // Delegate nhận dữ liệu KhachHang từ sự kiện
        public delegate void GetData(KhachHang kh);
        public GetData data;

        public ChonKH()
        {
            InitializeComponent();
        }

        public ChonKH(List<KhachHang> khachHangs)
        {
            InitializeComponent();
            dskh = khachHangs;

            // Hiển thị số lượng phần tử trong danh sách
            MessageBox.Show(dskh.Count.ToString());

            // Đặt nguồn dữ liệu cho DataGridView
            dataGridView1.DataSource = dskh;
            dataGridView1.Refresh();
        }

        // Sự kiện khi chọn một ô trong DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                
                KhachHang selectedKhachHang = dskh[e.RowIndex];
                data(selectedKhachHang);

                
                
            }
        }

        private void ChonKH_Load(object sender, EventArgs e)
        {
            // Xử lý nếu cần khi form được load
        }

        private void ChonKH_Load_1(object sender, EventArgs e)
        {

        }
    }

}
