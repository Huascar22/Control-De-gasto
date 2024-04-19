using Controlador;
using Controlador.Dtos;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace Vistas.Controlador
{
    [ApiController]
    public class LimiteGasto:ControllerBase
    {
        LogicaUsuarios control;
        public LimiteGasto(LogicaUsuarios control){
            this.control = control;
        }

        [HttpPost]
        [Route("CrearLimiteGasto")]
        public ActionResult CrearLimiteGasto([FromBody] DtoLimiteGasto gasto){
            control.LimiteGasto(gasto);  
            return Ok();
        }

        [HttpGet]
        [Route("VerLimiteGasto/{idUsuario}")]

        public Decimal VerLimiteGasto(int idUsuario){
            return control.VerLimiteGasto(idUsuario);
        }

        [HttpGet]
        [Route("EnviarLimiteCorreo/{gmail}")]
        public void EnviarCorreoLimite(string gmail)
        {
            Token.EnviarCorreoLimiteGasto(gmail);
        }
    }
}
