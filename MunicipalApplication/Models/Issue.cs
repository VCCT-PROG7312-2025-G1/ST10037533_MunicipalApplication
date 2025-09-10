using System;

namespace MunicipalApplication.Models
{
    public enum IssueCategory{
        Pothole,
        StreetlightOut,
        Lighting,
        WaterLeak,
        Other
    }
    public class Issue
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateReported { get; set; } = DateTime.Now;
        public string Location { get; set; } = string.Empty;
        public IssueCategory Category { get; set; } 
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Submitted";
    }
}
