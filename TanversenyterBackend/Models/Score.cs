using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanversenyBackend.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Judge")]
        public int JudgeId { get; set; }
        public Judge? Judge { get; set; }

        [ForeignKey("Submission")]
        public int SubmissionId { get; set; }
        public Submission? Submission { get; set; }

        [Range(0, 10)]
        public int Points { get; set; }

        [MaxLength(1000)]
        public string? Comments { get; set; }
    }
}