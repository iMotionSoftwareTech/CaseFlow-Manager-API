using System.ComponentModel.DataAnnotations;

namespace IMotionSoftware.CaseFlowManager.API.Models.Request
{
    /// <summary>
    /// The CreateTaskRequest
    /// </summary>
    public class CreateTaskRequest
    {
        /// <summary>
        /// Gets or sets the caseworker identifier.
        /// </summary>
        /// <value>
        /// The caseworker identifier.
        /// </value>
        [Required]
        public int CaseworkerId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the due date time.
        /// </summary>
        /// <value>
        /// The due date time.
        /// </value>
        [Required]
        public DateTime DueDateTime { get; set; }
    }
}