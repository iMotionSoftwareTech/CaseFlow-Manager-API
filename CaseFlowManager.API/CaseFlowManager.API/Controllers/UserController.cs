using CaseFlowManager.API.Service.Interfaces;
using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace IMotionSoftware.CaseFlowManager.API.Controllers
{
    /// <summary>
    /// The UserController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger<UserController> _logger;

        /// <summary>
        /// The user service
        /// </summary>
        private IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userService">The user service.</param>
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Creates the new user asynchronous.
        /// </summary>
        /// <param name="createUserRequest">The create user request.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        [HttpPost]
        [Route("CreateNewUserAsync")]
        public async Task<ActionResult<NewUser>> CreateNewUserAsync([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                var result = await this._userService.CreateUserAsync(createUserRequest);
                if (!result.IsSuccess)
                    return BadRequest("User creation failed.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        [HttpGet]
        [Route("GetUser/{email}")]
        public async Task<ActionResult<UserDetail>> GetUser(string email)
        {
            try
            {
                var result = await this._userService.GetUserAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving user.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        /// <summary>
        /// Updates the password attempt.
        /// </summary>
        /// <param name="caseworkerId">The caseworker identifier.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        [HttpPut]
        [Route("UpdatePasswordAttempt")]
        public async Task<ActionResult<PasswordAttempt>> UpdatePasswordAttempt([FromBody] PasswordAttemptRequest passwordAttemptRequest)
        {
            try
            {
                var result = await this._userService.UpdatePasswordAttemptAsync(passwordAttemptRequest);
                if (!result.IsSuccess)
                    return BadRequest("Updating password attempt failed.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating password attempt.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}