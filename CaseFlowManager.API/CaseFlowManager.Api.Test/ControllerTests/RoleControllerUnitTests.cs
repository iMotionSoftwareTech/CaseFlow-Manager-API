using CaseFlowManager.API.Controllers;
using CaseFlowManager.API.Service.Interfaces;
using IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
using IMotionSoftware.CaseFlowManager.API.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace IMotionSoftware.CaseFlowManager.Api.Test;

/// <summary>
/// The RoleControllerUnitTests
/// </summary>
[TestClass]
public class RoleControllerUnitTests
{
    /// <summary>
    /// The logger mock
    /// </summary>
    private Mock<ILogger<RoleController>> _loggerMock;

    /// <summary>
    /// The role service mock
    /// </summary>
    private Mock<IRoleService> _roleServiceMock;

    /// <summary>
    /// The role controller
    /// </summary>
    private RoleController _roleController;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<RoleController>>();
        _roleServiceMock = new Mock<IRoleService>();
        _roleController = new RoleController(_loggerMock.Object, _roleServiceMock.Object);
    }

    /// <summary>
    /// Creates the caseworker role a synchronize returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateCaseworkerRoleASync_ReturnsOk_Test()
    {
        // Arrange
        var apiResponse = UnitTestData.GetNewRoleResponse();
        var parameter = UnitTestData.GetCreateRoleRequest();
        this._roleServiceMock
            .Setup(service => service.CreateRoleAsync(It.IsAny<CreateRoleRequest>())).ReturnsAsync(apiResponse);

        // Act
        var result = await this._roleController.CreateCaseworkerRoleAsync(parameter);

        // Assert
        Assert.IsTrue(result.Result is ObjectResult);
        this._roleServiceMock.Verify(service => service.CreateRoleAsync(It.IsAny<CreateRoleRequest>()), Times.Once);
    }

    /// <summary>
    /// Creates the caseworker role asynchronous returns bad request test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateCaseworkerRoleAsync_ReturnsBadRequest_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetCreateRoleRequest();
        this._roleServiceMock
            .Setup(service => service.CreateRoleAsync(It.IsAny<CreateRoleRequest>()))
            .ReturnsAsync(new NewRole());

        // Act
        var result = await this._roleController.CreateCaseworkerRoleAsync(parameter);

        // Assert
        Assert.IsTrue(result.Result is BadRequestObjectResult);
        this._roleServiceMock.Verify(service => service.CreateRoleAsync(It.IsAny<CreateRoleRequest>()), Times.Once);
    }

    /// <summary>
    /// Creates the caseworker role a synchronize returns internal server error on exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateCaseworkerRoleASync_ReturnsInternalServerError_OnException_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetCreateRoleRequest();
        this._roleServiceMock
            .Setup(service => service.CreateRoleAsync(It.IsAny<CreateRoleRequest>()))
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._roleController.CreateCaseworkerRoleAsync(parameter);

        // Assert
        var statusCodeResult = result.Result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._roleServiceMock.Verify(service => service.CreateRoleAsync(It.IsAny<CreateRoleRequest>()), Times.Once);
    }

    /// <summary>
    /// Gets all caseworker roles asynchronous returns ok test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetAllCaseworkerRolesAsync_ReturnsOk_Test()
    {
        // Arrange
        var roles = UnitTestData.GetAllCaseworkerRoles();
        this._roleServiceMock
            .Setup(service => service.GetAllRolesAsync()).ReturnsAsync(roles);

        // Act
        var result = await this._roleController.GetAllCaseworkerRolesAsync();

        // Assert
        Assert.IsTrue(result.Result is OkObjectResult);
        this._roleServiceMock.Verify(service => service.GetAllRolesAsync(), Times.Once);
    }

    /// <summary>
    /// Gets all caseworker roles asynchronous returns internal server error on exception test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetAllCaseworkerRolesAsync_ReturnsInternalServerError_OnException_Test()
    {
        // Arrange
        this._roleServiceMock
            .Setup(service => service.GetAllRolesAsync())
            .ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await this._roleController.GetAllCaseworkerRolesAsync();

        // Assert
        var statusCodeResult = result.Result as ObjectResult;
        Assert.IsNotNull(statusCodeResult);
        Assert.AreEqual(500, statusCodeResult.StatusCode);
        this._roleServiceMock.Verify(service => service.GetAllRolesAsync(), Times.Once);
    }
}