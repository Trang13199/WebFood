using System.Collections.Generic;

namespace Web_food.Models
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }


        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        
        public string gender { get; set; }
        
        public int level { get; set; }
        public List<Role> roles { get; set; }

        public bool isActive { get; set; }

        public User()
        {
        }

        public User(string userName)
        {
            this.userName = userName;
        }

        public User(int id,string uname, string pass, string email, string address, string phone, string gender, int level)
        {
            this.id = id;
            this.userName = uname;
            this.password = pass;
            this.email = email;
            this.address = address;
            this.phone = phone;
            this.gender = gender;
            this.level = level;
        }

        public override string ToString()
        {
            return "User:: {'ID: " + id + "','userName: " + userName + "pass:"+password+" email: "+email
                   +" address: "+address+ "phone: "+phone+" gender: "+gender+" level: "+level+ "'}";
        }
    }
}