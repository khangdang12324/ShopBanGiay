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
    public partial class frmThemSl : Form
    {
        int soLuong;
        public frmThemSl()
        {
            InitializeComponent();
        }
        public delegate void GetData(int data);
        public GetData data;

        private void button2_Click(object sender, EventArgs e)
        {
            if (data != null) 
            {
                data((int)nbsl.Value); // Ép kiểu `decimal` về `int`
            }
        }

    }
}
