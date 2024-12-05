namespace ShopBanGiay
{
    partial class frmAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btnThemVaoSQL = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.nbSoluong = new System.Windows.Forms.NumericUpDown();
            this.nbPrice = new System.Windows.Forms.NumericUpDown();
            this.nbSize = new System.Windows.Forms.NumericUpDown();
            this.txtMauSP = new System.Windows.Forms.TextBox();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.txtHang = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.txtGhiChuSP = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSoluong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbSize)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnThemVaoSQL);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.nbSoluong);
            this.panel1.Controls.Add(this.nbPrice);
            this.panel1.Controls.Add(this.nbSize);
            this.panel1.Controls.Add(this.txtMauSP);
            this.panel1.Controls.Add(this.txtLoai);
            this.panel1.Controls.Add(this.txtHang);
            this.panel1.Controls.Add(this.txtMaSP);
            this.panel1.Controls.Add(this.txtTenHang);
            this.panel1.Controls.Add(this.txtGhiChuSP);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 412);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(462, 335);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 30);
            this.button4.TabIndex = 7;
            this.button4.Text = "Thoát";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnThemVaoSQL
            // 
            this.btnThemVaoSQL.Location = new System.Drawing.Point(423, 371);
            this.btnThemVaoSQL.Name = "btnThemVaoSQL";
            this.btnThemVaoSQL.Size = new System.Drawing.Size(114, 30);
            this.btnThemVaoSQL.TabIndex = 7;
            this.btnThemVaoSQL.Text = "Lưu";
            this.btnThemVaoSQL.UseVisualStyleBackColor = true;
            this.btnThemVaoSQL.Click += new System.EventHandler(this.btnThemVaoSQL_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(77, 331);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(114, 30);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Thêm";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // nbSoluong
            // 
            this.nbSoluong.Location = new System.Drawing.Point(101, 179);
            this.nbSoluong.Name = "nbSoluong";
            this.nbSoluong.Size = new System.Drawing.Size(120, 27);
            this.nbSoluong.TabIndex = 4;
            // 
            // nbPrice
            // 
            this.nbPrice.Location = new System.Drawing.Point(290, 179);
            this.nbPrice.Name = "nbPrice";
            this.nbPrice.Size = new System.Drawing.Size(120, 27);
            this.nbPrice.TabIndex = 4;
            // 
            // nbSize
            // 
            this.nbSize.Location = new System.Drawing.Point(100, 97);
            this.nbSize.Name = "nbSize";
            this.nbSize.Size = new System.Drawing.Size(120, 27);
            this.nbSize.TabIndex = 4;
            this.nbSize.ValueChanged += new System.EventHandler(this.nbSize_ValueChanged);
            // 
            // txtMauSP
            // 
            this.txtMauSP.Location = new System.Drawing.Point(100, 143);
            this.txtMauSP.Name = "txtMauSP";
            this.txtMauSP.Size = new System.Drawing.Size(136, 27);
            this.txtMauSP.TabIndex = 3;
            this.txtMauSP.Click += new System.EventHandler(this.tbAddMH_Click);
            this.txtMauSP.TextChanged += new System.EventHandler(this.txtMauSP_TextChanged);
            // 
            // txtLoai
            // 
            this.txtLoai.Location = new System.Drawing.Point(297, 140);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Size = new System.Drawing.Size(249, 27);
            this.txtLoai.TabIndex = 3;
            this.txtLoai.Click += new System.EventHandler(this.tbAddMH_Click);
            // 
            // txtHang
            // 
            this.txtHang.Location = new System.Drawing.Point(297, 100);
            this.txtHang.Name = "txtHang";
            this.txtHang.Size = new System.Drawing.Size(249, 27);
            this.txtHang.TabIndex = 3;
            this.txtHang.Click += new System.EventHandler(this.tbAddMH_Click);
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(100, 14);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.ReadOnly = true;
            this.txtMaSP.Size = new System.Drawing.Size(191, 27);
            this.txtMaSP.TabIndex = 3;
            this.txtMaSP.Click += new System.EventHandler(this.tbAddMH_Click);
            this.txtMaSP.TextChanged += new System.EventHandler(this.txtMaSP_TextChanged);
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(100, 56);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(446, 27);
            this.txtTenHang.TabIndex = 3;
            // 
            // txtGhiChuSP
            // 
            this.txtGhiChuSP.Location = new System.Drawing.Point(77, 232);
            this.txtGhiChuSP.Name = "txtGhiChuSP";
            this.txtGhiChuSP.Size = new System.Drawing.Size(463, 93);
            this.txtGhiChuSP.TabIndex = 2;
            this.txtGhiChuSP.Text = "";
            this.txtGhiChuSP.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Lưu ý";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Giá";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Số lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Màu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Loại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hãng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã hàng";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(589, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 412);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(606, 412);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 414);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmAdd";
            this.Text = "Thêm mặt hàng";
            this.Load += new System.EventHandler(this.frmAdd_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbSoluong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbSize)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nbPrice;
        private System.Windows.Forms.NumericUpDown nbSize;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.RichTextBox txtGhiChuSP;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nbSoluong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.TextBox txtHang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMauSP;
        private System.Windows.Forms.Button btnThemVaoSQL;
    }
}