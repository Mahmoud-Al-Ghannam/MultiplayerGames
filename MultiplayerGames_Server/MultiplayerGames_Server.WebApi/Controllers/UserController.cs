using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiplayerGames_Server.Application.Common.Responses;
using MultiplayerGames_Server.Application.UseCases.User;
using MultiplayerGames_Server.Application.UseCases.User.ResponseDTOs;
using MultiplayerGames_Server.WebApi.Common;
using MultiplayerGames_Server.WebApi.Helpers;

namespace MultiplayerGames_Server.WebApi.Controllers
{
    /// <summary>
    /// Handles user-related operations, including retrieving user information.
    /// </summary>
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ObjectUrlWrapper _objectUrlWrapper;

        public UserController(UserService userService, ObjectUrlWrapper objectUrlWrapper)
        {
            _userService = userService;
            _objectUrlWrapper = objectUrlWrapper;
        }

        /// <summary>
        /// Retrieves a list of all registered users.
        /// </summary>
        /// <returns>A collection of <see cref="UserInfoDto"/> objects wrapped in a standard response envelope.</returns>
        /// <response code="200">Returns the list of users successfully.</response>
        [HttpGet]
        [ProducesResponseType(
            typeof(BaseResponse<IEnumerable<UserInfoDto>>),
            StatusCodes.Status200OK
        )]
        public async Task<ActionResult<BaseResponse<IEnumerable<UserInfoDto>>>> GetUsers(
            CancellationToken cancellationToken
        )
        {
            var response = await _userService.GetUsersAsync(cancellationToken);
            response = response with
            {
                Data = response.Data?.Select(u => _objectUrlWrapper.WrapObjectUrls(u)),
            };
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
        /// <returns>The user matching the specified ID, wrapped in a standard response envelope.</returns>
        /// <response code="200">Returns the user successfully.</response>
        /// <response code="404">If no user is found with the specified ID.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<UserInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FailedProductionResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<UserInfoDto>>> GetUserById(
            string id,
            CancellationToken cancellationToken
        )
        {
            var response = await _userService.GetUserByIdAsync(id, cancellationToken);
            response = response with
            {
                Data = (
                    response.Data == null ? null : _objectUrlWrapper.WrapObjectUrls(response.Data)
                ),
            };
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a specific user by their email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
        /// <returns>The user matching the specified email, wrapped in a standard response envelope.</returns>
        /// <response code="200">Returns the user successfully.</response>
        /// <response code="404">If no user is found with the specified email.</response>
        [HttpGet("{email}/by-email")]
        [ProducesResponseType(typeof(BaseResponse<UserInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FailedProductionResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<UserInfoDto>>> GetUserByEmail(
            string email,
            CancellationToken cancellationToken
        )
        {
            var response = await _userService.GetUserByEmailAsync(email, cancellationToken);
            response = response with
            {
                Data = (
                    response.Data == null ? null : _objectUrlWrapper.WrapObjectUrls(response.Data)
                ),
            };
            return Ok(response);
        }
    }
}
