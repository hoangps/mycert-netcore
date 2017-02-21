using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCert.Data.Models;

namespace MyCert.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        T Get(Func<T, bool> predicate);
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
    }
}
