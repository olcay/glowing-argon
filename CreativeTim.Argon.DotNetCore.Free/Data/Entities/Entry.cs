using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;
using Ookgewoon.Web.Data.Enums;

namespace Ookgewoon.Web.Data.Entities
{
    public class Entry
    {
        [Key]
        public Guid Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Brief { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Point Location { get; set; }

        public Cost Cost { get; set; }

        public ICollection<OpeningTime> OpeningTimes { get; set; }
    }
}
