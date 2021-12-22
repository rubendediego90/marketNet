using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Errors;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericRepository<ProductoEntity> _producto;
        private readonly IMapper _mapper;
        public ProductoController(IGenericRepository<ProductoEntity> producto, IMapper mapper)
        {
            _producto = producto;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductoEntity>>> GetProductos()
        {
            var spec = new ProductoSpecification();
            var productos = await _producto.GetAllSpec(spec);
            return Ok(_mapper.Map<IReadOnlyList<ProductoEntity>, IReadOnlyList<ProductoDto>>(productos));   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProductoById(int id)
        {
            var spec = new ProductoSpecification(id);
            var producto = await _producto.GetByIdSpec(spec);

            if(producto == null)
            {
                return NotFound(new CodeErrors(404,"El producto no existe personalizado"));
            }
            return _mapper.Map<ProductoEntity, ProductoDto>(producto);
        }
    }
}
