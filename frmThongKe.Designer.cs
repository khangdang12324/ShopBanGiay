namespace ShopBanGiay
{
	partial class frmThongKe
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
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgvChiTietGiay = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgvHoaDon = new System.Windows.Forms.DataGridView();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.btnLoc = new System.Windows.Forms.Button();
			this.cboNCC = new System.Windows.Forms.ComboBox();
			this.lblTongSoTien = new System.Windows.Forms.Label();
			this.lblTongSoDonHang = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvChiTietGiay)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBox2);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.dtpTo);
			this.panel1.Controls.Add(this.dtpFrom);
			this.panel1.Controls.Add(this.btnLoc);
			this.panel1.Controls.Add(this.cboNCC);
			this.panel1.Controls.Add(this.lblTongSoTien);
			this.panel1.Controls.Add(this.lblTongSoDonHang);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(3, 4);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1296, 561);
			this.panel1.TabIndex = 4;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// textBox2
			// 
			this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(469, 71);
			this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(81, 23);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "Đến ngày";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(20, 71);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(81, 23);
			this.textBox1.TabIndex = 6;
			this.textBox1.Text = "Từ ngày";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgvChiTietGiay);
			this.groupBox2.Location = new System.Drawing.Point(664, 155);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Size = new System.Drawing.Size(616, 309);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Chi tiết sản phẩm";
			// 
			// dgvChiTietGiay
			// 
			this.dgvChiTietGiay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvChiTietGiay.Location = new System.Drawing.Point(8, 23);
			this.dgvChiTietGiay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dgvChiTietGiay.Name = "dgvChiTietGiay";
			this.dgvChiTietGiay.RowHeadersWidth = 51;
			this.dgvChiTietGiay.Size = new System.Drawing.Size(600, 276);
			this.dgvChiTietGiay.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dgvHoaDon);
			this.groupBox1.Location = new System.Drawing.Point(24, 155);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Size = new System.Drawing.Size(616, 309);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Danh sách hóa đơn";
			// 
			// dgvHoaDon
			// 
			this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHoaDon.Location = new System.Drawing.Point(8, 23);
			this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dgvHoaDon.Name = "dgvHoaDon";
			this.dgvHoaDon.RowHeadersWidth = 51;
			this.dgvHoaDon.Size = new System.Drawing.Size(600, 276);
			this.dgvHoaDon.TabIndex = 0;
			this.dgvHoaDon.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellDoubleClick);
			// 
			// dtpTo
			// 
			this.dtpTo.CustomFormat = "dd/MM/yyyy";
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTo.Location = new System.Drawing.Point(579, 71);
			this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(265, 22);
			this.dtpTo.TabIndex = 3;
			// 
			// dtpFrom
			// 
			this.dtpFrom.CustomFormat = "dd/MM/yyyy";
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFrom.Location = new System.Drawing.Point(139, 71);
			this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(265, 22);
			this.dtpFrom.TabIndex = 3;
			// 
			// btnLoc
			// 
			this.btnLoc.Location = new System.Drawing.Point(865, 69);
			this.btnLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnLoc.Name = "btnLoc";
			this.btnLoc.Size = new System.Drawing.Size(100, 28);
			this.btnLoc.TabIndex = 2;
			this.btnLoc.Text = "Lọc";
			this.btnLoc.UseVisualStyleBackColor = true;
			this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
			// 
			// cboNCC
			// 
			this.cboNCC.FormattingEnabled = true;
			this.cboNCC.Location = new System.Drawing.Point(139, 21);
			this.cboNCC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cboNCC.Name = "cboNCC";
			this.cboNCC.Size = new System.Drawing.Size(160, 24);
			this.cboNCC.TabIndex = 1;
			// 
			// lblTongSoTien
			// 
			this.lblTongSoTien.AutoSize = true;
			this.lblTongSoTien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTongSoTien.Location = new System.Drawing.Point(28, 513);
			this.lblTongSoTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTongSoTien.Name = "lblTongSoTien";
			this.lblTongSoTien.Size = new System.Drawing.Size(105, 19);
			this.lblTongSoTien.TabIndex = 0;
			this.lblTongSoTien.Text = "Tổng Số Tiền";
			this.lblTongSoTien.Click += new System.EventHandler(this.lblTongSoTien_Click);
			// 
			// lblTongSoDonHang
			// 
			this.lblTongSoDonHang.AutoSize = true;
			this.lblTongSoDonHang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTongSoDonHang.Location = new System.Drawing.Point(28, 481);
			this.lblTongSoDonHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTongSoDonHang.Name = "lblTongSoDonHang";
			this.lblTongSoDonHang.Size = new System.Drawing.Size(145, 19);
			this.lblTongSoDonHang.TabIndex = 0;
			this.lblTongSoDonHang.Text = "Tổng Số Đơn Hàng";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 23);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Nhà Cung Cấp";
			// 
			// frmThongKe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1301, 566);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "frmThongKe";
			this.Text = "Thống kê";
			this.Load += new System.EventHandler(this.frmThongKe_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvChiTietGiay)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView dgvChiTietGiay;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dgvHoaDon;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.Button btnLoc;
		private System.Windows.Forms.ComboBox cboNCC;
		private System.Windows.Forms.Label lblTongSoTien;
		private System.Windows.Forms.Label lblTongSoDonHang;
		private System.Windows.Forms.Label label2;
	}
}