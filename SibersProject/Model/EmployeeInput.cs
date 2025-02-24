namespace SibersProject.Model;

public class EmployeeInput
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Priority Priority { get; set; } = Priority.None;
    public string Customer { get; set; } = null!;
    public string Contractor { get; set; } = null!;
}
