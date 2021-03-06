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
    public class ProductoController : BaseApiController
    {
        private readonly IGenericRepository<ProductoEntity> _producto;
        private readonly IMapper _mapper;
        public ProductoController(IGenericRepository<ProductoEntity> producto, IMapper mapper)
        {
            _producto = producto;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<PaginationResponse<ProductoDto>>> GetProductos([FromQuery]ProductoSpecificationParams productoParams)
        {

            var spec = new ProductoSpecification(productoParams);
            var productos = await _producto.GetAllSpec(spec);
            var spectCount = new ProductoForCountingSpecification(productoParams);
            var totalProductos = await _producto.CountAync(spectCount);//total de productos
            var rounded = Math.Ceiling(Convert.ToDecimal(totalProductos / productoParams.PageSize));//cantidad de paginas
            var totalPages = Convert.ToInt32(rounded);
            var data = _mapper.Map<IReadOnlyList<ProductoEntity>, IReadOnlyList<ProductoDto>>(productos);

            return Ok(
                new PaginationResponse<ProductoDto>
                {
                    Count = totalProductos,
                    Data = data,
                    PageCount = totalPages,
                    PageIndex = productoParams.PageIndex,
                    PaseSize = productoParams.PageSize
                }
                );
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
