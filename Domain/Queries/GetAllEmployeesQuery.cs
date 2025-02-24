using Domain.Repository;
using Services;
using SibersProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public class GetAllEmployeesQuery : IQueryService<All, IEnumerable<EmployeeDTO>>
    {
        private readonly IRepository<EmployeeDTO> _repository;

        public GetAllEmployeesQuery(IRepository<EmployeeDTO> repository)
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
