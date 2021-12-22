using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    //la clase genérica debe heredar de las BaseClass. La clase T debe heredad de la clase base
    public interface IGenericRepository<T> where T : BaseClass
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> GetAllSpec(ISpecification<T> spec);

    }
}
