using System;
using System.ComponentModel.DataAnnotations;

namespace Ookgewoon.Web.Data.Entities
{
    public class OpeningTime
    {
        [Key]
        public Guid Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public bool IsOpen { get; set; }

        [DataType(DataType.Time)]
        public DateTime OpenTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime CloseTime { get; set; }
    }
}
