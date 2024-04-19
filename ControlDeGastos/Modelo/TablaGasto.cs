using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Modelo;

public partial class TablaGasto
{
    public int Id { get; set; }

    public int? Idusuario { get; set; }

    public decimal? LimiteGasto { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
