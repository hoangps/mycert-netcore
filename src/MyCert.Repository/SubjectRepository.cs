using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCert.Data.Models;

namespace MyCert.Repository
{
    public class SubjectRepository : IRepository<Subject>
    {
        public IEnumerable<Subject> GetAll(Func<Subject, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Subject Get(Func<Subject, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Subject entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(Subject entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Subject entity)
        {
            throw new NotImplementedException();
        }
    }
}
