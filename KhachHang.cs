using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBanGiay
{
    public class KhachHang
    {
        public string IDCustomer { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public KhachHang() { }
        public KhachHang(string iDKhachHang, string name, string phoneNumber, string locate)
        {
            IDCustomer = iDKhachHang;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = locate;
        }
    }
}
