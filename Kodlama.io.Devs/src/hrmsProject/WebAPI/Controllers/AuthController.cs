using Application.Features.Developer.Commands.LoginCommand;
using Application.Features.Developer.Commands.RegisterCommand;
using Application.Features.Developer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerDeveloperCommand)
        {
            AccessTokenDto result = await Mediator.Send(registerDeveloperCommand);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginDeveloperCommand)
        {
            AccessTokenDto result = await Mediator.Send(loginDeveloperCommand);

            return Ok(result);
        }
    }
}
