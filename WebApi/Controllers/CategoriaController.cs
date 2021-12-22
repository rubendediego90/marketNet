using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        
        private readonly IGenericRepository<CategoriaEntity> _categoria;

        public CategoriaController(IGenericRepository<CategoriaEntity> categoria)
        {
            _categoria = categoria;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoriaEntity>>> GetCategoriaAll()
        {
            return Ok(await _categoria.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEntity>> GetCategoriaById(int id)
        {
            return await _categoria.GetByIdAsync(id);
        }
    }
}
