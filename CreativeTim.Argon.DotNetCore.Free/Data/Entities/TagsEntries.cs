using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ookgewoon.Web.Data.Entities
{
    public class TagsEntries
    {
        public Guid EntryId { get; set; }        

        [ForeignKey("EntryId")]
        public Entry Entry { get; set; }

        public Guid TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
