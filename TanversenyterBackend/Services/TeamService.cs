using TanversenyBackend.Models.DTO;

namespace TanversenyBackend.Services
{
    public class TeamService : ITeamService
    {
        private readonly TanversenyContext _context;

        public TeamService(TanversenyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamGetAllDTO>> GetAll()
        {
            return await _context.Teams
                .Select(t => new TeamGetAllDTO
                {
                    Id = t.Id,
                    CompanyName = t.CompanyName,
                    SchoolName = t.SchoolName,
                    SchoolAddress = t.SchoolAddress,
                    Industry = t.Industry,
                    Email = t.Email,
                    AvailableInHungarian = t.AvailableInHungarian,
                    AvailableInEnglish = t.AvailableInEnglish,
                    AvailableInGerman = t.AvailableInGerman,
                    CompetitionId = t.CompetitionId,
                    IsPaid = t.IsPaid,
                })
                .ToListAsync();
        }

    }
}