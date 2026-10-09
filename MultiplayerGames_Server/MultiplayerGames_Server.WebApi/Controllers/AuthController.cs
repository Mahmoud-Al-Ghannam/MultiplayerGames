using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.ChangePassword;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.ConfirmEmail;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.ForgotPassword;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.Login;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.Logout;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.RefreshToken;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.ResendConfirmEmailOtp;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.ResetPassword;
using MultiplayerGames_Server.Application.UseCases.Auth.Commands.SignUp;
using MultiplayerGames_Server.WebApi.Common;
using MultiplayerGames_Server.WebApi.Requests.Auth;

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
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<LoginResponse>> Login(
            [FromBody] LoginCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Registers a new user account and returns a user id.
        /// </summary>
        /// <returns>An <see cref="SignUpResponse"/> containing the authentication result.</returns>
        [HttpPost("sign-up")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(SignUpResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<SignUpResponse>> SignUp(
            [FromForm] SignUpRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(request.ToCommand(), cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Refreshes the authentication token using a refresh token.
        /// </summary>
        /// <returns>An <see cref="RefreshTokenResponse"/> containing the new tokens.</returns>
        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(RefreshTokenResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<RefreshTokenResponse>> RefreshToken(
            [FromBody] RefreshTokenCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Logs out the current user and invalidates their session.
        /// </summary>
        /// <returns>An <see cref="LogoutResponse"/> confirming the logout.</returns>
        [HttpPost("logout")]
        [ProducesResponseType(typeof(LogoutResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<LogoutResponse>> Logout(
            [FromBody] LogoutCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Requests a password reset otp code to be sent to the user's email.
        /// </summary>
        /// <returns>A <see cref="ForgotPasswordResponse"/> confirming the request.</returns>
        [HttpPost("forgot-password")]
        [ProducesResponseType(typeof(ForgotPasswordResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ForgotPasswordResponse>> ForgotPassword(
            [FromBody] ForgotPasswordCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Resets the user's password using a valid reset otp code.
        /// </summary>
        /// <returns>A <see cref="ResetPasswordResponse"/> confirming the password change.</returns>
        [HttpPost("reset-password")]
        [ProducesResponseType(typeof(ResetPasswordResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResetPasswordResponse>> ResetPassword(
            [FromBody] ResetPasswordCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Confirms the user's email address using a verification token.
        /// </summary>
        /// <returns>A <see cref="ConfirmEmailResponse"/> confirming the verification.</returns>
        [HttpPost("confirm-email")]
        [ProducesResponseType(typeof(ConfirmEmailResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ConfirmEmailResponse>> ConfirmEmail(
            [FromBody] ConfirmEmailCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Resends the email confirmation OTP to the user.
        /// </summary>
        /// <returns>A <see cref="ResendConfirmEmailOtpResponse"/> confirming the email was sent.</returns>
        [HttpPost("resend-confirm-email-otp")]
        [ProducesResponseType(typeof(ResendConfirmEmailOtpResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResendConfirmEmailOtpResponse>> ResendConfirmEmailOtp(
            [FromBody] ResendConfirmEmailOtpCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Changes the password for the currently authenticated user.
        /// </summary>
        /// <returns>A <see cref="ChangePasswordResponse"/> confirming the password change.</returns>
        [HttpPost("change-password")]
        [Authorize]
        [ProducesResponseType(typeof(ChangePasswordResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ChangePasswordResponse>> ChangePassword(
            [FromBody] ChangePasswordCommand command,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
    }
}
