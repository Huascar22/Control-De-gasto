using System;
using System.Collections.Generic;

namespace Modelo;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Categorium> Categoria { get; } = new List<Categorium>();

    public virtual ICollection<Gasto> Gastos { get; } = new List<Gasto>();

    public virtual ICollection<TablaGasto> TablaGastos { get; } = new List<TablaGasto>();
}
