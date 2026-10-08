using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.Login;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.SignUp;
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
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Authenticates an existing user and returns an access token.
        /// </summary>
        /// <returns>An <see cref="LoginResponse"/> containing the authentication result.</returns>
        /// <response code="200">Returns the authentication data with the access token.</response>
        /// <response code="400">If the request data is invalid.</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FailedProductionResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> Login(
            [FromBody] LoginCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Registers a new user account and returns an access token.
        /// </summary>
        /// <returns>An <see cref="SignUpResponse"/> containing the authentication result.</returns>
        /// <response code="200">Returns the authentication data with the access token.</response>
        /// <response code="400">If the request data is invalid.</response>
        [HttpPost("sign-up")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(SignUpResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FailedProductionResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SignUpResponse>> SignUp(
            [FromForm] SignUpCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
    }
}
