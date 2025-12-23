namespace IMotionSoftware.CaseFlowManager.API.Models.Models
{
    /// <summary>
    /// The PasswordAttempt
    /// </summary>
    /// <seealso cref="IMotionSoftware.CaseFlowManager.API.Models.Models.BaseResponse" />
    public class PasswordAttempt : BaseResponse
    {
        /// <summary>
        /// Creates new attemptcount.
        /// </summary>
        /// <value>
        /// The new attempt count.
        /// </value>
        public int NewAttemptCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [was locked].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [was locked]; otherwise, <c>false</c>.
        /// </value>
        public bool WasLocked { get; set; }
    }
}