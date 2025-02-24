using Domain.Repository;
using Services;
using SibersProject.Model;


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

        if (!_repository.Check(obj.Email))
        {
            _repository.Add(obj);
        }
        
    }
}
