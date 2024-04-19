using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador.Dtos{
    public  class DtoCategoria{

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCategoria { get; set; }
        public decimal CantidadGasto { get; set; }
    }
}
