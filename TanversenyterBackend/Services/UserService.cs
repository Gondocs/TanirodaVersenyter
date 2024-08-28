namespace TanversenyBackend.Services
{
    public class UserService : IUserService
    {
        private readonly TanversenyContext _context;

        public UserService(TanversenyContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserID == id) ?? throw new Exception("User not found");
        }


    }
}