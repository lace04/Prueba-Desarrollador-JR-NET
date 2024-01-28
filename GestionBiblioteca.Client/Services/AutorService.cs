using GestionBiblioteca.Shared;
using System.Net.Http.Json;

namespace GestionBiblioteca.Client.Services
{
    public class AutorService : IAutorService
    {
        private readonly HttpClient _http;

        public AutorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AutorDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<AutorDTO>>>("api/Autor/Lista");

            if (result!.IsSuccess)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<AutorDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<AutorDTO>>($"api/Autor/Buscar/{id}");
            if (result!.IsSuccess)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<int> Guardar(AutorDTO autor)
        {
            var result = await _http.PostAsJsonAsync("api/Autor/Guardar", autor);
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

        public async Task<int> Editar(AutorDTO autor)
        {
            var result = await _http.PutAsJsonAsync($"api/Autor/Editar/{autor.AutorId}", autor);
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
            var result = await _http.DeleteAsync($"api/Autor/Eliminar/{id}");
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
