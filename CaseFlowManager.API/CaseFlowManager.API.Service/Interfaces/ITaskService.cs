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
    }
}