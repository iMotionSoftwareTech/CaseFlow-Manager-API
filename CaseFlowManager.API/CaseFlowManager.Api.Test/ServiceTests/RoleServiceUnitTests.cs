using CaseFlowManager.API.Service.Services;
using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowDataPackage.Interfaces;
using IMotionSoftware.CaseFlowManager.Api.Test.TestConfiguration;
using IMotionSoftware.CaseFlowManager.API.Models.Models;
using Moq;

namespace IMotionSoftware.CaseFlowManager.Api.Test;

/// <summary>
/// The RoleServiceUnitTests
/// </summary>
[TestClass]
public class RoleServiceUnitTests
{
    /// <summary>
    /// The role repo mock
    /// </summary>
    private Mock<IRoleRepo> _roleRepoMock;

    /// <summary>
    /// The role service
    /// </summary>
    private RoleService _roleService;

    /// <summary>
    /// Setups this instance.
    /// </summary>
    [TestInitialize]
    public void Setup() 
    { 
        _roleRepoMock = new Mock<IRoleRepo>();
        _roleService = new RoleService(_roleRepoMock.Object);
    }

    /// <summary>
    /// Creates the role is successfull test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task CreateRole_IsSuccessfull_Test()
    {
        // Arrange
        var parameter = UnitTestData.GetCreateRoleRequest();
        var response = UnitTestData.GetNewRoleResult();
        var apiResponse = UnitTestData.GetNewRoleResponse();
        this._roleRepoMock
            .Setup(repo => repo.CreateRoleAsync(It.IsAny<CreateRoleParameter>())).ReturnsAsync(response);

        // Act
        var result = await this._roleService.CreateRoleAsync(parameter);

        // Assert
        Assert.AreEqual(apiResponse.IsSuccess, result.IsSuccess);
        this._roleRepoMock.Verify(repo => repo.CreateRoleAsync(It.IsAny<CreateRoleParameter>()), Times.Once);
    }

    /// <summary>
    /// Gets the roles asynchronous is successfull test.
    /// </summary>
    [TestMethod, TestCategory("UnitTest")]
    public async Task GetRolesAsync_IsSuccessfull_Test()
    {
        // Arrange
        var roles = UnitTestData.GetAllRoles();
        this._roleRepoMock
            .Setup(repo => repo.GetAllRolesAsync()).ReturnsAsync(roles);

        // Act
        var result = await this._roleService.GetAllRolesAsync();

        // Assert
        Assert.IsNotNull(result);
        this._roleRepoMock.Verify(repo => repo.GetAllRolesAsync(), Times.Once);
    }
}