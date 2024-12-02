namespace ShopBanGiay
{
	partial class frmKhachHang
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
			this.components = new System.ComponentModel.Container();
			this.dtgvDSKH = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMaKH = new System.Windows.Forms.TextBox();
			this.txtTenKH = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.mtkSDTKH = new System.Windows.Forms.MaskedTextBox();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.grTTKH = new System.Windows.Forms.GroupBox();
			this.grTTMH = new System.Windows.Forms.GroupBox();
			this.cbHang = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cbSize = new System.Windows.Forms.ComboBox();
			this.txtDiem = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.btnCapNhat = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtSizeGiay = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.grFindKH = new System.Windows.Forms.GroupBox();
			this.cbLocSize = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtTim = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnThem = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtgvDSKH)).BeginInit();
			this.grTTKH.SuspendLayout();
			this.grTTMH.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grFindKH.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtgvDSKH
			// 
			this.dtgvDSKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvDSKH.ContextMenuStrip = this.contextMenuStrip1;
			this.dtgvDSKH.Location = new System.Drawing.Point(1, 351);
			this.dtgvDSKH.Name = "dtgvDSKH";
			this.dtgvDSKH.RowHeadersWidth = 51;
			this.dtgvDSKH.RowTemplate.Height = 24;
			this.dtgvDSKH.Size = new System.Drawing.Size(1556, 388);
			this.dtgvDSKH.TabIndex = 0;
			this.dtgvDSKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDSKH_CellClick);
			this.dtgvDSKH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDSKH_CellContentClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mã khách hàng:";
			// 
			// txtMaKH
			// 
			this.txtMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaKH.Location = new System.Drawing.Point(173, 33);
			this.txtMaKH.Name = "txtMaKH";
			this.txtMaKH.ReadOnly = true;
			this.txtMaKH.Size = new System.Drawing.Size(168, 26);
			this.txtMaKH.TabIndex = 2;
			this.txtMaKH.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// txtTenKH
			// 
			this.txtTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTenKH.Location = new System.Drawing.Point(167, 74);
			this.txtTenKH.Name = "txtTenKH";
			this.txtTenKH.Size = new System.Drawing.Size(295, 26);
			this.txtTenKH.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Tên khách hàng:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(7, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(137, 20);
			this.label4.TabIndex = 8;
			this.label4.Text = "SĐT khách hàng:";
			// 
			// mtkSDTKH
			// 
			this.mtkSDTKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mtkSDTKH.Location = new System.Drawing.Point(167, 112);
			this.mtkSDTKH.Mask = "(999) 000-0000";
			this.mtkSDTKH.Name = "mtkSDTKH";
			this.mtkSDTKH.Size = new System.Drawing.Size(166, 26);
			this.mtkSDTKH.TabIndex = 10;
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiaChi.Location = new System.Drawing.Point(167, 154);
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(295, 26);
			this.txtDiaChi.TabIndex = 12;
			this.txtDiaChi.TextChanged += new System.EventHandler(this.txtDiaChi_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 154);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 20);
			this.label5.TabIndex = 11;
			this.label5.Text = "Địa chỉ:";
			// 
			// grTTKH
			// 
			this.grTTKH.Controls.Add(this.txtTenKH);
			this.grTTKH.Controls.Add(this.txtDiaChi);
			this.grTTKH.Controls.Add(this.label5);
			this.grTTKH.Controls.Add(this.label1);
			this.grTTKH.Controls.Add(this.mtkSDTKH);
			this.grTTKH.Controls.Add(this.txtMaKH);
			this.grTTKH.Controls.Add(this.label4);
			this.grTTKH.Controls.Add(this.label2);
			this.grTTKH.Location = new System.Drawing.Point(12, 12);
			this.grTTKH.Name = "grTTKH";
			this.grTTKH.Size = new System.Drawing.Size(499, 250);
			this.grTTKH.TabIndex = 13;
			this.grTTKH.TabStop = false;
			this.grTTKH.Text = "Thông tin khách hàng";
			this.grTTKH.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// grTTMH
			// 
			this.grTTMH.Controls.Add(this.cbHang);
			this.grTTMH.Controls.Add(this.label7);
			this.grTTMH.Controls.Add(this.cbSize);
			this.grTTMH.Controls.Add(this.txtDiem);
			this.grTTMH.Controls.Add(this.label6);
			this.grTTMH.Controls.Add(this.label9);
			this.grTTMH.Location = new System.Drawing.Point(517, 12);
			this.grTTMH.Name = "grTTMH";
			this.grTTMH.Size = new System.Drawing.Size(492, 250);
			this.grTTMH.TabIndex = 14;
			this.grTTMH.TabStop = false;
			this.grTTMH.Text = "Thông tin mua hàng";
			// 
			// cbHang
			// 
			this.cbHang.FormattingEnabled = true;
			this.cbHang.Location = new System.Drawing.Point(175, 70);
			this.cbHang.Name = "cbHang";
			this.cbHang.Size = new System.Drawing.Size(298, 24);
			this.cbHang.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(13, 74);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 20);
			this.label7.TabIndex = 14;
			this.label7.Text = "Hạng thành viên:";
			// 
			// cbSize
			// 
			this.cbSize.FormattingEnabled = true;
			this.cbSize.Location = new System.Drawing.Point(175, 29);
			this.cbSize.Name = "cbSize";
			this.cbSize.Size = new System.Drawing.Size(298, 24);
			this.cbSize.TabIndex = 13;
			// 
			// txtDiem
			// 
			this.txtDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiem.Location = new System.Drawing.Point(175, 108);
			this.txtDiem.Name = "txtDiem";
			this.txtDiem.Size = new System.Drawing.Size(298, 26);
			this.txtDiem.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(16, 108);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(111, 20);
			this.label6.TabIndex = 11;
			this.label6.Text = "Điểm tích lũy:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(13, 33);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(47, 20);
			this.label9.TabIndex = 3;
			this.label9.Text = "Size:";
			// 
			// btnCapNhat
			// 
			this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCapNhat.Location = new System.Drawing.Point(27, 268);
			this.btnCapNhat.Name = "btnCapNhat";
			this.btnCapNhat.Size = new System.Drawing.Size(135, 34);
			this.btnCapNhat.TabIndex = 18;
			this.btnCapNhat.Text = "Cập nhật";
			this.btnCapNhat.UseVisualStyleBackColor = true;
			this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtSizeGiay);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Location = new System.Drawing.Point(517, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(492, 250);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thông tin mua hàng";
			// 
			// txtSizeGiay
			// 
			this.txtSizeGiay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSizeGiay.Location = new System.Drawing.Point(106, 33);
			this.txtSizeGiay.Name = "txtSizeGiay";
			this.txtSizeGiay.Size = new System.Drawing.Size(295, 26);
			this.txtSizeGiay.TabIndex = 13;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(13, 33);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(47, 20);
			this.label11.TabIndex = 3;
			this.label11.Text = "Size:";
			// 
			// grFindKH
			// 
			this.grFindKH.Controls.Add(this.label8);
			this.grFindKH.Controls.Add(this.cbLocSize);
			this.grFindKH.Controls.Add(this.label13);
			this.grFindKH.Controls.Add(this.txtTim);
			this.grFindKH.Location = new System.Drawing.Point(1015, 12);
			this.grFindKH.Name = "grFindKH";
			this.grFindKH.Size = new System.Drawing.Size(492, 250);
			this.grFindKH.TabIndex = 16;
			this.grFindKH.TabStop = false;
			this.grFindKH.Text = "Tìm kiếm khách hàng";
			// 
			// cbLocSize
			// 
			this.cbLocSize.FormattingEnabled = true;
			this.cbLocSize.Location = new System.Drawing.Point(173, 90);
			this.cbLocSize.Name = "cbLocSize";
			this.cbLocSize.Size = new System.Drawing.Size(298, 24);
			this.cbLocSize.TabIndex = 21;
			this.cbLocSize.SelectedIndexChanged += new System.EventHandler(this.cbLocSize_SelectedIndexChanged);
			this.cbLocSize.Click += new System.EventHandler(this.cbLocSize_Click);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(14, 90);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(47, 20);
			this.label13.TabIndex = 20;
			this.label13.Text = "Size:";
			// 
			// txtTim
			// 
			this.txtTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTim.Location = new System.Drawing.Point(176, 36);
			this.txtTim.Name = "txtTim";
			this.txtTim.Size = new System.Drawing.Size(295, 26);
			this.txtTim.TabIndex = 13;
			this.txtTim.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
			// 
			// xóaToolStripMenuItem
			// 
			this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
			this.xóaToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
			this.xóaToolStripMenuItem.Text = "Xóa ";
			this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
			// 
			// btnThem
			// 
			this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThem.Location = new System.Drawing.Point(185, 268);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(135, 34);
			this.btnThem.TabIndex = 20;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(14, 39);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(132, 20);
			this.label8.TabIndex = 22;
			this.label8.Text = "Tìm khách hàng:";
			// 
			// frmKhachHang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1568, 749);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.grFindKH);
			this.Controls.Add(this.btnCapNhat);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grTTMH);
			this.Controls.Add(this.grTTKH);
			this.Controls.Add(this.dtgvDSKH);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmKhachHang";
			this.Text = "z";
			this.Load += new System.EventHandler(this.frmKhachHang_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgvDSKH)).EndInit();
			this.grTTKH.ResumeLayout(false);
			this.grTTKH.PerformLayout();
			this.grTTMH.ResumeLayout(false);
			this.grTTMH.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grFindKH.ResumeLayout(false);
			this.grFindKH.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dtgvDSKH;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMaKH;
		private System.Windows.Forms.TextBox txtTenKH;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MaskedTextBox mtkSDTKH;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox grTTKH;
		private System.Windows.Forms.GroupBox grTTMH;
		private System.Windows.Forms.ComboBox cbHang;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbSize;
		private System.Windows.Forms.TextBox txtDiem;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnCapNhat;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox grFindKH;
		private System.Windows.Forms.TextBox txtTim;
		private System.Windows.Forms.ComboBox cbLocSize;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSizeGiay;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Label label8;
	}
}