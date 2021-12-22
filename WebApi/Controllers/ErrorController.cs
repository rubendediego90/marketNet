using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Errors;

namespace WebApi.Controllers
{
    //El fragmento hace que swagger al no tener controlador no se rompa
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase

    {
        [Route("error")]
        public CodeErrors Error()
        {
            int code = HttpContext.Response.StatusCode;
            //var exception = context.Error; // Your exception
            return new CodeErrors(code);
        }
    }
}
