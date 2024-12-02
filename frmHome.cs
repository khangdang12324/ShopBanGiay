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
    public partial class frmHome : Form
    {
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            OpenChildForm(new frmChinh());
            btnHome.BackColor = Color.Black;
            btnHome.ForeColor = Color.White;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            ctmsDangXuat.Show(btnDangXuat, 0, btnDangXuat.Height);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChinh());
            ResetButtonColors();
            btnHome.BackColor = Color.Black;
            btnHome.ForeColor = Color.White;

     
            
        }

        private void ResetButtonColors()
        {

            btnHome.BackColor = Color.White;
            btnHD.BackColor = Color.White;
            btnExit.BackColor = Color.White;
            btnDT.BackColor = Color.White;
            btnMH.BackColor = Color.White;
            btnCD.BackColor = Color.White;
            btnTK.BackColor = Color.White;
            btnKhachHang.BackColor = Color.White;


			btnHome.ForeColor = Color.Black;
            btnHD.ForeColor = Color.Black;
            btnExit.ForeColor = Color.Black;
            btnDT.ForeColor = Color.Black;
            btnMH.ForeColor = Color.Black;
            btnCD.ForeColor = Color.Black;
            btnTK.ForeColor = Color.Black;
            btnKhachHang.ForeColor = Color.Black;

		}

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoaDon());
            ResetButtonColors();
            btnHD.BackColor = Color.Black;
            btnHD.ForeColor = Color.White;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void btnMH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDSMH());
            ResetButtonColors();
            btnMH.BackColor = Color.Black;
            btnMH.ForeColor = Color.White;
        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
			OpenChildForm(new frmKhachHang());
			ResetButtonColors();
			btnKhachHang.BackColor = Color.Black;
			btnKhachHang.ForeColor = Color.White;
		}

		private void btnDT_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frmDoanhThu());
			ResetButtonColors();
			btnDT.BackColor = Color.Black;
			btnDT.ForeColor = Color.White;
		}

		private void btnNCC_Click(object sender, EventArgs e)
		{
			OpenChildForm(new frmNhaCungCap());
			ResetButtonColors();
			btnNCC.BackColor = Color.Black;
			btnNCC.ForeColor = Color.White;
		}
	}
}
