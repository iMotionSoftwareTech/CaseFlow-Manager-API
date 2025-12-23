namespace IMotionSoftware.CaseFlowManager.API.Models.Models
{
    /// <summary>
    /// The NewTask
    /// </summary>
    /// <seealso cref="IMotionSoftware.CaseFlowManager.API.Models.Models.BaseResponse" />
    public class NewTask : BaseResponse
    {
        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        public int TaskId { get; set; }
    }
}