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
            };

            return Ok(adminUser);
        }

        [HttpPost("addToTeam")]
        public IActionResult AddUserToTeam([FromBody] AddUserToTeamDTO dto)
        {
            // Find the user by ID
            var user = _userService.Users.FirstOrDefault(u => u.UserID == dto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            Team team;

            if (dto.TeamId.HasValue)
            {
                // Find the team by ID
                team = _userService.Teams.FirstOrDefault(t => t.Id == dto.TeamId.Value);
                if (team == null)
                {
                    return NotFound("Team not found");
                }
                // Update existing team data
                team.CompanyName = dto.CompanyName;
                team.SchoolName = dto.SchoolName;
                team.SchoolAddress = dto.SchoolAddress;
                team.Industry = dto.Industry;
                team.Email = dto.Email;
                team.AvailableInHungarian = dto.AvailableInHungarian;
                team.AvailableInEnglish = dto.AvailableInEnglish;
                team.AvailableInGerman = dto.AvailableInGerman;
                team.IsPaid = dto.IsPaid;
            }
            else
            {
                // Create a new team
                team = new Team
                {
                    CompanyName = dto.CompanyName,
                    SchoolName = dto.SchoolName,
                    SchoolAddress = dto.SchoolAddress,
                    Industry = dto.Industry,
                    Email = dto.Email,
                    AvailableInHungarian = dto.AvailableInHungarian,
                    AvailableInEnglish = dto.AvailableInEnglish,
                    AvailableInGerman = dto.AvailableInGerman,
                    IsPaid = dto.IsPaid,
                };

                _userService.Teams.Add(team);
            }

            // Associate the user with the team
            user.Team = team;

            // Save changes to the database
            _userService.SaveChanges();

            return Ok("User added to team successfully, with team data updated.");
        }
    }
}
