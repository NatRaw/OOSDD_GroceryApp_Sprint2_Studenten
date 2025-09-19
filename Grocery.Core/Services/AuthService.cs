﻿using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientService _clientService;
        public AuthService(IClientService clientService)
        {
            _clientService = clientService;
        }
        public Client? Login(string email, string password)
        {
            //Vraag de klantgegevens [Client] op die je zoekt met het opgegeven emailadres
            var client = _clientService.Get(email);
            
            // Als geen client is gevonden mislukt login
            if (client == null)
            {
                return null;
            }
            
            //Als je een klant gevonden hebt controleer dan of het password matcht --> PasswordHelper.VerifyPassword(password, passwordFromClient)
            bool passwordValid = PasswordHelper.VerifyPassword(password, client.Password); //PasswordHelper gebruikt, omdat de wachtwoorden gehashed zijn opgeslagen
            
            //Als alles klopt dan klantgegveens teruggeven, anders null

            if (!passwordValid)
            {
                return null; //wachtwoord klopt niet
            }
            
            // wachtwoord klopt
            return client;
        }
    }
}
