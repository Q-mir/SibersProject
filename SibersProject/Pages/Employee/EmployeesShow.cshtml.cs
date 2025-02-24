using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using SibersProject.Model;

namespace SibersProject.Pages.Employee
{
    public class EmployeesShowModel : PageModel
    {
        private readonly IQueryService<All, IEnumerable<EmployeeDTO>> _employeesAll;

        public EmployeesShowModel(IQueryService<All, IEnumerable<EmployeeDTO>> employeesAll)
        {
            ArgumentNullException.ThrowIfNull(employeesAll);
            _employeesAll = employeesAll;
        }

        [BindProperty]
        public IEnumerable<EmployeeDTO> AllEmployees { get; set; }
        public void OnGet()
        {
            var list = _employeesAll.Execute(new All());
            AllEmployees = list.Select(row => new EmployeeDTO() 
                                                { 
                                                    EmployeeId = row.EmployeeId,
                                                    Email = row.Email,
                                                    FirstName = row.FirstName,
                                                    LastName = row.LastName,
                                                    MiddleName = row.MiddleName
                                                });
        }
    }
}
