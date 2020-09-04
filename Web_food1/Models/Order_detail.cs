using System;
using System.Collections.Generic;

namespace Web_food.Models
{
    public class Order_detail
    {
        public Order_detail(string id_order, string image, string name, int quantity, double price, DateTime date)
        {
            this.id_order = id_order;
            this.name = name;
            this.image = image;
            this.quantity = quantity;
            this.price = price;
            this.date = date;
        }

        public Order_detail()
        {
            
        }

        public string image { get; set; } 
        public string name { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string id_order { get; set; }
        public int product_id { get; set; }

        public DateTime date
        {
            get
            {
                Order o = new Order();
                return o.date;
            }
            set
            {
                Order o = new Order();
            }
        }
    }
}