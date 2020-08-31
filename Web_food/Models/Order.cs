using System;

namespace Web_food.Models
{
    public class Order
    {
        public Order()
        {
            
        }
        public Order(string image, string name, string quantity, string price)
        {
            this.image = image;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }

        public Order(string id, string username, string phone, DateTime date, string image, string name, string quantity, string price, string total, string sum)
        {
            this.id = id;
            this.username = username;
            this.phone = phone;
            this.date = date;
            this.image = image;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.total = total;
            this.sum = sum;
        }

        public string id { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string image { get; set; } 
        public string name { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        
        public string status { get; set; }
        public DateTime date { get; set; }

        public string total
        {
            get;
            set;
        }

        public string sum { get; set; }
        
    }
}