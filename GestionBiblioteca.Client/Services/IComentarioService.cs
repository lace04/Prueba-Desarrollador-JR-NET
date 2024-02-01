using GestionBiblioteca.Shared;

namespace GestionBiblioteca.Client.Services
{
    public interface IComentarioService
    {
        Task<List<ComentarioDTO>> Lista();
        Task<int> Guardar(ComentarioDTO comentario);
    }
}
