using System;
using System.Collections.Generic;

namespace GestionBiblioteca.Server.Models;

public partial class Libro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int AutorId { get; set; }

    public virtual Autor AutorIdNavigation { get; set; } = null!;
}
