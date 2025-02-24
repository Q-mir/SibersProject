using Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee : IDelete
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(50)]
    public string MiddleName { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress] 
    public string Email { get; set; }

    public ICollection<Project> Projects { get; set; } = new List<Project>();

    public ICollection<Project> ManagedProjects { get; set; } = new List<Project>();
    public bool IsDelete { get; set; }
}