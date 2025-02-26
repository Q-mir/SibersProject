using Domain.DTO.Project;
using Domain.Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Project
{
    public class ProjectUpdateCommand : ICommandService<ProjectUpdateDTO>
    {
        private readonly IRepository<ProjectDTO> _repository;

        public ProjectUpdateCommand(IRepository<ProjectDTO> repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public void Execute(ProjectUpdateDTO obj)
        {
            _repository.Update(obj);
        }
    }
}
