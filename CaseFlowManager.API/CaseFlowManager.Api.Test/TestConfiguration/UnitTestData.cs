using IMotionSoftware.CaseFlowDataPackage.DomainObjects;
using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;

namespace IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration
{
    /// <summary>
    /// The UnitTestData
    /// </summary>
    public static class UnitTestData
    {
        /// <summary>
        /// Gets the create role request.
        /// </summary>
        /// <returns>The <see cref="CreateRoleRequest"</returns>
        public static CreateRoleRequest GetCreateRoleRequest()
        {
            return new CreateRoleRequest
            {
                RoleName = "Test Role",
                Description = "This is a test role"
            };
        }

        /// <summary>
        /// Gets the create task request.
        /// </summary>
        /// <returns>The <see cref="CreateTaskRequest"/>/returns>
        public static CreateTaskRequest GetCreateTaskRequest()
        {
            return new CreateTaskRequest
            {
                CaseworkerId = 1,
                Title = "Test Task",
                Description = "This is a test task",
                DueDateTime = DateTime.UtcNow.AddDays(7)
            };
        }

        /// <summary>
        /// Gets the create user request.
        /// </summary>
        /// <returns>The <see cref="CreateUserRequest"/></returns>
        public static CreateUserRequest GetCreateUserRequest()
        {
            return new CreateUserRequest
            {
                CaseworkerRoleId = 1,
                Forename = "John",
                Surname = "Doe",
                Email = "john.doe@hmcts.org.uk"
            };
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseworkerRoleResult> GetAllRoles()
        {
            return new List<CaseworkerRoleResult>
            {
                new CaseworkerRoleResult
                {
                    Id = 1,
                    Name = "Role 1",
                    Description = "Description for Role 1"
                },
                new CaseworkerRoleResult
                {
                    Id = 2,
                    Name = "Role 2",
                    Description = "Description for Role 2"
                }
            };
        }

        /// <summary>
        /// Gets all caseworker roles.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseworkerRole> GetAllCaseworkerRoles()
        {
            return new List<CaseworkerRole>
            {
                new CaseworkerRole
                {
                    Id = 3,
                    Name = "Role 3",
                    Description = "Description for Role 3"
                },
                new CaseworkerRole
                {
                    Id = 4,
                    Name = "Role 4",
                    Description = "Description for Role 4"
                }
            };
        }

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<Status> GetAllStatuses()
        {
            return new List<Status>
            {
                new Status
                {
                    Id = 1,
                    Title = "Open"
                },
                new Status
                {
                    Id = 2,
                    Title = "In Progress"
                },
                new Status
                {
                    Id = 3,
                    Title = "Closed"
                }
            };
        }

        /// <summary>
        /// Gets all status Result.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<StatusResult> GetAllStatusResult()
        {
            return new List<StatusResult>
            {
                new StatusResult
                {
                    Id = 4,
                    Title = "Awaiting Hearing"
                },
                new StatusResult
                {
                    Id = 5,
                    Title = "Scheduled Hearing"
                },
                new StatusResult
                {
                    Id = 6,
                    Title = "Transferred"
                }
            };
        }

        /// <summary>
        /// Gets all case tasks.
        /// </summary>
        /// <returns>The <see cref="TaskRecord"/></returns>
        public static TaskRecord GetAllCaseTasks()
        {
            return new TaskRecord
            {
                TotalNoOfRecords = 2,
                Tasks = new List<CaseTask>
                {
                    new CaseTask
                    {
                        TaskId = 1,
                        Title = "Task 1",
                        Description = "Description for Task 1",
                        DueDateTime = DateTime.UtcNow.AddDays(3),
                        Status = "Open"
                    },
                    new CaseTask
                    {
                        TaskId = 2,
                        Title = "Task 2",
                        Description = "Description for Task 2",
                        DueDateTime = DateTime.UtcNow.AddDays(5),
                        Status = "In Progress"
                    }
                }
            };
        }

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TaskResult> GetAllTasks()
        {
            return new List<TaskResult>
            {
                new TaskResult
                {
                    TaskId = 3,
                    Title = "Task 3",
                    Description = "Description for Task 3",
                    DueDateTime = DateTime.UtcNow.AddDays(4),
                    Status = "Open"
                },
                new TaskResult
                {
                    TaskId = 4,
                    Title = "Task 4",
                    Description = "Description for Task 4",
                    DueDateTime = DateTime.UtcNow.AddDays(6),
                    Status = "In Progress"
                }
            };
        }

        /// <summary>
        /// Gets the task status Results.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<TaskStatusResult> GetTaskStatusResult()
        {
            return new List<TaskStatusResult>
            {
                new TaskStatusResult
                {
                    Id = 1,
                    CaseWorker = "John Doe",
                    TaskId = 1,
                    StatusId = 1,
                    Status = "Open",
                    Notes = "Open case created",
                    LogDateTime = DateTime.UtcNow.AddDays(-2)
                },
                new TaskStatusResult
                {
                    Id = 2,
                    CaseWorker = "Jane Doe",
                    TaskId = 2,
                    StatusId = 2,
                    Status = "In Progress",
                    Notes = "Case in progress",
                    LogDateTime = DateTime.UtcNow.AddDays(-1)
                }
            };
        }

        /// <summary>
        /// Gets the task statuses.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<CaseTaskStatus> GetTaskStatuses()
        {
            return new List<CaseTaskStatus>
            {
                new CaseTaskStatus
                {
                    Id = 1,
                    CaseWorker = "Bob Wilkinson",
                    TaskId = 1,
                    StatusId = 2,
                    Status = "In Progress",
                    Notes = "Case in progress",
                    LogDateTime = DateTime.UtcNow.AddDays(2)
                },
                new CaseTaskStatus
                {
                    Id = 2,
                    CaseWorker = "Fred Cotteridge",
                    TaskId = 2,
                    StatusId = 3,
                    Status = "Hearing Scheduled",
                    Notes = "Case hearing scheduled",
                    LogDateTime = DateTime.UtcNow.AddDays(1)
                }
            };
        }

        /// <summary>
        /// Gets the user detail Result.
        /// </summary>
        /// <returns>The <see cref="UserDetailResult"/></returns>
        public static UserDetailResult GetUserDetailResult()
        {
            return new UserDetailResult
            {
                CaseworkerId = 10,
                CaseworkerRoleId = 2,
                Role = "Caseworker",
                Username = "ASmith",
                Forename = "Alice",
                Surname = "Smith",
                Email = "testuser@testsite.com",
                IsLocked = false,
                PasswordAttempt = 0
            };
        }

        /// <summary>
        /// Gets the user detail.
        /// </summary>
        /// <returns>The <see cref="UserDetail"</returns>
        public static UserDetail GetUserDetail()
        {
            return new UserDetail
            {
                CaseworkerId = 11,
                CaseworkerRoleId = 2,
                Role = "Caseworker",
                Username = "ASmith",
                Forename = "Alan",
                Surname = "Smith",
                Email = "testuser@testsite.com",
                IsLocked = false,
                PasswordAttempt = 0
            };
        }

        /// <summary>
        /// Gets the log status request.
        /// </summary>
        /// <returns>The <see cref="LogStatusRequest"/></returns>
        public static LogStatusRequest GetLogStatusRequest()
        {
            return new LogStatusRequest
            {
                CaseworkerId = 1,
                TaskId = 2,
                StatusId = 3,
                Notes = "Updating status to Hearing Scheduled",
                LogDateTime = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Gets the task status requests.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<LogStatusRequest> GetTaskStatusRequests()
        {
            return new List<LogStatusRequest>
            {
                new LogStatusRequest
                {
                    CaseworkerId = 2,
                    TaskId = 1,
                    StatusId = 3,
                    Notes = "Updating status to Hearing Scheduled",
                    LogDateTime = DateTime.UtcNow
                },
                new LogStatusRequest
                {
                    CaseworkerId = 1,
                    TaskId = 2,
                    StatusId = 4,
                    Notes = "Hearing was held",
                    LogDateTime = DateTime.UtcNow
                }
            };
        }

        /// <summary>
        /// Gets the password attempt request.
        /// </summary>
        /// <returns>The <see cref="PasswordAttemptRequest"/></returns>
        public static PasswordAttemptRequest GetPasswordAttemptRequest()
        {
            return new PasswordAttemptRequest
            {
                CaseworkerId = 5,
                MaxAttempts = 3
            };
        }

        /// <summary>
        /// Gets the new user result.
        /// </summary>
        /// <returns>The <see cref="NewUserResult"/></returns>
        public static NewUserResult GetNewUserResult()
        {
            return new NewUserResult
            {
                CaseworkerId = 5,
                Success = true,
                ErrorMessage = "User created successfully"
            };
        }

        /// <summary>
        /// Gets the password attempt result.
        /// </summary>
        /// <returns>The <see cref="PasswordAttempt"/></returns>
        public static PasswordAttemptResult GetPasswordAttemptResult()
        {
            return new PasswordAttemptResult
            {
                NewAttemptCount = 2,
                WasLocked = false,
                Success = true,
                ErrorMessage = string.Empty
            };
        }

        /// <summary>
        /// Gets the new task result.
        /// </summary>
        /// <returns>The <see cref="NewTaskResult"/></returns>
        public static NewTaskResult GetNewTaskResult()
        {
            return new NewTaskResult
            {
                TaskId = 7,
                Success = true,
                ErrorMessage = string.Empty
            };
        }

        /// <summary>
        /// Gets the task update result.
        /// </summary>
        /// <returns>The <see cref="TaskUpdateResult"/></returns>
        public static TaskUpdateResult GetTaskUpdateResult()
        {
            return new TaskUpdateResult
            {
                TaskStatusId = 3,
                Success = true,
                ErrorMessage = string.Empty
            };
        }

        /// <summary>
        /// Gets the bulk task update result.
        /// </summary>
        /// <returns>The <see cref="BulkTaskUpdateResult"/></returns>
        public static BulkTaskUpdateResult GetBulkTaskUpdateResult()
        {
            return new BulkTaskUpdateResult
            {
                InsertedCount = 5,
                Success = true,
                ErrorMessage = string.Empty
            };
        }

        /// <summary>
        /// Gets the new role result.
        /// </summary>
        /// <returns>The <see cref="NewRoleResult"/></returns>
        public static NewRoleResult GetNewRoleResult()
        {
            return new NewRoleResult
            {
                RoleId = 4,
                Success = true,
                ErrorMessage = string.Empty
            };
        }


        /// <summary>
        /// Gets the new user response.
        /// </summary>
        /// <returns>The <see cref="NewUser"/></returns>
        public static NewUser GetNewUserResponse()
        {
            return new NewUser
            {
                CaseworkerId = 5,
                IsSuccess = true,
                ErrorMessage = "User created successfully"
            };
        }

        /// <summary>
        /// Gets the password attempt response.
        /// </summary>
        /// <returns>The <see cref="PasswordAttempt"/></returns>
        public static PasswordAttempt GetPasswordAttemptResponse()
        {
            return new PasswordAttempt
            {
                NewAttemptCount = 2,
                WasLocked = false,
                IsSuccess = true,
                ErrorMessage = string.Empty
            };
        }

        /// <summary>
        /// Gets the new task response.
        /// </summary>
        /// <returns>The <see cref="NewTask"/></returns>
        public static NewTask GetNewTaskResponse()
        {
            return new NewTask
            {
                TaskId = 7,
                IsSuccess = true,
                ErrorMessage = string.Empty
            };
        }

        /// <summary>
        /// Gets the task update response.
        /// </summary>
        /// <returns>The <see cref="TaskUpdate"/></returns>
        public static TaskUpdate GetTaskUpdateResponse()
        {
            return new TaskUpdate
            {
                TaskStatusId = 3,
                IsSuccess = true,
                ErrorMessage = string.Empty
            };
        }

        /// <summary>
        /// Gets the bulk task update response.
        /// </summary>
        /// <returns>The <see cref="BulkTaskUpdate"/></returns>
        public static BulkTaskUpdate GetBulkTaskUpdateResponse()
        {
            return new BulkTaskUpdate
            {
                InsertedCount = 5,
                IsSuccess = true,
                ErrorMessage = string.Empty
            };
        }

        /// <summary>
        /// Gets the new role response.
        /// </summary>
        /// <returns>The <see cref="NewRole"/></returns>
        public static NewRole GetNewRoleResponse()
        {
            return new NewRole
            {
                RoleId = 4,
                IsSuccess = true,
                ErrorMessage = string.Empty
            };
        }
    }
}