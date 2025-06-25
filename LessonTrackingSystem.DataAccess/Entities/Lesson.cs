using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessonTrackingSystem.DataAccess.Entities
{
    [Table("Lessons")]
    public class Lesson : BaseEntity // ISoftDelete değil, artık BaseEntity'den geliyor
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Lesson name is required.")]
        [StringLength(50, ErrorMessage = "Lesson name must be at most 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Code must be at most 50 characters.")]
        public string? Code { get; set; }

        [Required(ErrorMessage = "AKTS must be set.")]
        public int Akts { get; set; }
    }
}
