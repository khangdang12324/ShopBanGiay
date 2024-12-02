namespace ShopBanGiay
{
	partial class frmDoanhThu
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chartDT = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.dtgvDT = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
			this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTongDT = new System.Windows.Forms.TextBox();
			this.btnLoc = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.chartDT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgvDT)).BeginInit();
			this.SuspendLayout();
			// 
			// chartDT
			// 
			chartArea1.Name = "ChartArea1";
			this.chartDT.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chartDT.Legends.Add(legend1);
			this.chartDT.Location = new System.Drawing.Point(3, 0);
			this.chartDT.Name = "chartDT";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chartDT.Series.Add(series1);
			this.chartDT.Size = new System.Drawing.Size(778, 299);
			this.chartDT.TabIndex = 0;
			this.chartDT.Text = "chart1";
			this.chartDT.Click += new System.EventHandler(this.chartDT_Click);
			// 
			// dtgvDT
			// 
			this.dtgvDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvDT.Location = new System.Drawing.Point(3, 290);
			this.dtgvDT.Name = "dtgvDT";
			this.dtgvDT.RowHeadersWidth = 51;
			this.dtgvDT.RowTemplate.Height = 24;
			this.dtgvDT.Size = new System.Drawing.Size(1522, 577);
			this.dtgvDT.TabIndex = 1;
			this.dtgvDT.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDT_CellContentClick);
			this.dtgvDT.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgvDoanhThu_CellFormatting);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(967, 140);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "Từ ngày:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(967, 185);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "Đến ngày:";
			// 
			// dtpTuNgay
			// 
			this.dtpTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTuNgay.Location = new System.Drawing.Point(1092, 135);
			this.dtpTuNgay.Name = "dtpTuNgay";
			this.dtpTuNgay.Size = new System.Drawing.Size(200, 30);
			this.dtpTuNgay.TabIndex = 3;
			this.dtpTuNgay.ValueChanged += new System.EventHandler(this.dtpTuNgay_ValueChanged);
			// 
			// dtpDenNgay
			// 
			this.dtpDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpDenNgay.Location = new System.Drawing.Point(1092, 180);
			this.dtpDenNgay.Name = "dtpDenNgay";
			this.dtpDenNgay.Size = new System.Drawing.Size(200, 30);
			this.dtpDenNgay.TabIndex = 4;
			this.dtpDenNgay.ValueChanged += new System.EventHandler(this.dtpDenNgay_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(967, 239);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 25);
			this.label3.TabIndex = 2;
			this.label3.Text = "Tổng thu:";
			// 
			// txtTongDT
			// 
			this.txtTongDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTongDT.Location = new System.Drawing.Point(1092, 239);
			this.txtTongDT.Name = "txtTongDT";
			this.txtTongDT.Size = new System.Drawing.Size(349, 30);
			this.txtTongDT.TabIndex = 5;
			this.txtTongDT.TextChanged += new System.EventHandler(this.txtTongDT_TextChanged);
			// 
			// btnLoc
			// 
			this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoc.Location = new System.Drawing.Point(1312, 135);
			this.btnLoc.Name = "btnLoc";
			this.btnLoc.Size = new System.Drawing.Size(90, 38);
			this.btnLoc.TabIndex = 6;
			this.btnLoc.Text = "Lọc";
			this.btnLoc.UseVisualStyleBackColor = true;
			this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
			// 
			// frmDoanhThu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1537, 898);
			this.Controls.Add(this.btnLoc);
			this.Controls.Add(this.txtTongDT);
			this.Controls.Add(this.dtpDenNgay);
			this.Controls.Add(this.dtpTuNgay);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtgvDT);
			this.Controls.Add(this.chartDT);
			this.Name = "frmDoanhThu";
			this.Text = "Doanh Thu";
			this.Load += new System.EventHandler(this.frmDoanhThu_Load);
			((System.ComponentModel.ISupportInitialize)(this.chartDT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtgvDT)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chartDT;
		private System.Windows.Forms.DataGridView dtgvDT;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpTuNgay;
		private System.Windows.Forms.DateTimePicker dtpDenNgay;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTongDT;
		private System.Windows.Forms.Button btnLoc;
	}
}