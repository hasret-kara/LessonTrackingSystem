
namespace LessonTrackingSystem.DataAccess.Models
{
    public class StudentSearchInput
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}