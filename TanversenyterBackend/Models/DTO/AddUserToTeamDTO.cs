namespace TanversenyBackend.Models.DTO
{
    public class AddUserToTeamDTO
{
    public int UserId { get; set; }
    
    // Team data
    public int? TeamId { get; set; } // Nullable in case we're creating a new team
    public string CompanyName { get; set; } = null!;
    public string SchoolName { get; set; } = null!;
    public string SchoolAddress { get; set; } = null!;
    public string Industry { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool AvailableInHungarian { get; set; }
    public bool AvailableInEnglish { get; set; }
    public bool AvailableInGerman { get; set; }
    public bool IsPaid { get; set; } = false;
}

}
