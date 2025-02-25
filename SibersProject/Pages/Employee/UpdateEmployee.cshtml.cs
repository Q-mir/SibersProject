using Domain.DTO.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

namespace SibersProject.Pages.Employee
{
    public class UpdateEmployeeModel : PageModel
    {
        [BindProperty]
        public EmployeeUpdateDTO EmployeeInput { get; set; } = null!;

        private readonly IQueryService<EmployeeSearchByIdDTO, EmployeeDTO> _query;
        private readonly ICommandService<EmployeeUpdateDTO> _command;

        public UpdateEmployeeModel(IQueryService<EmployeeSearchByIdDTO, EmployeeDTO> query, ICommandService<EmployeeUpdateDTO> command)
        {
            ArgumentNullException.ThrowIfNull(query);
            ArgumentNullException.ThrowIfNull(command);
            _query = query;
            _command = command;
        }

        public void OnGet(int id)
        {
            EmployeeDTO employeeUpdate = _query.Execute(new EmployeeSearchByIdDTO() { Id = id });
            if (employeeUpdate != null)
            {
                EmployeeInput = new()
                {
                    EmployeeId = employeeUpdate.EmployeeId,
                    Email = employeeUpdate.Email,
                    FirstName = employeeUpdate.FirstName,
                    LastName = employeeUpdate.LastName,
                    MiddleName = employeeUpdate.MiddleName
                };
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            EmployeeUpdateDTO employeeUpdate = new EmployeeUpdateDTO()
            {
                EmployeeId = EmployeeInput.EmployeeId,
                Email = EmployeeInput.Email,
                FirstName = EmployeeInput.FirstName,
                LastName = EmployeeInput.LastName,
                MiddleName = EmployeeInput.MiddleName
            };
            _command.Execute(employeeUpdate);
            return RedirectToPage("EmployeesShow");
        }
    }
}
