using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Domain.DTO;

public class ProjectDTO
{
    public int ProjectId { get; set; }

    [Display(Name = "Название проекта:")]
    [MinLength(3, ErrorMessage = "Название мин 3 символа")]
    [MaxLength(255, ErrorMessage = "Название макс 255 символов")]
    public string ProjectName { get; set; }

    [Display(Name = "Компания - заказчик:")]
    [MinLength(3, ErrorMessage = "Длинна мин 3 символа")]
    [MaxLength(255, ErrorMessage = "Длинна макс 255 символов")]
    public string CustomerCompany { get; set; }

    [Display(Name = "Компания - исполнитель:")]
    [MinLength(3, ErrorMessage = "Длинна мин 3 символа")]
    [MaxLength(255, ErrorMessage = "Длинна макс 255 символов")]
    public string ExecutorCompany { get; set; }

    [Display(Name = "Дата начала проекта:")]
    public DateTime StartDate { get; set; }

    [Display(Name = "Дата окончания проекта:")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Приоритет (1-5):")]
    [Range(1, 5, ErrorMessage = "Приоритет от 1 до 5")]
    public int Priority { get; set; }


    public int ProjectManagerId { get; set; }

}
