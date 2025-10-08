using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        
        private readonly ILogger<UsuarioController> _logger;
        private readonly AppDbContext _db;

        public UsuarioController(ILogger<UsuarioController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("holapicoso")]
        public string Hola()
        {
            return "Hola desde mi primer método en .NET 🎉";
        }

        [HttpPost("crear-usuario")]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            _db.SaveChanges();

            return Ok(new
            {
                mensaje = "Usuario guardado en MySQL ✅",
                datos = usuario
            });
        }

        // GET: api/usuarios
        [HttpGet("traer-usuario")]
        public IActionResult GetUsuarios()
        {
            Console.WriteLine("✅ Entró al método traer usuario");

            var usuarios = _db.Usuarios.ToList(); // Trae todos los registros de la tabla usuarios
            return Ok(usuarios);
        }

        [HttpPut("actualizar-usuario/{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuarioActualizado)
        {
            var usuarioExistente = _db.Usuarios.FirstOrDefault(u => u.Iduser == id);

            if (usuarioExistente == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado ❌" });
            }
            Console.WriteLine("Hola desde el servidor ASP.NET Core!");
            // Actualiza los campos
            usuarioExistente.Nombre = usuarioActualizado.Nombre;
  
            _db.Usuarios.Update(usuarioExistente);
            _db.SaveChanges();

            return Ok(new
            {
                mensaje = "Usuario actualizado correctamente ✅",
                datos = usuarioExistente
            });
        }

        [HttpDelete("eliminar-usuario/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuario = _db.Usuarios.FirstOrDefault(u => u.Iduser == id);

            if (usuario == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado ❌" });
            }

            _db.Usuarios.Remove(usuario);
            _db.SaveChanges();

            return Ok(new { mensaje = "Usuario eliminado correctamente ✅" });
        }


    }
}
