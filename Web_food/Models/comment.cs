namespace Web_food.Models
{
    public class comment
    {
        public comment(string username, string comment_text)
        {
            this.username = username;
            this.comment_text = comment_text;
        }
        public comment()
        {
            
        }
        public int id_comment { get; set; }
        public string comment_text { get; set; }
        public int id_user { get; set; }
        public int id_product { get; set; }
        public string username { get; set; }
    }
}