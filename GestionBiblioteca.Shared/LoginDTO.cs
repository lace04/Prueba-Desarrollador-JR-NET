using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioteca.Shared
{
  public class LoginDTO
  {
    public string Correo { get; set; } = null!;
    public string Clave { get; set; } = null!;
  }
}
