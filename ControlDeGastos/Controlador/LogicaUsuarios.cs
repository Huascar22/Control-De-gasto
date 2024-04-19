using Controlador.Dtos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class LogicaUsuarios
    {
        

        UsuarioContext context;
        public LogicaUsuarios(UsuarioContext context){
            this.context = context;
        }
        public List<Usuario> CrearUsuario(Usuario usuario){
            context.Add(usuario);
            context.SaveChanges();
            return context.Usuarios.ToList();
        }

        public List<Usuario> VerUsuarios(){
            return context.Usuarios.ToList();
        }

        public string ExisteUsername(string username){
            return context.Usuarios
                .ToList().Any(User => User.Username == username) ? "Existe" : "No existe";
        }

        public Usuario GetUsuario(string username, string password){ 
            return context.Usuarios
                .FirstOrDefault(U => U.Username == username && U.Password == password);
        }

        public Usuario Actualizar(Usuario usuario){
            Usuario UsuarioActual = new Usuario();
            UsuarioActual = context.Usuarios.FirstOrDefault(U => U.Id == usuario.Id);
            UsuarioActual.Username = usuario.Username;
            UsuarioActual.Name = usuario.Name;
            UsuarioActual.Phone = usuario.Phone;
            UsuarioActual.Email = usuario.Email;
            context.SaveChanges();
            return UsuarioActual;
        }

        public void LimiteGasto(DtoLimiteGasto gasto){
            if(context.TablaGastos.Any(C=>C.Idusuario == gasto.IdUsuario)){
                var limiteBorrar = context.TablaGastos.FirstOrDefault(C => C.Idusuario == gasto.IdUsuario);
                context.TablaGastos.Remove(limiteBorrar);
                context.SaveChanges() ;
            }
            TablaGasto Limitegasto = new TablaGasto{
                Idusuario = gasto.IdUsuario,
                LimiteGasto = gasto.LimiteGasto
            };
            context.TablaGastos.Add(Limitegasto);
            context.SaveChanges();
        }
        public decimal VerLimiteGasto(int idUsuario){
            if(context.TablaGastos.Any(G => G.Idusuario == idUsuario)){
                return (decimal)context.TablaGastos.FirstOrDefault(G => G.Idusuario == idUsuario).LimiteGasto;
            }return 0;          
        }
    }
}
