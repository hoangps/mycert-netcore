using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyCert.Data.Models;

namespace MyCert.Services.DTO
{
    public class BaseDTO<T1, T2> where T2 : BaseEntity
    {
        public static T1 ToDTO(T2 source)
        {
            return Mapper.Map<T2, T1>(source);
        }
    }
}
