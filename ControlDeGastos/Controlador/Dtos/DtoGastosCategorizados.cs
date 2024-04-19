using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Dtos
{
    public class DtoGastosCategorizados
    {
        public int IdGasto { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public int CantidadGasto { get; set; }
        public string  NombreGasto { get; set; }

    }
}
