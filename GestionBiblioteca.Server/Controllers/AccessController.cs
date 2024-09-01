using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionBiblioteca.Server.Custom;
using GestionBiblioteca.Server.Models;
using GestionBiblioteca.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace GestionBiblioteca.Server.Controllers
{
  [Route("api/[controller]")]
  [AllowAnonymous]
  [ApiController]
  public class AccessController : ControllerBase
  {
    private readonly DbgestionbibliotecaContext _dbContext;
    private readonly Utils _utils;
    public AccessController(DbgestionbibliotecaContext dbContext, Utils utils)
    {
      _dbContext = dbContext;
      _utils = utils;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(UsuarioDTO objeto)
    {
      var modeloUsuario = new Usuario
      {
        Nombre = objeto.Nombre,
        Correo = objeto.Correo,
        Clave = _utils.encriptarSHA256(objeto.Clave)
      };

      await _dbContext.Usuarios.AddAsync(modeloUsuario);
      await _dbContext.SaveChangesAsync();

      if (modeloUsuario.IdUsuario != 0)
      {
        return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
      }
      else
      {
        return StatusCode(StatusCodes.Status400BadRequest, new { isSucess = false });
      }
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginDTO objeto)
    {
      var usuarioEncontrado = await _dbContext.Usuarios
        .Where(u => u.Correo == objeto.Correo && u.Clave == _utils.encriptarSHA256(objeto.Clave)).FirstOrDefaultAsync();

      if (usuarioEncontrado != null)
      {
        return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utils.generarJWT(usuarioEncontrado) });
      }
      else
      {
        return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = false, token = "" });
      }
    }
  }
}
