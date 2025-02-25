using Domain.DTO.Employee;
using Domain.Repository;
using Services;


namespace Domain.Queries.Employee
{
    public class GetByIdEmployeesQueryService : IQueryService<EmployeeSearchByIdDTO, EmployeeDTO>
    {
        private readonly IRepository<EmployeeDTO> _repository;

        public GetByIdEmployeesQueryService(IRepository<EmployeeDTO> repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public EmployeeDTO Execute(EmployeeSearchByIdDTO obj)
        
        {
            return _repository.GetById(obj.Id);
        }
    }
}
