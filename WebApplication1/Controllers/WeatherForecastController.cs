using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "chile picoso", "Cool"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDbContext _db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
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
            var usuarios = _db.Usuarios.ToList(); // Trae todos los registros de la tabla usuarios
            return Ok(usuarios);
        }
    }
}
