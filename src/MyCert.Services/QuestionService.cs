using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCert.Services.DTO;

namespace MyCert.Services
{
    public class QuestionService : IService<QuestionDTO>
    {
        public IEnumerable<QuestionDTO> GetAll(Func<QuestionDTO, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public QuestionDTO Get(Func<QuestionDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(QuestionDTO entityDTO)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionDTO entityDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
