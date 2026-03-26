using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioAPI.Data;
using InventarioAPI.Models;
using BCrypt.Net; // <--- Asegúrate de que esta línea esté aquí

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public AuthController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Cambiamos la búsqueda: de Dni a Correo
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == request.Correo);

            if (usuario == null) return Unauthorized(new { message = "Correo no registrado" });

            bool passwordValida = BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash);
            if (!passwordValida) return Unauthorized(new { message = "Contraseña incorrecta" });

            return Ok(new { dni = usuario.Dni, nombre = usuario.Nombres, rol = usuario.Rol });
        }

    }
}