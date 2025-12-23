namespace IMotionSoftware.CaseFlowManager.API.Models.Models
{
    /// <summary>
    /// The NewUser
    /// </summary>
    /// <seealso cref="IMotionSoftware.CaseFlowManager.API.Models.Models.BaseResponse" />
    public class NewUser : BaseResponse
    {
        /// <summary>
        /// Gets or sets the caseworker identifier.
        /// </summary>
        /// <value>
        /// The caseworker identifier.
        /// </value>
        public int CaseworkerId { get; set; }
    }
}