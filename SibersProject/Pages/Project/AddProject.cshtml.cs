using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Domain.DTO.Project;
using Domain.DTO.Employee;
namespace SibersProject.Pages
{
    public class AddProjectModel : PageModel
    {
        [BindProperty]
        public ProjectDTO ProjectInput { get; set; } = null!;
        private readonly ICommandService<ProjectDTO> _save;
        public AddProjectModel(ICommandService<ProjectDTO> save)
        {
            ArgumentNullException.ThrowIfNull(save);
            _save = save;
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
                    ProjectManagerId = 1 // TODO
                });
                return RedirectToPage("/Index");
            }
            return Page();
        }

        [BindProperty]
        public IEnumerable<EmployeeDTO> Employees { get; set; }

        public void OnGet()
        {
        }
    }
}
