using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Service;
using ModelLayer.DTO;

namespace UserRegistration.Controllers;

[ApiController]
[Route("[controller]")]
public class UserRegistrationController : ControllerBase
{
    private readonly ILogger<UserRegistrationController> _logger;
    ResponseDTO<string> response;
    UserRegistrationBL _userRegistrationBL;

    public UserRegistrationController(ILogger<UserRegistrationController> logger, UserRegistrationBL userRegistrationBL)
    {
        _logger = logger;
        _userRegistrationBL = userRegistrationBL;
    }

    [HttpGet]
    public string registration()
    {
        _logger.LogInformation("Registration endpoint.");
        return _userRegistrationBL.registrationBL("String from controller.");   
    }

    [HttpPost]
    public IActionResult RegisterUser(RegisterDTO user)
    {
        _logger.LogInformation("RegisterUser method started.");
        try
        {
            response = new ResponseDTO<string>();

            bool result = _userRegistrationBL.checkRegistrationUser(user);

            if (result)
            {
                response.Success = true;
                response.Message = "Logged in successfully";
                response.Data = user.Password;
                _logger.LogInformation($"User {user.Username} logged in Successfully.");
                return Ok(response);
            }
            else
            {
                _logger.LogWarning("Login Failed.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception occured during user registration.");
            response.Success = false;
            response.Message = "Login Unsuccesful.";
            response.Data = ex.Message;
        }
        return BadRequest(response);
    }
}
