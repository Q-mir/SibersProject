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
    public class EmployeeUpdateCommand : ICommandService<EmployeeUpdateDTO>
    {
        private readonly IRepository<EmployeeDTO> _repository;

        public EmployeeUpdateCommand(IRepository<EmployeeDTO> repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public void Execute(EmployeeUpdateDTO obj)
        {
            EmployeeDTO employeeUpdate = new()
            {
                EmployeeId = obj.EmployeeId,
                Email = obj.Email,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                MiddleName = obj.MiddleName
            };
            _repository.Update(employeeUpdate);
        }
    }
}
