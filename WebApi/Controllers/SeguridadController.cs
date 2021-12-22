using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly UserManager<UsuarioEntity> _userManager;
        private readonly SignInManager<UsuarioEntity> _signInManager;

        public SeguridadController(UserManager<UsuarioEntity> userManager, SignInManager<UsuarioEntity> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

//        [HttpPost("login")]
 //       public async Task<ActionResult<UsuarioDto>> Login(LoginDto loginDto)
  //      {

   //     }
    }
}
