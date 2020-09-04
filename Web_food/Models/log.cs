using System;

namespace Web_food.Models
{
    public class Log {
        public int id { get; set; }
        public string message { get; set; }
        public string level { get; set; }
        public User user { get; set; }
        public string action { get; set; }
        public string ip { get; set; }
        public DateTime creatAt { get; set; }
        
    }
}