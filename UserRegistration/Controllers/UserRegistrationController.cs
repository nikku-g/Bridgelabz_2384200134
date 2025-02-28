using Microsoft.AspNetCore.Mvc;
using BusinesslayerBL.Services;
using Reposatorylayer.Services;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        UserRegistrationBL _userregistrationBL;

        public UserRegistrationController(UserRegistrationBL userRegistrationBL)
        {
            _userregistrationBL = userRegistrationBL;
        }
        [HttpGet]
        public string Registration()
        {
            string username = "root";
            string password = "root";

            return _userregistrationBL.registrationBL(username, password);
        }

    }
}
