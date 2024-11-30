using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBanGiay
{
    public class Shoes
    {
        // Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }

        //ID,Name,Brand,Color,Size,Price,Quantity,Type,Description,ImagaLink

        public Shoes() { }
        public Shoes(int iD, string name, string brand, string color, int size, decimal price, int quantity)
        {
            ID = iD;
            Name = name;
            Brand = brand;
            Color = color;
            Size = size;
            Price = price;
            Quantity = quantity;

        }
        public Shoes(int iD, string name, string brand, string color, int size, decimal price, int quantity, string type, string description, string imageLink) : this(iD, name, brand, color, size, price, quantity)
        {
            Type = type;
            Description = description;
            ImageLink = imageLink;
        }
       
    }
}
