using System;
using System.Collections.Generic;

namespace Modelo;

public partial class Gasto
{
    public int IdGastos { get; set; }

    public string? NombreGasto { get; set; }

    public decimal? CantidadGasto { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdUsuario { get; set; }

    public decimal? GastoAcumulado { get; set; }

    public decimal? LimiteGasto { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
