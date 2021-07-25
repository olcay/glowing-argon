using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ookgewoon.Web.Models.Identity;

namespace Ookgewoon.Web.Models
{
    public class Blog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        public string Content { get; set; }

        [ForeignKey("CreatedById")]
        public ApplicationUser CreatedBy { get; set; }

        public string CreatedById { get; set; }
    }
}
