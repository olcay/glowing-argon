using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ookgewoon.Web.Data.Enums;

namespace Ookgewoon.Web.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }

        public int? ParentCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public CategoryType Type { get; set; }
    }
}
