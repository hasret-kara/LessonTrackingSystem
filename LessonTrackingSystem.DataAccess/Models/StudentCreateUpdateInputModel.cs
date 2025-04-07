using System.ComponentModel.DataAnnotations;

namespace LessonTrackingSystem.DataAccess.Models
{
    public class StudentCreateUpdateInputModel

    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Surname { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }


        public int Number { get; set; }

        [StringLength(50)]
        public string? Gender { get; set; }
    }
}
