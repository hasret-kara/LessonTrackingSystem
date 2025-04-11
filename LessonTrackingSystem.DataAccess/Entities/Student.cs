namespace LessonTrackingSystem.DataAccess.Entities
{
    public class Student : ISoftDelete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Number { get; set; }
        public string Gender { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
