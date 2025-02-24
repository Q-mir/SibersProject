using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.DTO;
using Services;
using Domain.Repository;
using SibersProject.Model;
namespace SibersProject.Pages
{
    public class AddProjectModel : PageModel
    {
        [BindProperty]
        public ProjectDTO ProjectInput { get; set; }
        private ICommandService<ProjectDTO> _save;
        private readonly IRepository<ProjectDTO> _projectRepository; 
        private readonly IRepository<EmployeeDTO> _employeeRepository;
        private ICollection<EmployeeDTO> _employees;
        public AddProjectModel(ICommandService<ProjectDTO> save, IRepository<ProjectDTO> projectRepository, IRepository<EmployeeDTO> employeeRepository)
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
                _save.Execute(new ProjectDTO()
                {
                    ProjectName = ProjectInput.ProjectName,
                    CustomerCompany = ProjectInput.CustomerCompany,
                    ExecutorCompany = ProjectInput.ExecutorCompany,
                    StartDate = ProjectInput.StartDate,
                    EndDate = ProjectInput.EndDate,
                    Priority = ProjectInput.Priority,
                    ProjectManagerId = 0 // TODO
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
