using System;
using System.ComponentModel.DataAnnotations;

namespace LessonTrackingSystem.DataAccess.Entities
{
    public class Student : BaseEntity
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name cannot be left blank.")]
        [StringLength(50, ErrorMessage = "The name can be up to 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname cannot be left blank.")]
        [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number must be greater than zero.")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Gender must be selected.")]
        public string Gender { get; set; }
    }
}
