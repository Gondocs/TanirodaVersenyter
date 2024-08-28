using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanversenyBackend.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; }
    }

}