using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiplayerGames_Server.Application.UseCases.User;
using MultiplayerGames_Server.Application.UseCases.User.RequestDTOs;
using MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;
using MultiplayerGames_Server.Application.UseCases.XOGame;
using MultiplayerGames_Server.WebApi.Common;

namespace MultiplayerGames_Server.WebApi.Controllers
{
    /// <summary>
    /// Handles authentication-related operations, including user login and registration.
    /// </summary>
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticates an existing user and returns an access token.
        /// </summary>
        /// <returns>An <see cref="AuthResponseDto"/> containing the authentication result.</returns>
        /// <response code="200">Returns the authentication data with the access token.</response>
        /// <response code="400">If the request data is invalid.</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FailedProductionResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthResponseDto>> Login(
            [FromBody] LoginDto request,
            CancellationToken cancellationToken
        )
        {
            var response = await _authService.LoginAsync(request, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Registers a new user account and returns an access token.
        /// </summary>
        /// <returns>An <see cref="AuthResponseDto"/> containing the authentication result.</returns>
        /// <response code="200">Returns the authentication data with the access token.</response>
        /// <response code="400">If the request data is invalid.</response>
        [HttpPost("sign-up")]
        [ProducesResponseType(typeof(AuthResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FailedProductionResponse), StatusCodes.Status400BadRequest)]
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
