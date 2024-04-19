using Controlador;
using Controlador.Dtos;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace Vistas.Controlador
{
    [ApiController]
    public class GastoCategorizadoController: ControllerBase
    {
        LogicaGasto control;
        public GastoCategorizadoController(LogicaGasto control){
            this.control = control;
        }

        [HttpPost]
        [Route("CrearGastoCategorizado")]
        public void CrearGasto([FromBody] DtoGastosCategorizados gasto){
            control.CrearGastoCategorizado(gasto);
        }

        [HttpGet]
        [Route("VerGastos/{idUsuario}")]
        public List<DtoGastosCategorizados> VerGastos(int idUsuario){
            return control.LogicaVerGastos(idUsuario);
        }

        [HttpDelete]
        [Route("EliminarGasto/{idGasto}")]
        public void EliminarGasto(int idGasto){
            control.LogicaEliminarGasto(idGasto);
        }
    }
}
