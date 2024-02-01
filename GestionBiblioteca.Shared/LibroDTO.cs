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

        public int LibroId { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; } = null!;

        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "El autor es requerido.")]
        public int AutorId { get; set; }

        public AutorDTO? Autor { get; set; }

    }
}
