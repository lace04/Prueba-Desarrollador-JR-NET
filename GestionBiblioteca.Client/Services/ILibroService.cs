using GestionBiblioteca.Shared;

namespace GestionBiblioteca.Client.Services
{
    public interface ILibroService
    {
        Task<List<LibroDTO>> Lista();
        Task<LibroDTO> Buscar(int id);
        Task<int> Guardar(LibroDTO libro);

        //TODO: Editar y eliminar
        Task<int> Editar(LibroDTO libro);
        Task<bool> Eliminar(int id);

    }
}
