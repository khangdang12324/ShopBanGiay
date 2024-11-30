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
    public partial class Form1 : Form
    {
        private List<Shoes> shoesList = new List<Shoes>();
        public Form1()
        {
            InitializeComponent();
        }

        private void lvHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            shoesList.Add( new Shoes(1, "Air Max 90", "Nike", "Black", 42, 120.99m, 5));
            AddShoesToListView();

        }
        private void AddShoesToListView()
        {
            lvGiay.Items.Clear(); 

            foreach (var shoe in shoesList)
            {
                
                ListViewItem item = new ListViewItem(shoe.ID.ToString());
                item.SubItems.Add(shoe.Name);
                item.SubItems.Add(shoe.Brand);
                item.SubItems.Add(shoe.Size.ToString());
                item.SubItems.Add(shoe.Color);
                item.SubItems.Add(shoe.Price.ToString("C"));  
                item.SubItems.Add(shoe.Quantity.ToString());

                
                lvGiay.Items.Add(item);
            }
        }
    }
}
