using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObtenerPrdocutos()
        {
            return Ok("Saludos clase");
        }
        //GET POST PUT DELETE CRUD


    }
}
