using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace GestionBiblioteca.Shared
{
    public class ComentarioDTO
    {
        public int ComentarioId { get; set; }

        [Required(ErrorMessage = "El comentario es obligatorio")]
        public string Comentario1 { get; set; } = null!;

        public int LibroId { get; set; }

        public LibroDTO? Libro{ get; set; }
    }
}
