public class TeamMember
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int TeamId { get; set; }
    public Team? Team { get; set; }
}
