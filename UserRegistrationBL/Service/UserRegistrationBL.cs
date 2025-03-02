using Microsoft.Extensions.Logging;
using ModelLayer.DTO;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class UserRegistrationBL
    {
        private readonly ILogger<UserRegistrationBL> _logger;
        UserRegistrationRL _userRegistrationRL;

        public UserRegistrationBL(ILogger<UserRegistrationBL> logger, UserRegistrationRL userRegistrationRL)
        {
            _logger = logger;
            _userRegistrationRL = userRegistrationRL;
        }

        public string registrationBL(string str)
        {
            _logger.LogInformation("registrationBL method called.");
            return _userRegistrationRL.registrationRL(str); 
        }

        public bool checkRegistrationUser(RegisterDTO user)
        {
            _logger.LogInformation(message: $"checkRegistrationUser method started for user {user.Username}");

            try
            {
                if (user == null)
                {
                    _logger.LogWarning("User cannot be null.");
                }

                bool result = _userRegistrationRL.RegisterUser(user);

                if (result)
                {
                    _logger.LogInformation("Login successfully.");
                }
                else
                {
                    _logger.LogWarning("Login failed.");
                }

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError("Unexpected error occured.");
                return false;
            }
        }

    }
}
