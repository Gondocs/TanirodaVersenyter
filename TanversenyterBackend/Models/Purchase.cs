using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TanversenyBackend.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int TeamId { get; set; }
        public Team? Team { get; set; }

        public int? JudgeId { get; set; }
        public User? Judge { get; set; }

        public required DateTime PurchaseDate { get; set; }
        public required decimal Amount { get; set; }
        public string? Comment { get; set; }

        public int? PointsAwarded { get; set; } // Csak bírók számára
    }
}