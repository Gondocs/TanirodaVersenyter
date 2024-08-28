using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanversenyBackend.Models
{
    public class Team
    {
        public int Id { get; set; }
        public required string CompanyName { get; set; }
        public required string SchoolName { get; set; }
        public required string SchoolAddress { get; set; }
        public required string Industry { get; set; }
        public required string Email { get; set; }
        public required bool AvailableInHungarian { get; set; }
        public required bool AvailableInEnglish { get; set; }
        public required bool AvailableInGerman { get; set; }
        public int CompetitionId { get; set; }

        public bool IsPaid { get; set; } = false;
        public Competition? Competition { get; set; }

        public ICollection<TeamMember>? Members { get; set; }
        public ICollection<Submission>? Submissions { get; set; }
    }

}