using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessonTrackingSystem.DataAccess.Entities
{
    [Table("Lessons")]
    public class Lesson
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Code { get; set; }

        [Required]
        public int Akts { get; set; }
    }
}