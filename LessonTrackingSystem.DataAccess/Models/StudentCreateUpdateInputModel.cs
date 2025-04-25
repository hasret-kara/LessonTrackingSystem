using System.ComponentModel.DataAnnotations;

public class StudentCreateUpdateInputModel
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string Surname { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Numara 0'dan büyük olmalıdır.")]
    public int Number { get; set; }

    [Required]
    [RegularExpression("Erkek|Kadın", ErrorMessage = "Cinsiyet sadece Erkek veya Kadın olmalı.")]
    public string Gender { get; set; }
}
