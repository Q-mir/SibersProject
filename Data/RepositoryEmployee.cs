using Domain.DTO.Employee;
using Domain.Repository;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RepositoryEmployee : IRepository<EmployeeDTO>
    {
        private readonly Connection _connection;

        public RepositoryEmployee(Connection connection)
        {
            ArgumentNullException.ThrowIfNull(connection);
            _connection = connection;
        }

        public void Add(EmployeeDTO obj)
        {
            Employee employee = new Employee()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                MiddleName = obj.MiddleName,
                Email = obj.Email
            };
            _connection.Add(employee);
            _connection.SaveChanges();
            
        }

        public bool Check(string email) => _connection.Employees.Any(e => e.Email.ToLower() == email.ToLower());
        public List<EmployeeDTO> GetAll() => _connection.Employees.Select(e => Convert(e)).ToList();

        private static EmployeeDTO? Convert(Employee obj) => obj == null ? null : 
            new EmployeeDTO()
            {
                EmployeeId = obj.EmployeeId,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                MiddleName = obj.MiddleName,
                Email = obj.Email
            };
        public EmployeeDTO GetById(int id)
        {
            var employee = _connection.Employees.FirstOrDefault(e => e.EmployeeId == id);
            return employee == null ? null : Convert(employee);
        }

        public bool Update(EmployeeDTO obj)
        {
            Employee employeeUpdate = new()
            {
                EmployeeId = obj.EmployeeId,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                MiddleName = obj.MiddleName,
                Email = obj.Email
            };
            _connection.Employees.Update(employeeUpdate);
            return _connection.SaveChanges() > 0;
        }

        public void Delete(EmployeeDTO obj)
        {
            Employee employeeDelete = _connection.Employees.FirstOrDefault(e => e.EmployeeId == obj.EmployeeId);
            if(employeeDelete != null)
            {
                _connection.Delete(employeeDelete);
            }
        }
    }
}
