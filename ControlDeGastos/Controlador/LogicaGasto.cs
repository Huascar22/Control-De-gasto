using Controlador.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class LogicaGasto{
        UsuarioContext contex;
        public LogicaGasto(UsuarioContext contex){
            this.contex = contex;
        }
        public void CrearGastoCategorizado(DtoGastosCategorizados gastoC){
            var gastoUsuario = contex.Gastos.Where(L => L.IdUsuario == gastoC.IdUsuario)
                .Where(i => i.IdCategoria == gastoC.IdCategoria).ToList();
            Gasto gasto = new Gasto{
                NombreGasto = gastoC.NombreGasto,
                CantidadGasto = gastoC.CantidadGasto,
                IdCategoria = gastoC.IdCategoria,
                IdUsuario = gastoC.IdUsuario,
                GastoAcumulado = gastoUsuario.Sum(L => L.CantidadGasto) + gastoC.CantidadGasto
            };
            contex.Gastos.Add(gasto);
            contex.SaveChanges();
            ActualizarCategoria(gasto);
        }
        public void ActualizarCategoria(Gasto gasto){
            contex.Categoria.FirstOrDefault(i => i.IdCategoria == gasto.IdCategoria)
                .CantidadGastos = gasto.GastoAcumulado;
            contex.SaveChanges();
        }
        public List<DtoGastosCategorizados> LogicaVerGastos(int idUsuario){
            var gastosUsuario =  contex.Gastos.Where(U => U.IdUsuario == idUsuario).ToList();
            List<DtoGastosCategorizados> listaGastos = new List<DtoGastosCategorizados>();
            foreach(var gasto in gastosUsuario) {
                DtoGastosCategorizados gastosDto = new DtoGastosCategorizados() {
                    IdGasto = gasto.IdGastos,
                    IdUsuario = (int)gasto.IdUsuario,
                    IdCategoria = (int)gasto.IdCategoria,
                    CantidadGasto = (int)gasto.CantidadGasto,
                    NombreGasto = gasto.NombreGasto                  
                };listaGastos.Add(gastosDto);
            }return listaGastos;
        }
        public void LogicaEliminarGasto(int idGasto){
            var gastoAEliminar = contex.Gastos.FirstOrDefault(C => C.IdGastos == idGasto);
            contex.Gastos.Remove(gastoAEliminar);
            int categoria = (int)gastoAEliminar.IdCategoria;
            decimal cantidadGasto = (decimal)gastoAEliminar.CantidadGasto;
            ActualizarCategoriaGastoEliminado(cantidadGasto, categoria);
            contex.SaveChanges();
        }

        public void ActualizarCategoriaGastoEliminado(decimal cantidadGasto, int categoria)
        {
            var cantidad = contex.Categoria.FirstOrDefault(C => C.IdCategoria == categoria).CantidadGastos - cantidadGasto;
            contex.Categoria.FirstOrDefault(C => C.IdCategoria == categoria).CantidadGastos = cantidad;
            contex.SaveChanges();
        }

        

    }
}
