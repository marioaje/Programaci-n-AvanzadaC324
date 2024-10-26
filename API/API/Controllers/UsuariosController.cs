using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Moodels;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {

        private readonly MinombredeconexionDbContext _contextAcceso;


        public UsuariosController(MinombredeconexionDbContext contextAcceso)
        {
            _contextAcceso = contextAcceso;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> ObtenerUsuarios()
        {
            return Ok(_contextAcceso.prof_usuarios.ToList());
        }

        [HttpGet("{_id}")]
        public ActionResult<IEnumerable<UsuarioModel>> ObtenerUsuarios(int _id)
        {
            var datos = _contextAcceso.prof_usuarios.Find(_id);

            if (datos == null)
            {
                return NotFound("El dato buscado no existe.");
            }

            return Ok(datos);
        }



        [HttpPost]
        public IActionResult AgregarUsuario(UsuarioModel _datos)
        {

            try
            {
                _contextAcceso.prof_usuarios.Add(_datos);
                _contextAcceso.SaveChanges();

                return Ok("Usuario insertado exitosamente.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }



        [HttpPut]
        public IActionResult ModificarUsuario(UsuarioModel _datos)
        {

            try
            {
                //_datos?????
                //?????
                if ( !ConsultarDatos(_datos.id))
                {
                    return NotFound("El dato buscado no existe.");
                }

                _contextAcceso.Entry(_datos).State = EntityState.Modified;
                _contextAcceso.SaveChanges();

                return Ok("Usuario modificado exitosamente.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        [HttpDelete("{_id}")]
        public ActionResult EliminarUsuarios(int _id)
        {
            try
            {
                if (!ConsultarDatos(_id))
                {
                    return NotFound("El dato buscado no existe.");
                }

                var datos = _contextAcceso.prof_usuarios.Find(_id);

                _contextAcceso.prof_usuarios.Remove(datos);
                _contextAcceso.SaveChanges();

                return Ok($"Se elimino el registro {_id}");
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }




        private bool ConsultarDatos(int _id)
        {
            return _contextAcceso.prof_usuarios.Any(x => x.id == _id);
        }

    }
}
