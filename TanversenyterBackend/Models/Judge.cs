using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanversenyBackend.Models
{
    public class Judge
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Email { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Institution { get; set; }

        public ICollection<JudgeScore>? JudgeScores { get; set; } // Kapcsolat a JudgeScore táblával
    }

}