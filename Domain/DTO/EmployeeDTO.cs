using System.ComponentModel.DataAnnotations;

namespace SibersProject.Model;

public class EmployeeDTO
{
    [Display(Name = "Имя:")]
    [MinLength(3, ErrorMessage = "Имя мин 3 символа")]
    [MaxLength(20, ErrorMessage = "Имя макс 20 символов")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Фамилия:")]
    [MinLength(3, ErrorMessage = "Фамилия мин 3 символа")]
    [MaxLength(20, ErrorMessage = "Фамилия макс 20 символов")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Отчество:")]
    [MinLength(3, ErrorMessage = "Отчество мин 3 символа")]
    [MaxLength(20, ErrorMessage = "Отчество макс 20 символов")]
    public string MiddleName { get; set; }

    [Display(Name = "Email:")]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;
}

