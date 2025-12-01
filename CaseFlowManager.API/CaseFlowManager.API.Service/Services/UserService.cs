using CaseFlowManager.API.Service.Interfaces;
using CaseFlowManager.API.Service.Utilities;
using IMotionSoftware.CaseFlowDataPackage.Interfaces;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace CaseFlowManager.API.Service.Services
{
    /// <summary>
    /// The UserService
    /// </summary>
    /// <seealso cref="CaseFlowManager.API.Service.Interfaces.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The user repo
        /// </summary>
        private readonly IUserRepo _userRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepo">The user repo.</param>
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="createUserRequest">The create user request.</param>
        /// <returns>
        /// The <see cref="Task{TResult}" />
        /// </returns>
        public async Task<int> CreateUserAsync(CreateUserRequest createUserRequest)
        {
            return await this._userRepo.CreateUserAsync(createUserRequest.ToCreateUserParameter());
        }

        /// <summary>
        /// Gets the user asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// The <see cref="Task{TResult}" />
        /// </returns>
        public async Task<UserDetail> GetUserAsync(string email)
        {
            var result = await this._userRepo.GetUserAsync(email);
            return result.ToUserDetail();
        }
    }
}