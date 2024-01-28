using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionBiblioteca.Server.Models;
using GestionBiblioteca.Shared;
using Microsoft.EntityFrameworkCore;

namespace GestionBiblioteca.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly DbgestionbibliotecaContext _dbContext;

        public LibroController(DbgestionbibliotecaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<LibroDTO>>();
            var listaLibroDTO = new List<LibroDTO>();

            try
            {
                foreach (var item in await _dbContext.Libros.Include(a => a.AutorIdNavigation).ToListAsync())
                {
                    listaLibroDTO.Add(new LibroDTO
                    {
                        Id = item.Id,
                        Titulo = item.Titulo,
                        AutorId = item.AutorId,
                        Autor = new AutorDTO
                        {
                            AutorId = item.AutorIdNavigation.AutorId,
                            Nombre = item.AutorIdNavigation.Nombre,
                        }
                    });
                }
                responseApi.IsSuccess = true;
                responseApi.Value = listaLibroDTO;
            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<LibroDTO>();
            var LibroDTO = new LibroDTO();

            try
            {
                var dbLibro = await _dbContext.Libros.FirstOrDefaultAsync(x => x.Id == id);

                if (dbLibro != null)
                {
                    LibroDTO.Id = dbLibro.Id;
                    LibroDTO.Titulo = dbLibro.Titulo;
                    LibroDTO.AutorId = dbLibro.AutorId;

                    responseApi.IsSuccess = true;
                    responseApi.Value = LibroDTO;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "No se encontró el libro";
                }
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
        public async Task<IActionResult> Guardar(LibroDTO libro)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbLibro = new Libro
                {
                    Titulo = libro.Titulo,
                    AutorId = libro.AutorId,
                };

                _dbContext.Libros.Add(dbLibro); // Agregar a la base de datos
                await _dbContext.SaveChangesAsync(); // Guardar cambios

                if (dbLibro.Id != 0)
                {
                    responseApi.IsSuccess = true;
                    responseApi.Value = dbLibro.Id;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "No se pudo guardar el libro";
                }
            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }
            return Ok(responseApi);
        }

        //TODO: EDITAR ELIMINAR
        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(LibroDTO libro, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbLibro = await _dbContext.Libros.FirstOrDefaultAsync(l => l.Id == id);

                if (dbLibro != null)
                {
                    dbLibro.Titulo = libro.Titulo;
                    dbLibro.AutorId = libro.AutorId;

                    _dbContext.Libros.Update(dbLibro);
                    await _dbContext.SaveChangesAsync();

                    responseApi.IsSuccess = true;
                    responseApi.Value = dbLibro.Id;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "No se encontró el libro";
                }
            }
            catch (Exception ex)
            {
                responseApi.IsSuccess = false;
                responseApi.Message = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbLibro = await _dbContext.Libros.FirstOrDefaultAsync(l => l.Id == id);

                if (dbLibro != null)
                {
                    _dbContext.Libros.Remove(dbLibro);
                    await _dbContext.SaveChangesAsync();

                    responseApi.IsSuccess = true;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "No se encontró el libro";
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
