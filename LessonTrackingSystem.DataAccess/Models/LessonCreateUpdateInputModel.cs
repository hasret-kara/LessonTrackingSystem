using System.ComponentModel.DataAnnotations;

namespace LessonTrackingSystem.DataAccess.Models
{
    public class LessonCreateUpdateInputModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Code { get; set; }

        [Required]
        public int Akts { get; set; }
    }
}