using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository<T>
    {
        void Add(T obj);
        bool Check(string key);
        List<T> GetAll();
        T GetById(int id);
        //Task<IEnumerable<T>> GetAllAsync(); //TODO
    }
}
