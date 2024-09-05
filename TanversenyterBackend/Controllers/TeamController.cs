using TanversenyBackend.Models.DTO;
using TanversenyBackend.Services;

namespace TanversenyBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {

        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamGetAllDTO>>> GetAll()
        {
            return Ok(await _teamService.GetAll());
        }

    }
}
