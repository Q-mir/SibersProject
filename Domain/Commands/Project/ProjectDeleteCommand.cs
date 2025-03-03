using Domain.DTO.Project;
using Domain.Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Async;

namespace Domain.Commands.Project
{
    public class ProjectDeleteCommand : ICommandService<ProjectDeleteDTO>
    {
        private readonly IRepository<ProjectDTO> _repository;

        public ProjectDeleteCommand(IRepository<ProjectDTO> repository)
        {
            ArgumentNullException.ThrowIfNull(repository);
            _repository = repository;
        }

        public void Execute(ProjectDeleteDTO obj)
        {
            _repository.Delete(obj);
        }
    }
}
