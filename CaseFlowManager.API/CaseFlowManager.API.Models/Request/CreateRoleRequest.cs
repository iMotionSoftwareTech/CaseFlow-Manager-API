using System.ComponentModel.DataAnnotations;

namespace IMotionSoftware.CaseFlowManager.API.Models.Request
{
    /// <summary>
    /// The CreateRoleRequest
    /// </summary>
    public class CreateRoleRequest
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        [Required]
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string? Description { get; set; }
    }
}