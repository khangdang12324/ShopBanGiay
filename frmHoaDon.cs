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
    public partial class frmHoaDon : Form
    {
        private TextBox autoCompleteTextBox;
        private AutoCompleteStringCollection autoCompleteCollection;
        public frmHoaDon()
        {
            InitializeComponent();
            SetUpAutoComplete();
        }
        private void SetUpAutoComplete()
        {
            // Tạo danh sách gợi ý
            autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(new string[]
            {
            "Apple",
            "Banana",
            "Cherry",
            "Date",
            "Fig",
            "Grape",
            "Kiwi",
            "Lemon",
            "Mango",
            "Orange",
            "Papaya",
            "Quince",
            "Raspberry",
            "Strawberry",
            "Tomato"
            });

            // Cài đặt thuộc tính tự động hoàn thành cho TextBox
            textBox1.AutoCompleteCustomSource = autoCompleteCollection;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Cập nhật danh sách gợi ý dựa trên nội dung của TextBox
            //UpdateAutoCompleteSource();
        }

        private void UpdateAutoCompleteSource()
        {
            // Tạo danh sách gợi ý dựa trên nội dung hiện tại của TextBox
            var filteredItems = autoCompleteCollection.Cast<string>()
                .Where(item => item.StartsWith(textBox1.Text, StringComparison.OrdinalIgnoreCase))
                .ToArray();

            // Cập nhật danh sách gợi ý
            textBox1.AutoCompleteCustomSource.Clear();
            textBox1.AutoCompleteCustomSource.AddRange(filteredItems);
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}
