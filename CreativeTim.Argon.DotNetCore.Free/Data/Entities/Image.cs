using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ookgewoon.Web.Data.Entities
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("EntryId")]
        public Entry Entry { get; set; }

        public Guid EntryId { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; }

        [Required]
        [StringLength(4)]
        public string FileExtension { get; set; }

        public void Create(Guid entryId, string fileName)
        {
            Id = Guid.NewGuid();
            EntryId = entryId;
            Created = DateTimeOffset.UtcNow;
            FileExtension = fileName.Split(".").Last();
        }

        public string FileName() => string.Concat(EntryId, "/", Id, ".", FileExtension);
    }
}
