using System;
using System.ComponentModel.DataAnnotations;

namespace Ookgewoon.Web.Data.Entities
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
