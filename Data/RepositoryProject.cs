using Domain.DTO;
using Domain.Repository;
using SibersProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace Data
{
    public class RepositoryProject : IRepository<ProjectDTO>
    {
        private readonly Connection _connection;

        public RepositoryProject(Connection connection)
        {
            ArgumentNullException.ThrowIfNull(connection);
            _connection = connection;
        }

        public void Add(ProjectDTO obj)
        {
            
            _connection.Projects.Add(new Project()
            {
                ProjectName = obj.ProjectName,
                CustomerCompany = obj.CustomerCompany,
                ExecutorCompany = obj.ExecutorCompany,
                StartDate = obj.StartDate,
                EndDate = obj.EndDate,
                Priority = obj.Priority,
                ProjectManagerId = obj.ProjectManagerId
            });
            _connection.SaveChanges();
            
        }

        public bool Check(string key) => _connection.Projects.Any(p => p.ProjectName == key);

        public List<ProjectDTO> GetAll() => _connection.Projects.Select(e => Convert(e)).ToList();

        public ProjectDTO GetById(int id)
        {
            var project = _connection.Projects.FirstOrDefault(p => p.ProjectId == id);
            return project == null ? null : Convert(project);
        }

        private static ProjectDTO? Convert(Project obj)
                       => obj == null ? null : new ProjectDTO()
                       {
                           ProjectName = obj.ProjectName,
                           CustomerCompany = obj.CustomerCompany,
                           ExecutorCompany = obj.ExecutorCompany,
                           StartDate = obj.StartDate,
                           EndDate = obj.EndDate,
                           Priority = obj.Priority,
                           ProjectManagerId = obj.ProjectManagerId
                       };
    }
}
