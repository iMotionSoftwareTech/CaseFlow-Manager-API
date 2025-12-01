using IMotionSoftware.CaseFlowDataPackage.DomainObjects;
using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace CaseFlowManager.API.Service.Utilities
{
    /// <summary>
    /// The DomainObjectConverter
    /// </summary>
    public static class DomainObjectConverter
    {
        /// <summary>
        /// Converts to createroleparameter.
        /// </summary>
        /// <param name="createRoleRequest">The create role request.</param>
        /// <returns>THe <see cref="CreateRoleParameter"/></returns>
        public static CreateRoleParameter ToCreateRoleParameter(this CreateRoleRequest createRoleRequest)
        {
            return new CreateRoleParameter
            {
                RoleName = createRoleRequest.RoleName,
                Description = createRoleRequest.Description
            };
        }

        /// <summary>
        /// Converts to createtaskparameter.
        /// </summary>
        /// <param name="createTaskRequest">The create task request.</param>
        /// <returns>The <see cref="CreateTaskParameter"/></returns>
        public static CreateTaskParameter ToCreateTaskParameter(this CreateTaskRequest createTaskRequest)
        {
            return new CreateTaskParameter
            {
                CaseworkerId = createTaskRequest.CaseworkerId,
                Title = createTaskRequest.Title,
                Description = createTaskRequest.Description,
                DueDateTime = createTaskRequest.DueDateTime
            };
        }

        /// <summary>
        /// Converts to createuserparameter.
        /// </summary>
        /// <param name="createUserRequest">The create user request.</param>
        /// <returns>The <see cref="CreateUserParameter"/></returns>
        public static CreateUserParameter ToCreateUserParameter(this CreateUserRequest createUserRequest)
        {
            return new CreateUserParameter
            {
                CaseworkerRoleId = createUserRequest.CaseworkerRoleId,
                Forename = createUserRequest.Forename,
                Surname = createUserRequest.Surname,
                Email = createUserRequest.Email,
                PasswordHash = DataTypeConverters.VarBinaryStringToBytes(createUserRequest.PasswordHash),
                PasswordSalt = DataTypeConverters.VarBinaryStringToBytes(createUserRequest.PasswordSalt),
                CreatedDateTime = createUserRequest.CreatedDateTime
            };
        }

        /// <summary>
        /// Converts to caseworkerrole.
        /// </summary>
        /// <param name="caseworkerRoles">The caseworker role.</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseworkerRole> ToCaseworkerRoles(this IEnumerable<CaseworkerRoleDto> caseworkerRoles)
        {
            var roles = new List<CaseworkerRole>();
            foreach (var role in caseworkerRoles)
            {
                roles.Add(new CaseworkerRole
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                });
            };

            return roles;
        }

        /// <summary>
        /// Converts to statuses.
        /// </summary>
        /// <param name="statuses">The statuses.</param>
        /// <returns>The <see cref="Task{TResult}"/></returns>
        public static IEnumerable<Status> ToStatuses(this IEnumerable<StatusDto> statuses)
        {
            var statusList = new List<Status>();
            foreach (var status in statuses)
            {
                statusList.Add(new Status
                {
                    Id = status.Id,
                    Title = status.Title
                });
            };
            return statusList;
        }

        /// <summary>
        /// Converts to taskrecord.
        /// </summary>
        /// <param name="totalRecords">The total records.</param>
        /// <param name="tasks">The tasks.</param>
        /// <returns>The <see cref="TaskRecord"/></returns>
        public static TaskRecord ToTaskRecord(this int totalRecords, IEnumerable<TaskDto> tasks)
        {
            return new TaskRecord
            {
                TotalNoOfRecords = totalRecords,
                Tasks = tasks.ToCaseTasks()
            };
        } 

        /// <summary>
        /// Converts to casetasks.
        /// </summary>
        /// <param name="tasks">The tasks.</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseTask> ToCaseTasks(this IEnumerable<TaskDto> tasks) 
        { 
            var taskList = new List<CaseTask>();
            foreach (var task in tasks)
            {
                taskList.Add(new CaseTask
                {
                    TaskId = task.TaskId,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                    DueDateTime = task.DueDateTime
                });
            };
            return taskList;
        }

        /// <summary>
        /// Converts to casetaskstatuses.
        /// </summary>
        /// <param name="taskStatuses">The task statuses.</param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseTaskStatus> ToCaseTaskStatuses(this IEnumerable<TaskStatusDto> taskStatuses)
        {
            var caseTaskStatusList = new List<CaseTaskStatus>();
            foreach (var caseTaskStatus in taskStatuses)
            {
                caseTaskStatusList.Add(new CaseTaskStatus
                {
                    Id = caseTaskStatus.Id,
                    CaseWorker = caseTaskStatus.CaseWorker,
                    TaskId = caseTaskStatus.TaskId,
                    StatusId = caseTaskStatus.StatusId,
                    Status = caseTaskStatus.Status,
                    Notes = caseTaskStatus.Notes,
                    LogDateTime = caseTaskStatus.LogDateTime
                });
            };
            return caseTaskStatusList;
        }

        /// <summary>
        /// Converts to userdetail.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <returns>The <see cref="UserDetail"/></returns>
        public static UserDetail ToUserDetail(this UserDetailDto userDetail) 
        {
            return new UserDetail
            {
                CaseworkerId = userDetail.CaseworkerId,
                CaseworkerRoleId = userDetail.CaseworkerRoleId,
                Role = userDetail.Role,
                Email = userDetail.Email,
                Username = userDetail.Username,
                Forename = userDetail.Forename,
                Surname = userDetail.Surname,
                PasswordAttempt = userDetail.PasswordAttempt,
                IsLocked = userDetail.IsLocked
            };
        }
    }
}