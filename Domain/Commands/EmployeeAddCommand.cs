using Domain.DTO.Employee;
using Domain.Repository;
using Services;


namespace Domain.Commands;

public class EmployeeAddCommand : ICommandService<EmployeeDTO>
{
    private readonly IRepository<EmployeeDTO> _repository;

    public EmployeeAddCommand(IRepository<EmployeeDTO> repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        _repository = repository;
    }

    public void Execute(EmployeeDTO obj)
    {
        if (obj.Email.Length < 3
         || obj.FirstName.Length < 3
         || obj.LastName.Length < 3)
            return;
        _repository.Add(obj);
    }
}
