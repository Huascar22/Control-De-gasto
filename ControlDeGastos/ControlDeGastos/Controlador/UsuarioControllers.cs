using Controlador;
using Modelo;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Vistas.Controlador
{
    [ApiController]
    [Route("Usuarios")]
    public class UsuarioControllers: ControllerBase
    {
        LogicaUsuarios control;

        public UsuarioControllers(LogicaUsuarios control){
            this.control = control;
        }

        [HttpPost]
        [Route("EnviarCodigo")]
        public void EnviarCodigo([FromBody] string email){
            Token.EnviarCorreo(email);  
        }

        [HttpGet]
        [Route("LoginUsuario")]
        public ActionResult<List<Usuario>> LoginUsuario(){
            return control.VerUsuarios();
        }

        [HttpPost]
        [Route("GuardarUsuario")]
        public ActionResult GuardarUsua([FromBody] Usuario user){
            control.CrearUsuario(user);
            return Ok();
        }

        [HttpGet]
        [Route("codigo")]     
        public string DameCodigo(){
            return Token.EnviarCodigo();
        }

        [HttpPost]
        [Route("ConfirmarUsername")]
        public string ConfirmarUsername([FromBody] string username) { 
            return control.ExisteUsername(username);
        }

        [HttpGet]
        [Route("Login/{username}/{password}")]
        public ActionResult<Usuario> GetUsuarioEstado(string username, string password) { 
            return control.GetUsuario(username, password);
        }

        [HttpPut]
        [Route("actualizar")]       
        public ActionResult<Usuario> ActualizarUsuario([FromBody] Usuario usuario){
            return control.Actualizar(usuario);
        }
    }
}
