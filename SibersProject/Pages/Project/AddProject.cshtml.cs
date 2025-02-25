using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Domain.Repository;
using SibersProject.Model;
using Domain.DTO.Project;
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

        

        public void OnGet()
        {
        }
    }
}
