using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //Criteria , condicion logica de la consulta
        Expression<Func<T, bool>> Criteria {get;}

        //includes, relaciones entre entidades
        List<Expression<Func<T,object>>> Includes { get;}

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDesc { get; }




    }
}
