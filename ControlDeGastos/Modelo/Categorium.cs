using System;
using System.Collections.Generic;

namespace Modelo;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public int? IdUsuario { get; set; }

    public string? NombreCategoria { get; set; }

    public decimal? CantidadGastos { get; set; }

    public virtual ICollection<Gasto> Gastos { get; } = new List<Gasto>();

    public virtual Usuario? IdUsuarioNavigation { get; }
}
