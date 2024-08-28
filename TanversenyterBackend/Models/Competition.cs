using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TanversenyBackend.Models
{
    public class Competition
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Duration { get; set; }
        public required string Status { get; set; }
        public decimal RegistrationFee { get; set; }
        public required string CoverPhotoUrl { get; set; }
        public required string ContactName { get; set; }
        public required string ContactEmail { get; set; }
        public required string ContactPhone { get; set; }
        public required DateTime RegistrationStartDate { get; set; }
        public required DateTime SubmissionDeadline { get; set; }
        public DateTime JudgingPeriodStart { get; set; }
        public DateTime JudgingPeriodEnd { get; set; }
        public string? Note { get; set; }
        public required string TemplateUrl { get; set; }
        public string? TemplateDescription { get; set; }

        public ICollection<CompetitionOrganizer>? Organizers { get; set; }
        public ICollection<Team>? Teams { get; set; }
    }

}