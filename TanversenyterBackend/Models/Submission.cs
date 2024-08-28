using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanversenyBackend.Models
{

    public class Submission
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }

        [MaxLength(255)]
        public string? Logo { get; set; }

        [MaxLength(255)]
        public string? Flyer { get; set; }

        [MaxLength(255)]
        public string? Motto { get; set; }

        [MaxLength(255)]
        public string? Website { get; set; }

        [MaxLength(255)]
        public string? Catalogue { get; set; }

        [MaxLength(255)]
        public string? BusinessCard { get; set; }

        [MaxLength(255)]
        public string? Presentation { get; set; }

        [MaxLength(255)]
        public string? EditedStand { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }

        [MaxLength(150)]
        public string? ChatLink { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<JudgeScore>? JudgeScores { get; set; }
    }

}