using Domain.DTO.Employee;
using Domain.DTO.Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace SibersProject.Pages.Project
{

    public class DeleteProjectModel : PageModel
    {
        private readonly ICommandService<ProjectDeleteDTO> _command;
        private readonly IQueryService<ProjectSearchByIdDTO, ProjectDTO> _query;

        public DeleteProjectModel(ICommandService<ProjectDeleteDTO> command, IQueryService<ProjectSearchByIdDTO, ProjectDTO> query)
        {
            ArgumentNullException.ThrowIfNull(command);
            ArgumentNullException.ThrowIfNull(query);
            _command = command;
            _query = query;
        }


        public ProjectDTO ProjectDelete { get; set; }
        public void OnGet(int id)
        {
            ProjectDelete = _query.Execute(new ProjectSearchByIdDTO() { Id = id }); 
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _command.Execute(new ProjectDeleteDTO() { ProjectId = id });

            return RedirectToPage("/ProjectsShow");
        }
    }
}
