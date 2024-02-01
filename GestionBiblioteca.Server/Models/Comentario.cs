using System;
using System.Collections.Generic;

namespace GestionBiblioteca.Server.Models;

public partial class Comentario
{
    public int ComentarioId { get; set; }

    public string Comentario1 { get; set; } = null!;

    public int LibroId { get; set; }

    public virtual Libro LibroIdNavigation { get; set; } = null!;
}
