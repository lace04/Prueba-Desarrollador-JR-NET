using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.Shared
{
    public class LibroDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "El autor es obligatorio")]
        public int AutorId { get; set; }

        public AutorDTO? Autor { get; set; }

    }
}
