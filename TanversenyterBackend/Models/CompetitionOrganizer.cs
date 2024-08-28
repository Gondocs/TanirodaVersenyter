using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanversenyBackend.Models
{
    public class CompetitionOrganizer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public int CompetitionId { get; set; }
        public Competition? Competition { get; set; }
    }


}