using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiplayerGames_Server.Application.UseCases.User;
using MultiplayerGames_Server.Application.UseCases.User.RequestDTOs;
using MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;
using MultiplayerGames_Server.Application.UseCases.XOGame;

namespace MultiplayerGames_Server.WebApi.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(
            LoginDto request,
            CancellationToken cancellationToken
        )
        {
            var response = await _authService.LoginAsync(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<AuthResponseDto>> SignUp(
            SignUpDto request,
            CancellationToken cancellationToken
        )
        {
            var response = await _authService.SignUpAsync(request, cancellationToken);
            return Ok(response);
        }
    }
}
