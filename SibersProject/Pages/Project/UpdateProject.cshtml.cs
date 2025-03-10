using Domain.DTO.Employee;
using Domain.DTO.Project;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace SibersProject.Pages.Project
{
    public class UpdateProjectModel : PageModel
    {
        private readonly IQueryService<ProjectSearchByIdDTO, ProjectDTO> _query;
        private readonly ICommandService<ProjectUpdateDTO> _command;
        private readonly IQueryService<All, IEnumerable<EmployeeDTO>> _getAllEmployees;

        public UpdateProjectModel(IQueryService<ProjectSearchByIdDTO,ProjectDTO> query,
                                  ICommandService<ProjectUpdateDTO> command,
                                  IQueryService<All, IEnumerable<EmployeeDTO>> getAllEmployees)
        {
            ArgumentNullException.ThrowIfNull(query);
            ArgumentNullException.ThrowIfNull(command);
            ArgumentNullException.ThrowIfNull(getAllEmployees);
            _query = query;
            _command = command;
            _getAllEmployees = getAllEmployees;
        }

        public IEnumerable<EmployeeDTO> Managers { get; set; }

        [BindProperty]
        public ProjectUpdateDTO ProjectInput { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Managers = _getAllEmployees.Execute(new All());
            ProjectDTO projectUpdate = _query.Execute(new ProjectSearchByIdDTO() { Id = id });
            if (projectUpdate != null)
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
                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult OnPost()
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