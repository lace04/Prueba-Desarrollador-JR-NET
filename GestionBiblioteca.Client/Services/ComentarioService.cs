using GestionBiblioteca.Shared;
using System.Net.Http.Json;

namespace GestionBiblioteca.Client.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly HttpClient _http;

        public ComentarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ComentarioDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ComentarioDTO>>>("api/Comentario/Lista");

            if (result!.IsSuccess)
            {
                return result.Value!;
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        public async Task<int> Guardar(ComentarioDTO comentario)
        {
            var result = await _http.PostAsJsonAsync("api/Comentario/Guardar", comentario);
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
    }
}
