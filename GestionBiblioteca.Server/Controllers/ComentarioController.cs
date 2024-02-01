using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionBiblioteca.Server.Models;
using GestionBiblioteca.Shared;
using Microsoft.EntityFrameworkCore;

namespace GestionBiblioteca.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly DbgestionbibliotecaContext _dbContext;

        public ComentarioController(DbgestionbibliotecaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<ComentarioDTO>>();
            var listaComentarioDTO = new List<ComentarioDTO>();

            try
            {
                foreach (var item in await _dbContext.Comentarios.Include(l => l.LibroIdNavigation).ToListAsync())
                {
                    listaComentarioDTO.Add(new ComentarioDTO
                    {
                        ComentarioId = item.ComentarioId,
                        Comentario1 = item.Comentario1,
                        LibroId = item.LibroId,
                        Libro = new LibroDTO
                        {
                            LibroId = item.LibroIdNavigation.LibroId,
                            Titulo = item.LibroIdNavigation.Titulo,
                        }
                    });
                }
                responseApi.IsSuccess = true;
                responseApi.Value = listaComentarioDTO;
            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(ComentarioDTO libro)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbComentario = new Comentario
                {
                    Comentario1 = libro.Comentario1,
                    LibroId = libro.LibroId
                };

                _dbContext.Comentarios.Add(dbComentario); // Agregar a la base de datos
                await _dbContext.SaveChangesAsync(); // Guardar cambios

                if (dbComentario.ComentarioId != 0)
                {
                    responseApi.IsSuccess = true;
                    responseApi.Value = dbComentario.ComentarioId;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "No se pudo guardar el comentario";
                }
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
