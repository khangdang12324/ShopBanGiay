using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyshopgiay
{
    public partial class frmDanhsachmathang : Form
    {
        public frmDanhsachmathang()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmDanhsachmathang_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmThemsanpham frmadd = new frmThemsanpham();
            frmadd.ShowDialog();
        }
    }
}
