using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCert.Data.Models;

namespace MyCert.Repository
{
    public class QuestionRepository : IRepository<Question>
    {
        public IEnumerable<Question> GetAll(Func<Question, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public Question Get(Func<Question, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Question entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(Question entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Question entity)
        {
            throw new NotImplementedException();
        }
    }
}
