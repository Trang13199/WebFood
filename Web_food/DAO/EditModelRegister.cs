namespace Web_food.EditModel
{
    public class EditModelRegister
    {
        private string username;
        private string password;
        private string email;
        private string phone;
        private string address;

        public string Address
        {
            get => address;
            set => address = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }
    }
}