namespace TanversenyBackend.Models.DTO
{
    public class TeamGetAllDTO
    {
    public int Id { get; set; }
    public required string CompanyName { get; set; }
    public required string SchoolName { get; set; }
    public required string SchoolAddress { get; set; }
    public required string Industry { get; set; }
    public required string Email { get; set; }
    public required bool AvailableInHungarian { get; set; }
    public required bool AvailableInEnglish { get; set; }
    public required bool AvailableInGerman { get; set; }
    public int CompetitionId { get; set; }

    public bool IsPaid { get; set; } = false;

    }
}
