using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCert.Data.Models;

namespace MyCert.Repository
{
    public class TestRepository : IRepository<Test>
    {
        public IEnumerable<Test> GetAll(Func<Test, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Test Get(Func<Test, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Test entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(Test entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Test entity)
        {
            throw new NotImplementedException();
        }
    }
}
