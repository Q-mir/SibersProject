using Domain.DTO.Employee;
using Domain.Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class EmployeeDeleteCommand : ICommandService<EmployeeDeleteDTO>
    {
        private readonly IRepository<EmployeeDTO> _repository;

        public EmployeeDeleteCommand(IRepository<EmployeeDTO> repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public void Execute(EmployeeDeleteDTO obj)
        {
            _repository.Delete(obj);
        }
    }
}
