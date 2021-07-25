using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ookgewoon.Web.Data.Entities
{
    public class CategoriesEntries
    {
        public Guid EntryId { get; set; }        

        [ForeignKey("EntryId")]
        public Entry Entry { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
