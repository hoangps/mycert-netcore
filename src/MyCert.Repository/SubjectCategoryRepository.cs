using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCert.Data.Models;

namespace MyCert.Repository
{
    public class SubjectCategoryRepository : IRepository<SubjectCategory>
    {
        public IEnumerable<SubjectCategory> GetAll(Func<SubjectCategory, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public SubjectCategory Get(Func<SubjectCategory, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(SubjectCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(SubjectCategory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubjectCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
