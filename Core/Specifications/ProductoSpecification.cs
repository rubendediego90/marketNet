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
        public ProductoSpecification(ProductoSpecificationParams productoParams) 
            : base(x=>(!productoParams.Marca.HasValue || x.MarcaId== productoParams.Marca) &&
                       (!productoParams.Categoria.HasValue || x.CategoriaId== productoParams.Categoria)            
            )
        {
            AddInclude(p =>p.Categoria);
            AddInclude(p =>p.Marca);

            ApplyPaging(productoParams.PageSize*(productoParams.PageIndex-1),productoParams.PageSize);

            switch (productoParams.Sort)
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
