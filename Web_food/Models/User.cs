using System.Collections.Generic;

namespace Project.Models
{
    public class User
    {
        public int id{get;set;}
        public string userName{get;set;}
        public string password{get; set;} 
        public bool isActive{get; set;}
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public List<Role> roles {get; set;}

        public User()
        {
            
        }

        public User(string userName)
        {
            this.userName = userName;
        }
        public User(string uname, string pass, string email, string address, string phone) {
            this.userName = uname;
            this.password = pass;
            this.email = email;
            this.address = address;
            this.phone = phone;
        }

        public override string ToString()
        {
            return "User:: {'ID: " + id + "','userName: " + userName + "'}";
        }
    }

   
}