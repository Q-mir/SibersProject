using Domain.Repository;
using Microsoft.EntityFrameworkCore.Migrations;
using SibersProject.Model;
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
            if (!Check(obj.Email))
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
        }

        public bool Check(string email) => _connection.Employees.Any(e => e.Email.ToLower() == email.ToLower());
        public List<EmployeeDTO> GetAll() => _connection.Employees.Select(e => Convert(e)).ToList();
        
        private static EmployeeDTO? Convert(Employee obj)
                       => obj == null ? null : new EmployeeDTO()
                                               {
                                                   FirstName = obj.FirstName,
                                                   LastName = obj.LastName,
                                                   MiddleName = obj.MiddleName,
                                                   Email = obj.Email
                                               };
        public EmployeeDTO GetById(int id)
        {
            var client = _connection.Employees.FirstOrDefault(e => e.EmployeeId == id);
            return client == null ? null : Convert(client);
        }


    }
}
