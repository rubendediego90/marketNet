using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
    
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
       
        private readonly IGenericRepository<MarcaEntity> _marca;

        public MarcaController(IGenericRepository<MarcaEntity> marca)
        {
            _marca = marca;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MarcaEntity>>> GetCategoriaAll()
        {
            return Ok(await _marca.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaEntity>> GetCategoriaById(int id)
        {
            return await _marca.GetByIdAsync(id);
        }
    }
}