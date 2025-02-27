using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;
using Domain.DTO.Project;
using Domain.DTO.Employee;
using Domain.Queries;
using System.Collections.Generic;
using System.Linq;

namespace SibersProject.Pages
{
    public class AddProjectModel : PageModel
    {
        [BindProperty]
        public ProjectDTO ProjectInput { get; set; } = null!;

        private readonly ICommandService<ProjectDTO> _save;
        private readonly IQueryService<EmployeeSearchDTO, IEnumerable<EmployeeDTO>> _employeeQuery;

        public AddProjectModel(
            ICommandService<ProjectDTO> save,
            IQueryService<EmployeeSearchDTO, IEnumerable<EmployeeDTO>> employeeQuery)
        {
            ArgumentNullException.ThrowIfNull(save);
            ArgumentNullException.ThrowIfNull(employeeQuery);
            _save = save;
            _employeeQuery = employeeQuery;
        }

        [BindProperty]
        public IEnumerable<SelectListItem> SelectEmloyees { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            var employees = GetAllEmployees();
            SelectEmloyees = employees.Select(e => new SelectListItem
            {
                Value = e.EmployeeId.ToString(),
                Text = $"{e.FirstName} {e.LastName}"
            }).ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _save.Execute(new ProjectDTO()
                {
                    ProjectName = ProjectInput.ProjectName,
                    CustomerCompany = ProjectInput.CustomerCompany,
                    ExecutorCompany = ProjectInput.ExecutorCompany,
                    StartDate = ProjectInput.StartDate,
                    EndDate = ProjectInput.EndDate,
                    Priority = ProjectInput.Priority,
                    ProjectManagerId = ProjectInput.ProjectManagerId
                });
                return RedirectToPage("/Index");
            }

            OnGet();
            return Page();
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _employeeQuery.Execute(new EmployeeSearchDTO { SearchString = "" });
        }

       
    }
}