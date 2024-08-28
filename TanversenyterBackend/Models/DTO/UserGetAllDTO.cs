namespace TanversenyBackend.Models.DTO
{
    public class UserGetAllDTO
    {
        public int UserID { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }
        public required string Role { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<CompetitionOrganizer>? OrganizedCompetitions { get; set; }
        public ICollection<TeamMember>? Teams { get; set; }
    }
}
