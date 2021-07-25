using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;
using Ookgewoon.Web.Data.Enums;
using Ookgewoon.Web.Models.Identity;

namespace Ookgewoon.Web.Data.Entities
{
    public class Entry
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("CreatedById")]
        public ApplicationUser CreatedBy { get; set; }

        public string CreatedById { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(1500)]
        public string Brief { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Point Location { get; set; }

        public Cost Cost { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        public DateTimeOffset? Updated { get; set; }

        public DateTimeOffset? Published { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<OpeningTime> OpeningTimes { get; set; }
    }
}
