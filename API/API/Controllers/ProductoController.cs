using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        //Variables
        //??????? 
        private static List<string> _productos = new List<string>
        {
            "TV","Itachi","Venom","laptop","monitor"
        };


        [HttpGet]
        public IActionResult ObtenerProductos()
        {
            return Ok(_productos);
        }
        //GET POST PUT DELETE CRUD


    }
}
