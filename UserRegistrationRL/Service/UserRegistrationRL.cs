using Microsoft.Extensions.Logging;
using ModelLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class UserRegistrationRL
    {
        private readonly ILogger<UserRegistrationRL> _logger;
        private string databaseUsername = "Vishal@234";
        private string databasePassword = "123654";

        public UserRegistrationRL(ILogger<UserRegistrationRL> logger)
        {
            _logger = logger;
        }

        public string registrationRL(string str)
        {
            _logger.LogInformation("registrationRL method called.");
            return $"this is repository layer, {str}"; 
        }

        public bool RegisterUser(RegisterDTO user)
        {
            _logger.LogInformation("RegisterUser method started.");
            try
            {
                if (user == null)
                {
                    _logger.LogWarning("Recieved null user object.");
                    throw new ArgumentNullException(nameof(user), "User data cannot be null.");
                }

                _logger.LogInformation("Verifying credentials.");
                if (!user.Username.Equals(databaseUsername) || !user.Password.Equals(databasePassword))
                {
                    _logger.LogInformation("Invalid login attempt.");
                    return false;
                }

                databaseUsername = user.Username;
                databasePassword = user.Password;
                _logger.LogInformation("User registered successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error occured.");
                return false;
            }
        }
    }
}
