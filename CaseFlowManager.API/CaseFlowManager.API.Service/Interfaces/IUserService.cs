using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace CaseFlowManager.API.Service.Interfaces
{
    /// <summary>
    /// The IUserService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="createUserRequest">The create user request.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        Task<int> CreateUserAsync(CreateUserRequest createUserRequest);

        /// <summary>
        /// Gets the user asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        Task<UserDetail> GetUserAsync(string email);

        /// <summary>
        /// Updates the password attempt asynchronous.
        /// </summary>
        /// <param name="caseworkerId">The caseworker identifier.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        Task<int> UpdatePasswordAttemptAsync(int caseworkerId);
    }
}