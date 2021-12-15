using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProducto
    {
        Task<ProductoEntity> GetProductoByIdAsync(int Id);
        Task<IReadOnlyList<ProductoEntity>> GetAllProductsAsync();
    }
}
