using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Project
{
    public class ProjectSearchByIdDTO : IQuery
    {
        public int Id { get; set; }
    }
}
