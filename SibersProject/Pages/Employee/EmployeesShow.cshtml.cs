using Domain.DTO.Employee;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.Reflection;

namespace SibersProject.Pages.Employee
{
    public class EmployeesShowModel : PageModel
    {
        private readonly IQueryService<All, IEnumerable<EmployeeDTO>> _employeesAll;

        public EmployeesShowModel(IQueryService<All, IEnumerable<EmployeeDTO>> employeesAll)
        {
            ArgumentNullException.ThrowIfNull(employeesAll);
            _employeesAll = employeesAll;
        }

        [BindProperty(SupportsGet = true)]
        public string SortColumn { get; set; } = nameof(EmployeeDTO.EmployeeId); 

        [BindProperty(SupportsGet = true)]
        public string SortDirection { get; set; } = "asc"; 

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } 

        public IEnumerable<EmployeeDTO> AllEmployees { get; set; }

        public void OnGet()
        {
            try
            {
                var employees = _employeesAll.Execute(new All());

                if (!string.IsNullOrEmpty(SearchString))
                {
                    employees = employees.Where(e =>
                        e.FirstName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                        e.LastName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                        e.Email.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
                }

                AllEmployees = employees.OrderBy(SortColumn, SortDirection);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Произошла ошибка при загрузке данных.");
                Console.Error.WriteLine($"Ошибка при загрузке сотрудников: {ex.Message}");
                AllEmployees = Enumerable.Empty<EmployeeDTO>();
            }
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, string columnName, string direction)
        {
            if (string.IsNullOrEmpty(columnName))
                return source;

            var property = typeof(T).GetProperty(columnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
                throw new ArgumentException($"Свойство {columnName} не найдено в типе {typeof(T).Name}");

            if (direction?.ToLower() == "desc")
                return source.OrderByDescending(x => property.GetValue(x, null));
            else
                return source.OrderBy(x => property.GetValue(x, null));
        }
    }
}