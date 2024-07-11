using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Controlador.Dtos;
using Modelo;
using Controlador;

public class CategoriaServiceTests
{
    [Fact]
    public void LogicaCrearCategoria_ShouldAddCategoriaToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UsuarioContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var context = new UsuarioContext(options);
        var service = new LogicaCategoria(context);

        var dtoCategoria = new DtoCategoria
        {
            NombreCategoria = "Test Categoria",
            IdUsuario = 1,
            CantidadGasto = 100
        };

        // Act
        service.LogicaCrearCategoria(dtoCategoria);

        // Assert
        var categoria = context.Categoria.FirstOrDefault();
        Assert.NotNull(categoria);
        Assert.Equal("Test Categoria", categoria.NombreCategoria);
        Assert.Equal(1, categoria.IdUsuario);
        Assert.Equal(100, categoria.CantidadGastos);
    }

    [Fact]
    public void LogicaVerCategoria_ShouldReturnCorrectCategories()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UsuarioContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new UsuarioContext(options))
        {
            context.Categoria.AddRange(
                new Categorium { IdCategoria = 1, NombreCategoria = "Categoria 1", IdUsuario = 1, CantidadGastos = 100 },
                new Categorium { IdCategoria = 2, NombreCategoria = "Categoria 2", IdUsuario = 1, CantidadGastos = 200 },
                new Categorium { IdCategoria = 3, NombreCategoria = "Categoria 3", IdUsuario = 2, CantidadGastos = 300 }
            );
            context.SaveChanges();

            var service = new LogicaCategoria(context);

            // Act
            var result = service.LogicaVerCategoria(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Categoria 1", result[0].NombreCategoria);
            Assert.Equal(100, result[0].CantidadGasto);
            Assert.Equal("Categoria 2", result[1].NombreCategoria);
            Assert.Equal(200, result[1].CantidadGasto);
        }

        
    }

    [Fact]
    public void CrearGasto_ShouldAddGastoToDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UsuarioContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new UsuarioContext(options))
        {
            var service = new LogicaCategoria(context);

            var dtoGasto = new DtoLimiteGasto
            {
                IdUsuario = 1,
                LimiteGasto = 500
            };

            // Act
            service.CrearGasto(dtoGasto);

            // Assert
            Assert.Equal(1, context.TablaGastos.Count());
            var gasto = context.TablaGastos.First();
            Assert.Equal(1, gasto.Idusuario);
            Assert.Equal(500, gasto.LimiteGasto);
        }
    }

    [Fact]
    public void LogicaEliminarCategoria_ShouldRemoveCategoriaFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<UsuarioContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new UsuarioContext(options))
        {
            context.Categoria.Add(new Categorium { IdCategoria = 1, NombreCategoria = "Categoria 1", IdUsuario = 1, CantidadGastos = 100 });
            context.SaveChanges();

            var service = new LogicaCategoria(context);

            // Act
            service.LogicaEliminarCategoria(1);

            // Assert
            Assert.Equal(0, context.Categoria.Count());
        }
    }
}
