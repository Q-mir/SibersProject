using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Employee
{
    public class EmployeeSearchDTO : IQuery
    {
        public string SearchString { get; set; }
    }
}
