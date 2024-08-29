using TanversenyBackend.Models.DTO;

namespace TanversenyBackend.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<User> AddUserToTeam(AddUserToTeamDTO dto);
        void SaveChanges();

        IEnumerable<User> Users { get; }

         List<Team> Teams { get; set; }
    }
}