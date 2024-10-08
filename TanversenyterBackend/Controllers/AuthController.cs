using System.Security.Cryptography;
using TanversenyBackend.Data;

namespace TanversenyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TanversenyContext _context;

        public AuthController(TanversenyContext context)
        {
            _context = context;
        }

        private string GenerateJwtToken(User user)
        {
            var key = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.GivenName, user.Firstname),
                        new Claim(ClaimTypes.Surname, user.Lastname),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModelDTO model)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == model.Email))
                {
                    return BadRequest("Email already in use.");
                }

                if (!Enum.TryParse<UserRole>(model.Role, true, out var userRole))
                {
                    return BadRequest("Invalid role.");
                }

                string hashedPassword = HashPassword(model.Password);

                User user = new User
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Email = model.Email,
                    PasswordHash = hashedPassword,
                    Role = userRole.ToString(),
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok("Registration successful.");
            }

            return BadRequest("Invalid registration data.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModelDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.Email == model.Email);

                if (user == null || !VerifyPassword(model.Password, user.PasswordHash))
                {
                    return Unauthorized("Invalid email or password.");
                }

                var Token = GenerateJwtToken(user);

                return Ok(Token);
            }

            return BadRequest("Invalid login data.");
        }

        /*[HttpPost("changepassword")]
        public IActionResult ChangePassword([FromBody] PasswordChange pc)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User.SingleOrDefault(u => u.UserID == pc.UserID);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                if (!VerifyPassword(pc.OldPassword, user.PasswordHash))
                {
                    return Unauthorized("Invalid old password.");
                }

                string newPasswordHash = HashPassword(pc.NewPassword);

                user.PasswordHash = newPasswordHash;

                _context.SaveChanges();

                return Ok("Password changed successfully.");
            }

            return BadRequest("Invalid input data.");
        }

        [HttpPut("ChangeUserRole")]
        public IActionResult ChangeUserRole([FromBody] UserRoleChange urc, string requestUserId)
        {
            if (ModelState.IsValid)
            {
                var requestingUser = _context.User.SingleOrDefault(u => u.UserID == Convert.ToInt32(requestUserId));

                if (requestingUser == null)
                {
                    return NotFound("Requesting user not found.");
                }

                if (requestingUser.Role != "admin")
                {
                    return Unauthorized("You do not have permission to change roles.");
                }

                if (urc.Role != "admin" && urc.Role != "user")
                {
                    return BadRequest("Invalid role. Role can only be 'admin' or 'user'.");
                }

                var user = _context.User.SingleOrDefault(u => u.UserID == urc.UserID);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                user.Role = urc.Role;

                _context.SaveChanges();

                return Ok("Role changed successfully.");
            }

            return BadRequest("Invalid input data.");
        }


        [HttpGet("GetUserRole")]
        public IActionResult GetUserRole(string requestUserId)
        {
            var requestingUser = _context.User.SingleOrDefault(u => u.UserID == Convert.ToInt32(requestUserId));

            if (requestingUser == null)
            {
                return NotFound("Requesting user not found.");
            }

            return Ok(requestingUser.Role);
        }*/
    }
}
