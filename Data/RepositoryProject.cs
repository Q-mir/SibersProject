using Domain.DTO.Employee;
using Domain.DTO.Project;
using Domain.Repository;

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

        public bool Update(ProjectDTO obj)
        {
            Project projectUpdate = new()
            {
                ProjectId = obj.ProjectId,
                ProjectName = obj.ProjectName,
                CustomerCompany = obj.CustomerCompany,
                ExecutorCompany = obj.ExecutorCompany,
                StartDate = obj.StartDate,
                EndDate = obj.EndDate,
                Priority = obj.Priority,
            };
            _connection.Projects.Update(projectUpdate);
            return _connection.SaveChanges() > 0;
        }

        public void Delete(ProjectDTO obj)
        {
            Project? projectDelete = _connection.Projects.FirstOrDefault(p => p.ProjectId == obj.ProjectId);
            if (projectDelete != null)
            {
                _connection.Delete(projectDelete);
            }
        }
    }
}
