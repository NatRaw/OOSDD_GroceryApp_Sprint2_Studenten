
namespace Grocery.Core.Models
{
    public partial class Client : Model
    {
        private string _emailAddress;
        private string _password { get; set; }
        
        // Publieke properties (toegankelijk buiten deze class)
        public int Id {get; set; }
        public string Name { get; set; }

        // Property voor het e-mailadres
        public string EmailAddress
        {
            get => _emailAddress;
            set => _emailAddress = value;
        }

        //Property voor het wachtwoord
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public Client(int id, string name, string emailAddress, string password) : base(id, name)
        {
            _emailAddress=emailAddress;
            _password=password;
        }
    }
}
