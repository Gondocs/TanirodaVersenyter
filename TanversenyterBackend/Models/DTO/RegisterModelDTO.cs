namespace TanversenyBackend.Models
{
    public enum UserRole
    {
        Admin,
        Organizer,
        Judge,
        Team,
    }

    public class RegisterModelDTO
    {
        [Required(ErrorMessage = "Lastname is required")]
        public required string Lastname { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public required string Firstname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }

        public required string Role { get; set; }
    }
}
