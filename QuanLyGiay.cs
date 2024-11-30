using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBanGiay
{
    internal class QuanLyGiay
    {
        List<Shoes> ds = new List<Shoes>();

        public QuanLyGiay()
        {
            this.ds = new List<Shoes>();
        }

        public Shoes this[int index]
        {
            get { return ds[index]; }
            set { ds[index] = value; }
        }
        public void Add(Shoes shoes)
        {
            ds.Add(shoes);
        }
    }
}
