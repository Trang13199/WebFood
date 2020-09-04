using System.Web.WebPages;

namespace Web_food.Models
{
    public class Role
    {
        public string name { get; set; }
        public string control { get; set; }
        public string action { get; set; }
        public int level { get; set; }

        public Role(string name, string control, string action, int level)
        {
            this.name = name;
            this.control = control;
            this.action = action;
            this.level = level;
        }

        public Role(string control, string action)
        {
            this.control = control;
            this.action = action;
        }

        public bool contain(string control, string action)
        {
            return control.ToLower().Equals(this.control.ToLower()) && action.ToLower().Equals(this.action.ToLower());
        }
    }
}