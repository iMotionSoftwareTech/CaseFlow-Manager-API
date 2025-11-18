using CaseFlowManager.API.Service.Interfaces;
using CaseFlowManager.API.Service.Utilities;
using IMotionSoftware.CaseFlowDataPackage.Interfaces;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace CaseFlowManager.API.Service.Services
{
    /// <summary>
    /// The TaskService
    /// </summary>
    /// <seealso cref="CaseFlowManager.API.Service.Interfaces.ITaskService" />
    public class TaskService : ITaskService
    {
        /// <summary>
        /// The task repo
        /// </summary>
        private readonly ITaskRepo _taskRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskService"/> class.
        /// </summary>
        /// <param name="taskRepo">The task repo.</param>
        public TaskService(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

        /// <summary>
        /// Creates the task asynchronous.
        /// </summary>
        /// <param name="createTaskRequest">The create task request.</param>
        /// <returns></returns>
        public async Task<int> CreateTaskAsync(CreateTaskRequest createTaskRequest)
        {
            return await this._taskRepo.CreateTaskAsync(createTaskRequest.ToCreateTaskParameter());
        }

        /// <summary>
        /// Gets all statuses asynchronous.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}" />
        /// </returns>
        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await this._taskRepo.GetAllStatusesAsync().Result.ToStatuses();
        }
    }
}