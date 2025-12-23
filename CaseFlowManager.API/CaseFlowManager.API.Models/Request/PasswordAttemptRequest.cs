namespace IMotionSoftware.CaseFlowManager.API.Models.Request
{
    /// <summary>
    /// The PasswordAttemptRequest
    /// </summary>
    public class PasswordAttemptRequest
    {
        /// <summary>
        /// Gets or sets the caseworker identifier.
        /// </summary>
        /// <value>
        /// The caseworker identifier.
        /// </value>
        public int CaseworkerId { get; set; }

        /// <summary>
        /// Gets or sets the maximum attempts.
        /// </summary>
        /// <value>
        /// The maximum attempts.
        /// </value>
        public int MaxAttempts { get; set; }
    }
}