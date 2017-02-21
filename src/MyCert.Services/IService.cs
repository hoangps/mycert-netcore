using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCert.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        T Get(Func<T, bool> predicate);
        void Create(T entityDTO);
        void Update(T entityDTO);
        void Delete(Guid id);
    }
}
