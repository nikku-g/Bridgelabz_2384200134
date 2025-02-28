using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposatorylayer.Services;

namespace BusinesslayerBL.Services
{
    public class UserRegistrationBL
    {
        UserRegistrationRL _userregistrationRL;
        public UserRegistrationBL(UserRegistrationRL userregistrationRL)
        {
            _userregistrationRL = userregistrationRL;
        }

        public string registrationBL(string username, string password)
        {
            var(user, pass) = _userregistrationRL.RegistrationRL();
            if (username == user && password == pass)
            {
                return "Login sucessfully";
            }
            else
            {
                return "Invalid user or password";
            }
        }
    }
}
