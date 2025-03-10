using Domain.DTO.Employee;
using Domain.DTO.Project;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.Reflection;

namespace SibersProject.Pages.Project
{
    public class ProjectsShowModel : PageModel
    {
        private readonly IQueryService<All, IEnumerable<ProjectDTO>> _projectsAll;
        private readonly IQueryService<EmployeeSearchByIdDTO, EmployeeDTO> _employeeQuery;
        public ProjectsShowModel(IQueryService<All, IEnumerable<ProjectDTO>> projectsAll,
                                 IQueryService<EmployeeSearchByIdDTO, EmployeeDTO> employeeQuery)
        {
            ArgumentNullException.ThrowIfNull(projectsAll);
            ArgumentNullException.ThrowIfNull(employeeQuery);
            _projectsAll = projectsAll;
            _employeeQuery = employeeQuery;
        }

        [BindProperty]
        public IEnumerable<ProjectDTO> AllProjects { get; set; }

        

        [BindProperty(SupportsGet = true)]
        public string SortColumn { get; set; } = nameof(ProjectDTO.ProjectId); 

        [BindProperty(SupportsGet = true)]
        public string SortDirection { get; set; } = "asc";

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } 
        public void OnGet()
        {
            var projects = _projectsAll.Execute(new All());

            if (!string.IsNullOrEmpty(SearchString))
            {
                projects = projects.Where(p =>
                    p.ProjectName.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                    p.CustomerCompany.Contains(SearchString, StringComparison.OrdinalIgnoreCase) ||
                    p.ExecutorCompany.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
            }

            AllProjects = projects.OrderBy(SortColumn, SortDirection);
        }
        public string GetManagerFullName(int? managerId)
        {
            if (managerId == null)
            {
                return "�� ��������";
            }

            var manager = _employeeQuery.Execute(new EmployeeSearchByIdDTO { Id = managerId.Value });
            return manager != null ? $"{manager.FirstName} {manager.LastName}" : "����������� ���������";
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
                throw new ArgumentException($"�������� {columnName} �� ������� � ���� {typeof(T).Name}");

            if (direction?.ToLower() == "desc")
                return source.OrderByDescending(x => property.GetValue(x, null));
            else
                return source.OrderBy(x => property.GetValue(x, null));
        }
    }

}
