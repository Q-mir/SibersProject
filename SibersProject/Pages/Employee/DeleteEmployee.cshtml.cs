using Domain.DTO.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace SibersProject.Pages.Employee
{
    public class DeleteEmployeeModel : PageModel
    {
        private readonly ICommandService<EmployeeDeleteDTO> _command;
        private readonly IQueryService<EmployeeSearchByIdDTO, EmployeeDTO> _query;
        public DeleteEmployeeModel(ICommandService<EmployeeDeleteDTO> command, IQueryService<EmployeeSearchByIdDTO, EmployeeDTO> query)
        {
            ArgumentNullException.ThrowIfNull(command);
            ArgumentNullException.ThrowIfNull(query);
            _command = command;
            _query = query;
        }

        
        public EmployeeDTO EmployeeDelete { get; set; }
        public void OnGet(int id)
        {
            EmployeeDelete = _query.Execute(new EmployeeSearchByIdDTO() { Id = id });
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _command.Execute(new EmployeeDeleteDTO() { EmployeeId = id });


            return RedirectToPage("EmployeesShow");
        }


    }
}
