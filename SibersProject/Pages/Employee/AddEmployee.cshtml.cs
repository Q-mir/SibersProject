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
        public AddEmployeeModel(ICommandService<EmployeeDTO> save)
        {
            ArgumentNullException.ThrowIfNull(save);
            _save = save;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _save.Execute(new EmployeeDTO() 
                { 
                    FirstName = EmployeeInput.FirstName,
                    LastName = EmployeeInput.LastName,
                    MiddleName = EmployeeInput.MiddleName,
                    Email = EmployeeInput.Email
                }
                );
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
