using MySql.Data.MySqlClient;
using Web_food.DAO;

namespace Web_food.Models
{
    public class Product
    {
        private int id;
        private string images;
        private string name;
        private string content;
        private int quantity;
        private double costDiscount;
        private double price;
        private int status;
        private int type;
        private int active;

        public Product()
        {
        }
        public Product(int id, int price, string name, string img, string content)
        {
            this.Id = id;
            this.Price = price;
            this.Name = name;
            this.Images = img;
            this.content = content;
        }

        public Product(int id, string images, string name, string content, int quantity, double costDiscount, double price, int type)
        {
            this.id = id;
            this.images = images;
            this.name = name;
            this.content = content;
            this.quantity = quantity;
            this.costDiscount = costDiscount;
            this.price = price;
            this.type = type;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Images
        {
            get => images;
            set => images = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Content
        {
            get => content;
            set => content = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public double CostDiscount
        {
            get => costDiscount;
            set => costDiscount = value;
        }

        public double Price
        {
            get => price;
            set => price = value;
        }

        public int Status
        {
            get => status;
            set => status = value;
        }

        public int Type
        {
            get => type;
            set => type = value;
        }

        public int Active
        {
            get => active;
            set => active = value;
        }
        
        public Product find(int id)  {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection conn = dbConnection.ConnectionSql();
            conn.Open();
            string   sql = "SELECT * FROM `products` WHERE active=1 AND id = @id";
            MySqlCommand  sqlCommand = new MySqlCommand(sql);
            sqlCommand.Connection = conn;
            sqlCommand.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int idSP = reader.GetInt32("id");
                    string Name = reader.GetString("name");
                    string Img = reader.GetString("image");
                    int Price = reader.GetInt32("price");
                    string content = reader.GetString("content");
                    Product p = new Product(idSP, Price, Name, Img, content);

                    return p;
                }
            }
            return null;
        }
    }
}