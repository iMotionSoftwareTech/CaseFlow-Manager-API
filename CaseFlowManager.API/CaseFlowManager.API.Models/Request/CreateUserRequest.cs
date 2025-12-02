using System.ComponentModel.DataAnnotations;

namespace IMotionSoftware.CaseFlowManager.API.Models.Request
{
    /// <summary>
    /// The CreateUserRequest
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// Gets or sets the caseworker role identifier.
        /// </summary>
        /// <value>
        /// The caseworker role identifier.
        /// </value>
        [Required]
        public int CaseworkerRoleId { get; set; }

        /// <summary>
        /// Gets or sets the forename.
        /// </summary>
        /// <value>
        /// The forename.
        /// </value>
        [Required]
        public string Forename { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        /// <value>
        /// The password salt.
        /// </value>
        [Required]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        [Required]
        public DateTime CreatedDateTime { get; set; }
    }
}