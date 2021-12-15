using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _producto;

        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductoEntity>>> GetProductos()
        {
            var productos = await _producto.GetAllProductsAsync();
            return Ok(productos);   
        }
    }
}
