using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioteca.Shared
{
  public class UsuarioDTO
  {
    public string Nombre { get; set; } = null!;
    public string Correo { get; set; } = null!;
    public string Clave { get; set; } = null!;
  }
}
