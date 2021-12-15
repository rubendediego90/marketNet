using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Negocio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Logic
{
    public class Producto : IProducto
    {
        private readonly AppDbContext _context;
        public Producto(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<ProductoEntity>> GetAllProductsAsync()
        {
            return await _context.ProductoTabla.ToListAsync();
        }

        public async Task<ProductoEntity> GetProductoByIdAsync(int id)
        {
            return await _context.ProductoTabla.FindAsync(id);

        }
    }
}
