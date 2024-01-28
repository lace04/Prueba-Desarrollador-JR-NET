using GestionBiblioteca.Shared;
using System.Net.Http.Json;

namespace GestionBiblioteca.Client.Services
{
    public class LibroService : ILibroService
    {
        private readonly HttpClient _http;

        public LibroService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<LibroDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<LibroDTO>>>("api/Libro/Lista");

            if (result!.IsSuccess)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<LibroDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<LibroDTO>>($"api/Libro/Buscar/{id}");
            if (result!.IsSuccess)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<int> Guardar(LibroDTO libro)
        {
            var result = await _http.PostAsJsonAsync("api/Libro/Guardar", libro);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.IsSuccess)
            {
                return response.Value!;
            }
            else
            {
                throw new Exception(response.Message);
            }

        }

        public async Task<int> Editar(LibroDTO libro)
        {
            var result = await _http.PutAsJsonAsync($"api/Libro/Editar/{libro.Id}", libro);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.IsSuccess)
            {
                return response.Value!;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Libro/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.IsSuccess)
            {
                return response.IsSuccess!;
            }
            else
            {
                throw new Exception(response.Message);
            }
        }
    }
}
