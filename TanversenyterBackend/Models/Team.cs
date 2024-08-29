public class Team
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
    public Competition? Competition { get; set; }

    // Kapcsolat a User-rel (opcionális)
    public ICollection<User>? Users { get; set; }

    // A TeamMember maradhat névlista kezelésére
    public ICollection<TeamMember>? Members { get; set; }
}
