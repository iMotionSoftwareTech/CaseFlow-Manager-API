namespace IMotionSoftware.CaseFlowManager.API.Models.Models
{
    /// <summary>
    /// The TaskUpdate
    /// </summary>
    /// <seealso cref="IMotionSoftware.CaseFlowManager.API.Models.Models.BaseResponse" />
    public class TaskUpdate : BaseResponse
    {
        /// <summary>
        /// Gets or sets the task status identifier.
        /// </summary>
        /// <value>
        /// The task status identifier.
        /// </value>
        public int TaskStatusId { get; set; }
    }
}