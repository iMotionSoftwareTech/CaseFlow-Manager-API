using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace CaseFlowManager.API.Service.Interfaces
{
    /// <summary>
    /// The ITaskService
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Creates the task asynchronous.
        /// </summary>
        /// <param name="createTaskRequest">The create task request.</param>
        /// <returns></returns>
        Task<int> CreateTaskAsync(CreateTaskRequest createTaskRequest);

        /// <summary>
        /// Gets all statuses asynchronous.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        Task<IEnumerable<Status>> GetAllStatusesAsync();

        /// <summary>
        /// Gets all tasks asynchronous.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// The <see cref="Task{TResult}" />
        /// </returns>
        Task<TaskRecord> GetAllTasksAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Gets the task with statuses by identifier asynchronous.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <returns>The <see cref="Task{T}"/></returns>
        Task<IEnumerable<CaseTaskStatus>> GetTaskWithStatusesByIdAsync(int taskId);

        /// <summary>
        /// Logs the task status asynchronous.
        /// </summary>
        /// <param name="logStatusRequest">The log status request.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        Task<int> LogTaskStatusAsync(LogStatusRequest logStatusRequest);
    }
}