using CaseFlowManager.API.Service.Services;
using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowDataPackage.Interfaces;
using IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration;
using Moq;
using System.Threading.Tasks;

namespace IMotionSoftware.CaseFlowManager.Api.Test
{
    /// <summary>
    /// The TaskServiceUnitTests
    /// </summary>
    [TestClass]
    public class TaskServiceUnitTests
    {
        /// <summary>
        /// The task repo mock
        /// </summary>
        private Mock<ITaskRepo> _taskRepoMock;

        /// <summary>
        /// The task service
        /// </summary>
        private TaskService _taskService;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _taskRepoMock = new Mock<ITaskRepo>();
            _taskService = new TaskService(_taskRepoMock.Object);
        }

        /// <summary>
        /// Creates the task is successfull test.
        /// </summary>
        [TestMethod, TestCategory("UnitTest")]
        public async Task CreateTask_IsSuccessfull_Test()
        {
            // Arrange
            var request = UnitTestData.GetCreateTaskRequest();
            this._taskRepoMock
                .Setup(repo => repo.CreateTaskAsync(It.IsAny<CreateTaskParameter>()))
                .ReturnsAsync(1);

            // Act
            var result = await this._taskService.CreateTaskAsync(request);

            // Assert
            Assert.AreEqual(1, result);
            this._taskRepoMock.Verify(repo => repo.CreateTaskAsync(It.IsAny<CreateTaskParameter>()), Times.Once);
        }

        /// <summary>
        /// Gets all statuses asynchronous is successfull test.
        /// </summary>
        [TestMethod, TestCategory("UnitTest")]
        public async Task GetAllStatusesAsync_IsSuccessfull_Test()
        {
            // Arrange
            var roles = UnitTestData.GetAllStatusDto();
            this._taskRepoMock
                .Setup(repo => repo.GetAllStatusesAsync()).ReturnsAsync(roles);

            // Act
            var result = await this._taskService.GetAllStatusesAsync();

            // Assert
            Assert.IsNotNull(result);
            this._taskRepoMock.Verify(repo => repo.GetAllStatusesAsync(), Times.Once);
        }

        /// <summary>
        /// Gets all tasks asynchronous is successfull test.
        /// </summary>
        [TestMethod, TestCategory("UnitTest")]
        public async Task GetAllTasksAsync_IsSuccessfull_Test()
        {
            // Arrange
            var response = new
            {
                TotalNoOfRecords = 2,
                Tasks = UnitTestData.GetAllTasks()
            };
            this._taskRepoMock
                .Setup(repo => repo.GetAllTasksAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((response.TotalNoOfRecords, response.Tasks));

            // Act
            var result = await this._taskService.GetAllTasksAsync(1, 10);

            // Assert
            Assert.IsNotNull(result);
            this._taskRepoMock.Verify(repo => repo.GetAllTasksAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        /// <summary>
        /// Gets the task with statuses by identifier asynchronous is successfull test.
        /// </summary>
        [TestMethod, TestCategory("UnitTest")]
        public async Task GetTaskWithStatusesByIdAsync_IsSuccessfull_Test()
        {
            // Arrange
            var response = UnitTestData.GetTaskStatusDtos();
            this._taskRepoMock
                .Setup(repo => repo.GetTaskWithStatusesByIdAsync(It.IsAny<int>())).ReturnsAsync(response);

            // Act
            var result = await this._taskService.GetTaskWithStatusesByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            this._taskRepoMock.Verify(repo => repo.GetTaskWithStatusesByIdAsync(It.IsAny<int>()), Times.Once);
        }

        /// <summary>
        /// Logs the task status asynchronous is successfull test.
        /// </summary>
        [TestMethod, TestCategory("UnitTest")]
        public async Task LogTaskStatusAsync_IsSuccessfull_Test()
        {
            // Arrange
            var request = UnitTestData.GetLogStatusRequest();
            this._taskRepoMock
                .Setup(repo => repo.LogTaskStatusAsync(It.IsAny<LogTaskStatusParameter>()))
                .ReturnsAsync(1);

            // Act
            var result = await this._taskService.LogTaskStatusAsync(request);

            // Assert
            Assert.AreEqual(1, result);
            this._taskRepoMock.Verify(repo => repo.LogTaskStatusAsync(It.IsAny<LogTaskStatusParameter>()), Times.Once);
        }
    }
}