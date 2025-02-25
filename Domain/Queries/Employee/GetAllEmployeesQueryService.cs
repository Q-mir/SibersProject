using Domain.DTO.Employee;
using Domain.Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.Employee
{
    public class GetAllEmployeesQueryService : IQueryService<All, IEnumerable<EmployeeDTO>>
    {
        private readonly IRepository<EmployeeDTO> _repository;

        public GetAllEmployeesQueryService(IRepository<EmployeeDTO> repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public IEnumerable<EmployeeDTO> Execute(All obj)
        {
            return _repository.GetAll();
        }
    }
}
