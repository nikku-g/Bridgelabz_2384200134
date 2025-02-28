using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatorylayer.Services
{
    public class UserRegistrationRL
    {
        public (string,string) RegistrationRL()
        {
            string user = "root";
            string pass = "root";
           
            return (user,pass);
        }
    }
}
