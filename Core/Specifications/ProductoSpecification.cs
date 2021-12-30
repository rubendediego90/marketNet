using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoSpecification : BaseSpecification<ProductoEntity>
    {
        public ProductoSpecification(string? sort)
        {
            AddInclude(p =>p.Categoria);
            AddInclude(p =>p.Marca);

            switch (sort)
            {
                case "precioAsc":
                    AddOrderBy(p => p.Precio);
                    break;
                case "precioDesc":
                    AddOrderByDesc(p => p.Precio);
                    break;
                case "descripcionAsc":
                    AddOrderBy(p => p.Descripcion);
                    break;
                case "descripcionDesc":
                    AddOrderByDesc(p => p.Descripcion);
                    break;
                case "nombreAsc":
                    AddOrderBy(p => p.Nombre);
                    break;
                case "nombreDesc":
                    AddOrderByDesc(p => p.Nombre);
                    break;
                default:
                    AddOrderBy(p => p.Nombre);
                    break;
            }

        }

        public ProductoSpecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);

        }

    }
}
