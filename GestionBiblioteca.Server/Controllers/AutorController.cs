using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionBiblioteca.Server.Models;
using GestionBiblioteca.Shared;
using Microsoft.EntityFrameworkCore;

namespace GestionBiblioteca.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly DbgestionbibliotecaContext _dbContext;

        public AutorController(DbgestionbibliotecaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<AutorDTO>>();
            var listaAutorDTO = new List<AutorDTO>();

            try
            {
                foreach (var item in await _dbContext.Autores.ToListAsync())
                {
                    listaAutorDTO.Add(new AutorDTO
                    {
                        AutorId = item.AutorId,
                        Nombre = item.Nombre,
                    });
                }
                responseApi.IsSuccess = true;
                responseApi.Value = listaAutorDTO;
            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
