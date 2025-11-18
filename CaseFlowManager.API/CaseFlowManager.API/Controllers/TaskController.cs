using CaseFlowManager.API.Service.Interfaces;
using IMotionSoftware.CaseFlowManager.API.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace IMotionSoftware.CaseFlowManager.API.Controllers
{
    /// <summary>
    /// The TaskController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<TaskController> _logger;

        /// <summary>
        /// The task service
        /// </summary>
        private readonly ITaskService _taskService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="taskService">The task service.</param>
        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        /// <summary>
        /// Creates the case task asynchronous.
        /// </summary>
        /// <param name="createTaskRequest">The create task request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateCaseTaskAsync")]
        public async Task<ActionResult> CreateCaseTaskAsync(CreateTaskRequest createTaskRequest)
        {
            try
            {
                var result = await this._taskService.CreateTaskAsync(createTaskRequest);
                if (result != -1)
                    return BadRequest("Task creation failed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating task.");
                return StatusCode(500, "Internal server error");
            }

            return Ok();
        }

        /// <summary>
        /// Gets all statuses asynchronous.
        /// </summary>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        [HttpGet]
        [Route("GetAllStatusesAsync")]
        public async Task<ActionResult> GetAllStatusesAsync()
        {
            try
            {
                var result = await this._taskService.GetAllStatusesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving statuses.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}