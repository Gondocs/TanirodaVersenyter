using TanversenyBackend.Models.DTO;
using TanversenyBackend.Services;

namespace TanversenyBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserGetAllDTO>>> Get()
        {
            var users = await _userService.GetAllUsers();
            var adminUsers = users
                .Select(user => new UserGetAllDTO
                {
                    UserID = user.UserID,
                    Email = user.Email,
                    Firstname = user.Firstname,
                    Role = user.Role,
                    Lastname = user.Lastname,
                    CreatedAt = user.CreatedAt,
                    OrganizedCompetitions = user.OrganizedCompetitions,
                    Teams = user.Teams,
                })
                .ToList();

            return Ok(adminUsers);
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserGetAllDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            var adminUser = new UserGetAllDTO
            {
                UserID = user.UserID,
                Email = user.Email,
                Firstname = user.Firstname,
                Role = user.Role,
                Lastname = user.Lastname,
                CreatedAt = user.CreatedAt,
                OrganizedCompetitions = user.OrganizedCompetitions,
                Teams = user.Teams,
            };

            return Ok(adminUser);
        }
    }
}
