using TanversenyBackend.Models.DTO;

namespace TanversenyBackend.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamGetAllDTO>> GetAll();
    }
}