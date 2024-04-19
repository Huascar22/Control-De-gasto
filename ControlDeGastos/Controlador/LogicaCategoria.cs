using Controlador.Dtos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class LogicaCategoria
    {
        UsuarioContext context;

        public LogicaCategoria(UsuarioContext context){
            this.context = context;
        }
        public void LogicaCrearCategoria(DtoCategoria categoria){
            Categorium categorium = new Categorium{
                NombreCategoria = categoria.NombreCategoria,
                IdUsuario = categoria.IdUsuario,
                CantidadGastos = categoria.CantidadGasto
            };
            context.Categoria.Add(categorium);
            context.SaveChanges();
        }
        public List<DtoCategoria> LogicaVerCategoria(int idUsuario){
            List<Categorium> categorium = new List<Categorium>();
            List<DtoCategoria> categoriaDto = new List<DtoCategoria>();
            categorium = context.Categoria.Where(C => C.IdUsuario == idUsuario).ToList();
            foreach(var item in categorium) {
                DtoCategoria categorias = new DtoCategoria{
                    Id= item.IdCategoria,
                    NombreCategoria = item.NombreCategoria,
                    IdUsuario = (int)item.IdUsuario,
                    CantidadGasto = (decimal)item.CantidadGastos
                };
                categoriaDto.Add(categorias);
            }return categoriaDto;
        }     
        public void CrearGasto(DtoLimiteGasto gasto){
            TablaGasto tablaGasto = new TablaGasto{
                Idusuario = gasto.IdUsuario,
                LimiteGasto = gasto.LimiteGasto
            };context.TablaGastos.Add(tablaGasto);
        }
        public void LogicaEliminarCategoria(int idCategoria){
            var categoriaRemove = context.Categoria.FirstOrDefault(c => c.IdCategoria == idCategoria);
            context.Categoria.Remove(categoriaRemove);
            context.SaveChanges();
        }
    }
}
