using System;

namespace Web_food.Models
{
    public class Order
    {
        public Order(string id, string username, string email, string phone, string address, string status, DateTime date, string sum, string total)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.phone = phone;
            this.address = address;
            this.status = status;
            this.date = date;
            this.sum = sum;
            this.total = total;
        }

        public Order()
        {
            
        }
        public string id { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
        public string total { get; set; }
        public string sum { get; set; }
        
    }
}