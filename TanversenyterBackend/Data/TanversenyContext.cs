namespace TanversenyBackend.Data
{
    public class TanversenyContext : DbContext
    {
        public TanversenyContext(DbContextOptions<TanversenyContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<JudgeScore> JudgeScores { get; set; }
        public DbSet<CompetitionOrganizer> CompetitionOrganizers { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
