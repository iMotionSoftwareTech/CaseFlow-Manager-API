using CaseFlowManager.API.Service.Interfaces;
using IMotionSoftware.CaseFlowManager.API.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace CaseFlowManager.API.Controllers
{
    /// <summary>
    /// The RoleController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<RoleController> _logger;

        /// <summary>
        /// The role service
        /// </summary>
        private readonly IRoleService _roleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="roleService">The role service.</param>
        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        /// <summary>
        /// Creates the caseworker role asynchronous.
        /// </summary>
        /// <param name="createRoleRequest">The create role request.</param>
        /// <returns>The <see cref="Task{T}"/></returns>
        [HttpPost]
        [Route("CreateCaseworkerRoleAsync")]
        public async Task<ActionResult> CreateCaseworkerRoleAsync(CreateRoleRequest createRoleRequest)
        {
            try
            {
                var result = await this._roleService.CreateRoleAsync(createRoleRequest);
                if (result != -1)
                    return BadRequest("Role creation failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating role.");
                return StatusCode(500, "Internal server error");
            }
            
            return Ok();
        }

        /// <summary>
        /// Gets all caseworker roles asynchronous.
        /// </summary>
        /// <returns>The <see cref="Task{T}"/></returns>
        [HttpGet]
        [Route("GetAllCaseworkerRolesAsync")]
        public async Task<ActionResult> GetAllCaseworkerRolesAsync()
        {
            try
            {
                var result = await this._roleService.GetAllRolesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving roles.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}