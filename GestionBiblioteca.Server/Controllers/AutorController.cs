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

        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<AutorDTO>();
            var AutorDTO = new AutorDTO();

            try
            {
                var dbAutor = await _dbContext.Autores.FirstOrDefaultAsync(x => x.AutorId == id);

                if (dbAutor != null)
                {
                    AutorDTO.AutorId = dbAutor.AutorId;
                    AutorDTO.Nombre = dbAutor.Nombre;

                    responseApi.IsSuccess = true;
                    responseApi.Value = AutorDTO;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "No se encontro el autor";
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
        public async Task<IActionResult> Guardar(AutorDTO autor)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAutor = new Autor
                {
                    Nombre = autor.Nombre
                };

                _dbContext.Autores.Add(dbAutor);
                await _dbContext.SaveChangesAsync();

                if (dbAutor.AutorId != 0)
                {
                    responseApi.IsSuccess = true;
                    responseApi.Value = dbAutor.AutorId;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "No se pudo guardar el autor";
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
        public async Task<IActionResult> Editar(AutorDTO autor, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAutor = await _dbContext.Autores.FirstOrDefaultAsync(a => a.AutorId == id);

                if (dbAutor != null)
                {
                    dbAutor.Nombre = autor.Nombre;

                    _dbContext.Autores.Update(dbAutor);
                    await _dbContext.SaveChangesAsync();

                    responseApi.IsSuccess = true;
                    responseApi.Value = dbAutor.AutorId;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "No se encontro el autor";
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
                var dbAutor = await _dbContext.Autores.FirstOrDefaultAsync(a => a.AutorId == id);

                if (dbAutor != null)
                {
                    _dbContext.Autores.Remove(dbAutor);
                    await _dbContext.SaveChangesAsync();

                    responseApi.IsSuccess = true;
                }
                else
                {
                    responseApi.IsSuccess = false;
                    responseApi.Message = "No se encontro el autor";
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
