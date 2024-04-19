using Controlador;
using Controlador.Dtos;
using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace Vistas.Controlador
{
    [ApiController]
    public class CategoriaController: ControllerBase{
        LogicaCategoria contex;
        public CategoriaController(LogicaCategoria contex){
            this.contex = contex;
        }

        [HttpPost]
        [Route("CrearCategoria")]
        public ActionResult CrearCategoria([FromBody] DtoCategoria categoria){   
            contex.LogicaCrearCategoria(categoria);
            return Ok(categoria);
        }

        [HttpGet]
        [Route("VerCategorias/{idUsuario}")]
        public List<DtoCategoria> VerCategorias(int idUsuario){
            return contex.LogicaVerCategoria(idUsuario);
        }

        [HttpDelete]
        [Route("EliminarCategoria/{IdCategoria}")]
        public ActionResult EliminarCategoria(int IdCategoria) {
            contex.LogicaEliminarCategoria(IdCategoria);
            return Ok();
        }       
    }
}
