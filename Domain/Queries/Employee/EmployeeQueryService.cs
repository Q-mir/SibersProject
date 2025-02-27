using Domain.DTO.Employee;
using Domain.Queries;
using Domain.Repository;
using Services;

public class EmployeeQueryService : IQueryService<EmployeeSearchDTO, IEnumerable<EmployeeDTO>>
{
    private readonly IRepository<EmployeeDTO> _repository;

    public EmployeeQueryService(IRepository<EmployeeDTO> repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        _repository = repository;
    }

    public IEnumerable<EmployeeDTO> Execute(EmployeeSearchDTO query)
    {
        var employees = _repository.GetAll().AsQueryable();

        if (!string.IsNullOrEmpty(query.SearchString))
        {
            employees = employees.Where(e =>
                e.FirstName.Contains(query.SearchString) ||
                e.LastName.Contains(query.SearchString)  ||
                e.Email.Contains(query.SearchString));
        }

        return employees.Select(e => new EmployeeDTO
        {
            EmployeeId = e.EmployeeId,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email
        }).ToList();
    }
}