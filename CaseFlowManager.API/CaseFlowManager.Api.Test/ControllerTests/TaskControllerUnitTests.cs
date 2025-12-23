using Azure.Core;
using CaseFlowManager.API.Service.Interfaces;
using IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration;
using IMotionSoftware.CaseFlowManager.API.Controllers;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace IMotionSoftware.CaseFlowManager.Api.Test;

/// <summary>
/// The TaskControllerUnitTests
/// </summary>
[TestClass]
public class TaskControllerUnitTests
{
    /// <summary>
    /// The logger mock
    /// </summary>
    private Mock<ILogger<TaskController>> _loggerMock;

    /// <summary>
    /// The task service mock
    /// </summary>
    private Mock<ITaskService> _taskServiceMock;

    /// <summary>
    /// The task controller
    /// </summary>
    private TaskController _taskController;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<TaskController>>();
        _taskServiceMock = new Mock<ITaskService>();
        _taskController = new TaskController(_loggerMock.Object, _taskServiceMock.Object);
    }

    /// <summary>
    /// Creates the case task asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateCaseTaskAsync_ReturnsOk_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetCreateTaskRequest();
        var apiResponse = UnitTestData.GetNewTaskResponse();
        this._taskServiceMock
            .Setup(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()))
            .ReturnsAsync(apiResponse);

        // Act
        var result = await this._taskController.CreateCaseTaskAsync(parameter);

        // Assert
        Assert.IsTrue(result.Result is ObjectResult);
        this._taskServiceMock.Verify(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()), Times.Once);
    }

    /// <summary>
    /// Creates the case task asynchronous returns bad request test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateCaseTaskAsync_ReturnsBadRequest_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetCreateTaskRequest();
        this._taskServiceMock
            .Setup(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()))
            .ReturnsAsync(new NewTask());

        // Act
        var result = await this._taskController.CreateCaseTaskAsync(parameter);

        // Assert
        Assert.IsTrue(result.Result is BadRequestObjectResult);
        this._taskServiceMock.Verify(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()), Times.Once);
    }

    /// <summary>
    /// Creates the case task asynchronous throws exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateCaseTaskAsync_ThrowsException_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetCreateTaskRequest();
        this._taskServiceMock
            .Setup(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>())).ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._taskController.CreateCaseTaskAsync(parameter);

        // Assert
        var statusCodeResult = result.Result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._taskServiceMock.Verify(service => service.CreateTaskAsync(It.IsAny<CreateTaskRequest>()), Times.Once);
    }

    /// <summary>
    /// Gets all caseworker roles asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetAllCaseworkerRolesAsync_ReturnsOk_Test()
    {
        // Arrange
        var statuses = UnitTestData.GetAllStatuses();
        this._taskServiceMock
            .Setup(service => service.GetAllStatusesAsync()).ReturnsAsync(statuses);

        // Act
        var result = await this._taskController.GetAllStatusesAsync();

        // Assert
        Assert.IsTrue(result.Result is OkObjectResult);
        this._taskServiceMock.Verify(service => service.GetAllStatusesAsync(), Times.Once);
    }

    /// <summary>
    /// Gets all caseworker roles asynchronous returns internal server error on exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetAllCaseworkerRolesAsync_ReturnsInternalServerError_OnException_Test()
    {
        // Arrange
        this._taskServiceMock
            .Setup(service => service.GetAllStatusesAsync())
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._taskController.GetAllStatusesAsync();

        // Assert
        var statusCodeResult = result.Result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._taskServiceMock.Verify(service => service.GetAllStatusesAsync(), Times.Once);
    }

    /// <summary>
    /// Gets all case tasks asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetAllCaseTasksAsync_ReturnsOk_Test()
    {
        // Arrange
        var tasks = UnitTestData.GetAllCaseTasks();
        this._taskServiceMock
            .Setup(service => service.GetAllTasksAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(tasks);

        // Act
        var result = await this._taskController.GetAllCaseTasksAsync(1, 10);

        // Assert
        Assert.IsTrue(result.Result is OkObjectResult);
        this._taskServiceMock.Verify(service => service.GetAllTasksAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }

    /// <summary>
    /// Gets all case tasks asynchronous returns internal server error on exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetAllCaseTasksAsync_ReturnsInternalServerError_OnException_Test()
    {
        // Arrange
        this._taskServiceMock
            .Setup(service => service.GetAllTasksAsync(It.IsAny<int>(), It.IsAny<int>()))
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._taskController.GetAllCaseTasksAsync(0, 0);

        // Assert
        var statusCodeResult = result.Result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._taskServiceMock.Verify(service => service.GetAllTasksAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }

    /// <summary>
    /// Gets the task with statuses by identifier asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetTaskWithStatusesByIdAsync_ReturnsOk_Test()
    {
        // Arrange
        var tasks = UnitTestData.GetTaskStatuses();
        this._taskServiceMock
            .Setup(service => service.GetTaskWithStatusesByIdAsync(It.IsAny<int>())).ReturnsAsync(tasks);

        // Act
        var result = await this._taskController.GetTaskWithStatusesByIdAsync(1);

        // Assert
        Assert.IsTrue(result.Result is OkObjectResult);
        this._taskServiceMock.Verify(service => service.GetTaskWithStatusesByIdAsync(It.IsAny<int>()), Times.Once);
    }

    /// <summary>
    /// Gets the task with statuses by identifier asynchronous returns internal server error on exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetTaskWithStatusesByIdAsync_ReturnsInternalServerError_OnException_Test()
    {
        // Arrange
        this._taskServiceMock
            .Setup(service => service.GetTaskWithStatusesByIdAsync(It.IsAny<int>()))
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._taskController.GetTaskWithStatusesByIdAsync(1);

        // Assert
        var statusCodeResult = result.Result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._taskServiceMock.Verify(service => service.GetTaskWithStatusesByIdAsync(It.IsAny<int>()), Times.Once);
    }

    /// <summary>
    /// Logs the case task status asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task LogCaseTaskStatusAsync_ReturnsOk_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetLogStatusRequest();
        var apiResponse = UnitTestData.GetTaskUpdateResponse();
        this._taskServiceMock
            .Setup(service => service.LogTaskStatusAsync(It.IsAny<LogStatusRequest>()))
            .ReturnsAsync(apiResponse);

        // Act
        var result = await this._taskController.LogCaseTaskStatusAsync(parameter);

        // Assert
        Assert.IsTrue(result.Result is ObjectResult);
        this._taskServiceMock.Verify(service => service.LogTaskStatusAsync(It.IsAny<LogStatusRequest>()), Times.Once);
    }

    /// <summary>
    /// Logs the case task status asynchronous returns bad request test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task LogCaseTaskStatusAsync_ReturnsBadRequest_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetLogStatusRequest();
        this._taskServiceMock
            .Setup(service => service.LogTaskStatusAsync(It.IsAny<LogStatusRequest>()))
            .ReturnsAsync(new TaskUpdate());

        // Act
        var result = await this._taskController.LogCaseTaskStatusAsync(parameter);

        // Assert
        Assert.IsTrue(result.Result is BadRequestObjectResult);
        this._taskServiceMock.Verify(service => service.LogTaskStatusAsync(It.IsAny<LogStatusRequest>()), Times.Once);
    }

    /// <summary>
    /// Logs the case task status asynchronous throws exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task LogCaseTaskStatusAsync_ThrowsException_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetLogStatusRequest();
        this._taskServiceMock
            .Setup(service => service.LogTaskStatusAsync(It.IsAny<LogStatusRequest>())).ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._taskController.LogCaseTaskStatusAsync(parameter);

        // Assert
        var statusCodeResult = result.Result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._taskServiceMock.Verify(service => service.LogTaskStatusAsync(It.IsAny<LogStatusRequest>()), Times.Once);
    }

    /// <summary>
    /// Logs the bulk task statuses asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task LogBulkTaskStatusesAsync_ReturnsOk_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetTaskStatusRequests();
        var apiResponse = UnitTestData.GetBulkTaskUpdateResponse();
        this._taskServiceMock
            .Setup(service => service.LogTaskStatusesAsync(It.IsAny<IEnumerable<LogStatusRequest>>()))
            .ReturnsAsync(apiResponse);

        // Act
        var result = await this._taskController.LogBulkTaskStatusesAsync(parameter);

        // Assert
        Assert.IsTrue(result.Result is ObjectResult);
        this._taskServiceMock.Verify(service => service.LogTaskStatusesAsync(It.IsAny<IEnumerable<LogStatusRequest>>()), Times.Once);
    }

    /// <summary>
    /// Logs the bulk task statuses asynchronous returns bad request test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task LogBulkTaskStatusesAsync_ReturnsBadRequest_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetTaskStatusRequests();
        this._taskServiceMock
            .Setup(service => service.LogTaskStatusesAsync(It.IsAny<IEnumerable<LogStatusRequest>>()))
            .ReturnsAsync(new BulkTaskUpdate());

        // Act
        var result = await this._taskController.LogBulkTaskStatusesAsync(parameter);

        // Assert
        Assert.IsTrue(result.Result is BadRequestObjectResult);
        this._taskServiceMock.Verify(service => service.LogTaskStatusesAsync(It.IsAny<IEnumerable<LogStatusRequest>>()), Times.Once);
    }

    /// <summary>
    /// Logs the bulk task statuses asynchronous throws exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task LogBulkTaskStatusesAsync_ThrowsException_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetTaskStatusRequests();
        this._taskServiceMock
            .Setup(service => service.LogTaskStatusesAsync(It.IsAny<IEnumerable<LogStatusRequest>>()))
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._taskController.LogBulkTaskStatusesAsync(parameter);

        // Assert
        var statusCodeResult = result.Result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._taskServiceMock.Verify(service => service.LogTaskStatusesAsync(It.IsAny<IEnumerable<LogStatusRequest>>()), Times.Once);
    }
}