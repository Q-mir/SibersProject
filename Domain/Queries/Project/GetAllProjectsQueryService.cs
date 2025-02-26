using Domain.DTO.Project;
using Domain.Repository;
using Services;

namespace Domain.Queries.Project
{
    public class GetAllProjectsQueryService : IQueryService<All, IEnumerable<ProjectDTO>>
    {
        private readonly IRepository<ProjectDTO> _repository;

        public GetAllProjectsQueryService(IRepository<ProjectDTO> repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public IEnumerable<ProjectDTO> Execute(All obj) => _repository.GetAll();
        
    }
}
