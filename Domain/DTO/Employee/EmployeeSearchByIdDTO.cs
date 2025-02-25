using Service;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Employee
{
    public class EmployeeSearchByIdDTO : IQuery
    {
        public int Id { get; set; }
    }
}
