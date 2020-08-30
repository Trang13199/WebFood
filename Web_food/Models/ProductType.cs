namespace Web_food.Models
{
    public class ProductType
    {
        private int id;
        private string name;
        private int active;

        public ProductType(int id, string name,int active)
        {
            this.Id = id;
            this.Name = name;
            this.active = active;
        }

        public ProductType()
        {
            
        }
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Active
        {
            get => active;
            set => active = value;
        }
    }
}