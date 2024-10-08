using TanversenyBackend.Models.DTO;

namespace TanversenyBackend.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(int id);
    }
}