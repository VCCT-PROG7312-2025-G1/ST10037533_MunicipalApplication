using System;
using System.ComponentModel.DataAnnotations;

namespace MunicipalApplication.Models
{
    public class Issue
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public string AttachmentPath { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
