<<<<<<< HEAD
﻿namespace Web_food.Models
=======
namespace Web_food.Models
>>>>>>> 06772271c26297355a6fcd0480462c7d4dbd0d8e
{
    public class ProductType
    {
        private string name;
        private int id;
        private int active;

        public ProductType()
        {
            
        }
        public ProductType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public ProductType(int id, string name,int active)
        {
            this.Id = id;
            this.Name = name;
            this.active = active;
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
