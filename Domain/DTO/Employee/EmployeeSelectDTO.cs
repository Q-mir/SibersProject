using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Employee
{
    public class EmployeeSelectDTO
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = null!;
    }
}
