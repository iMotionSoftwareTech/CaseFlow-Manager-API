namespace IMotionSoftware.CaseFlowManager.API.Models.Models
{
    /// <summary>
    /// The BulkTaskUpdate
    /// </summary>
    /// <seealso cref="IMotionSoftware.CaseFlowManager.API.Models.Models.BaseResponse" />
    public class BulkTaskUpdate : BaseResponse
    {
        /// <summary>
        /// Gets or sets the inserted count.
        /// </summary>
        /// <value>
        /// The inserted count.
        /// </value>
        public int InsertedCount { get; set; }
    }
}