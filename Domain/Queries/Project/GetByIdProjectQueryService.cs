using Domain.DTO.Project;
using Domain.Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries.Project
{
    public class GetByIdProjectQueryService : IQueryService<ProjectSearchByIdDTO, ProjectDTO>
    {
        private readonly IRepository<ProjectDTO> _repository;

        public GetByIdProjectQueryService(IRepository<ProjectDTO> repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public ProjectDTO Execute(ProjectSearchByIdDTO obj) => _repository.GetById(obj.Id);
        
    }
}
