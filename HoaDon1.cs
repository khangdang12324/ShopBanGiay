using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBanGiay
{
	internal class HoaDon1
	{
		public int Id { get; set; }
		public DateTime NgayLap { get; set; }
		public decimal TongTien { get; set; }
		public string TinhTrang { get; set; }
		public HoaDon1() { }
		public HoaDon1(int id, DateTime ngayLap, decimal tongTien, string tinhTrang)
		{
			Id = id;
			NgayLap = ngayLap;
			TongTien = tongTien;
			TinhTrang = tinhTrang;
		}
	}
}
