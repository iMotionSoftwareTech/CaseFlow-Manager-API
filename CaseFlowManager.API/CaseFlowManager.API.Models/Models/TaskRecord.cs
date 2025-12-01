namespace IMotionSoftware.CaseFlowManager.API.Models.Models
{
    /// <summary>
    /// The TaskRecord
    /// </summary>
    public class TaskRecord
    {
        /// <summary>
        /// Gets or sets the total no of records.
        /// </summary>
        /// <value>
        /// The total no of records.
        /// </value>
        public int TotalNoOfRecords { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public IEnumerable<CaseTask> Tasks { get; set; } = Enumerable.Empty<CaseTask>();
    }
}