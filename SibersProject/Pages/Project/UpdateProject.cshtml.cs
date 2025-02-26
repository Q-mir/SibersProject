using Domain.DTO.Employee;
using Domain.DTO.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace SibersProject.Pages.Project
{
    public class UpdateProjectModel : PageModel
    {
        private readonly IQueryService<ProjectSearchByIdDTO, ProjectDTO> _query;
        private readonly ICommandService<ProjectUpdateDTO> _command;

        public UpdateProjectModel(IQueryService<ProjectSearchByIdDTO, ProjectDTO> query, ICommandService<ProjectUpdateDTO> command)
        {
            ArgumentNullException.ThrowIfNull(query);
            ArgumentNullException.ThrowIfNull(command);
            _query = query;
            _command = command;
        }
        public ProjectUpdateDTO ProjectInput { get; set; }
        public void OnGet(int id)
        {
            ProjectDTO projectUpdate = _query.Execute(new ProjectSearchByIdDTO() { Id = id });
            if(projectUpdate != null)
            {
                ProjectInput = new()
                {
                    ProjectId = projectUpdate.ProjectId,
                    CustomerCompany = projectUpdate.CustomerCompany,
                    EndDate = projectUpdate.EndDate,
                    StartDate = projectUpdate.StartDate,
                    ExecutorCompany = projectUpdate.ExecutorCompany,
                    Priority = projectUpdate.Priority,
                    ProjectManagerId = projectUpdate.ProjectManagerId,
                    ProjectName = projectUpdate.ProjectName
                };
            }
        }

        public IActionResult Onpost()
        {
            if (!ModelState.IsValid) return Page();

            ProjectUpdateDTO projectUpdate = new ProjectUpdateDTO()
            {
                ProjectId = ProjectInput.ProjectId,
                CustomerCompany = ProjectInput.CustomerCompany,
                EndDate = ProjectInput.EndDate,
                StartDate = ProjectInput.StartDate,
                ExecutorCompany = ProjectInput.ExecutorCompany,
                Priority = ProjectInput.Priority,
                ProjectManagerId = ProjectInput.ProjectManagerId,
                ProjectName = ProjectInput.ProjectName
            };
            _command.Execute(projectUpdate);
            return RedirectToPage("ProjectsShow");


        }
    }
}
