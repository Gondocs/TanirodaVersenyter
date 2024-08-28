using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanversenyBackend.Models
{
    public class JudgeScore
    {
        public int Id { get; set; }
        public int JudgeId { get; set; }
        public User? Judge { get; set; }

        public int SubmissionId { get; set; }
        public Submission? Submission { get; set; }

        public required int Score { get; set; }
        public string? Comment { get; set; }
    }

}