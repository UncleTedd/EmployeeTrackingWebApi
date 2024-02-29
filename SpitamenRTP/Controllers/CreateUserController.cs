using Microsoft.AspNetCore.Mvc;

namespace SpitamenRTP.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CreateUserController : Controller
{
    private IUserService _userService;

    public CreateUserController (IUserService userService)
    {
        _userService = userService;
    }

}
