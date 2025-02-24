using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Project : IDelete
{
    [Key] 
    public int ProjectId { get; set; }

    [Required] 
    [MaxLength(100)] 
    public string ProjectName { get; set; }

    [Required]
    [MaxLength(100)]
    public string CustomerCompany { get; set; }

    [Required]
    [MaxLength(100)]
    public string ExecutorCompany { get; set; }

    [Required]
    [Column(TypeName = "datetime2")] 
    public DateTime StartDate { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime EndDate { get; set; }

    [Required]
    [Range(1, 5)] 
    public int Priority { get; set; }

    [ForeignKey("ProjectManager")]
    public int ProjectManagerId { get; set; }

    public Employee ProjectManager { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public bool IsDelete { get; set; }
}