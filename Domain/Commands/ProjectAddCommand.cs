using Domain.DTO;
using Domain.Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class ProjectAddCommand : ICommandService<ProjectDTO>
    {
        private readonly IRepository<ProjectDTO> _repository;
        
        public ProjectAddCommand(IRepository<ProjectDTO> repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public void Execute(ProjectDTO obj)
        {
            //TODO

            if (!_repository.Check(obj.ProjectName))
            {
                _repository.Add(obj);
            }
        }
    }
}
