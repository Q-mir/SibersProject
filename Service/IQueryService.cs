using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IQueryService<in Tin, out Tout> where Tin : Service.IQuery
    {
        Tout Execute(Tin obj);
    }
}
