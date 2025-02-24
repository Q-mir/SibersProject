using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICommandService<in T> where T : class
    {
        void Execute(T obj);
    }
}
