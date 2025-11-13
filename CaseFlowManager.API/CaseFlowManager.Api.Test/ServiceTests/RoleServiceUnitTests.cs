using CaseFlowManager.API.Service.Services;
using IMotionSoftware.CaseFlowDataPackage.DomainObjects.ParameterObjects;
using IMotionSoftware.CaseFlowDataPackage.Interfaces;
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
        var parameter = TestConfiguration.UnitTestData.GetCreateRoleParameter();
        this._roleRepoMock
            .Setup(repo => repo.CreateRoleAsync(It.IsAny<CreateRoleParameter>()));

        // Act
        await this._roleService.CreateRoleAsync(parameter);

        // Assert
        this._roleRepoMock.Verify(repo => repo.CreateRoleAsync(It.IsAny<CreateRoleParameter>()), Times.Once);
    }
}