using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCert.Services.DTO;

namespace MyCert.Services
{
    public class AnswerService : IService<AnswerDTO>
    {
        public IEnumerable<AnswerDTO> GetAll(Func<AnswerDTO, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public AnswerDTO Get(Func<AnswerDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(AnswerDTO entityDTO)
        {
            throw new NotImplementedException();
        }

        public void Update(AnswerDTO entityDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
