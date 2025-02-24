using Domain.DTO;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using SibersProject.Model;

namespace SibersProject.Pages.Employee
{
    public class AddEmployeeModel : PageModel
    {
        [BindProperty]
        public EmployeeDTO EmployeeInput { get; set; }
        private ICommandService<EmployeeDTO> _save;
        private readonly IRepository<ProjectDTO> _projectRepository;
        private readonly IRepository<EmployeeDTO> _employeeRepository;
        public AddEmployeeModel(ICommandService<EmployeeDTO> save,
                                IRepository<ProjectDTO> projectRepository,
                                IRepository<EmployeeDTO> employeeRepository)
        {
            ArgumentNullException.ThrowIfNull(save);
            _save = save;
            ArgumentNullException.ThrowIfNull(projectRepository);
            _projectRepository = projectRepository;
            ArgumentNullException.ThrowIfNull(employeeRepository);
            _employeeRepository = employeeRepository;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _save.Execute(new EmployeeDTO()
                {
                });
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
