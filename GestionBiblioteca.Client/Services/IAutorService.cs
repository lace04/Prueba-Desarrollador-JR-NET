using GestionBiblioteca.Shared;

namespace GestionBiblioteca.Client.Services
{
    public interface IAutorService
    {
        Task<List<AutorDTO>> Lista();
        Task<AutorDTO> Buscar(int id);
        Task<int> Guardar(AutorDTO autor);

        //TODO: Editar y eliminar
        Task<int> Editar(AutorDTO autor);
        Task<bool> Eliminar(int id);
    }
}
