namespace IMotionSoftware.CaseFlowManager.API.Models.Models
{
    /// <summary>
    /// The NewRole
    /// </summary>
    /// <seealso cref="IMotionSoftware.CaseFlowManager.API.Models.Models.BaseResponse" />
    public class NewRole : BaseResponse
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }
    }
}