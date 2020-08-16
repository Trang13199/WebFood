using Microsoft.Ajax.Utilities;

namespace Project.Models
{
    public class Role
    {

        public int id { get; set; }
        public string control { get; set; }
        public string action { get; set; }
        public int level { get; set; }
        
        public Role(int id, string control, string action, int level)
        {
            this.id = id;
            this.control = control;
            this.action = action;
            this.level = level;
        }
<<<<<<< HEAD
        public Role(string control, string action) {
            this.control = control;
            this.action = action;
        }

        public bool contain(string control, string action) { 
            return control.ToLower().Equals(this.control.ToLower()) && action.ToLower().Equals(this.action.ToLower());
        }

=======

        public bool contain(string control, string action)
        {
            return false;
        }
>>>>>>> 69df8b6a0eee270c1edd2673ee8f528ccee9a202
    }
}