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
            var result = await this._taskRepo.GetAllStatusesAsync();
            return result.ToStatuses();
        }

        /// <summary>
        /// Gets all tasks asynchronous.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// The <see cref="Task{TResult}" />
        /// </returns>
        public async Task<TaskRecord> GetAllTasksAsync(int pageNumber, int pageSize)
        {
            var (total, tasks) = await this._taskRepo.GetAllTasksAsync(pageNumber, pageSize);
            return total.ToTaskRecord(tasks);
        }

        /// <summary>
        /// Gets the task with statuses by identifier asynchronous.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <returns>
        /// The <see cref="Task{T}" />
        /// </returns>
        public async Task<IEnumerable<CaseTaskStatus>> GetTaskWithStatusesByIdAsync(int taskId)
        {
            var result = await this._taskRepo.GetTaskWithStatusesByIdAsync(taskId);
            return result.ToCaseTaskStatuses();
        }
    }
}