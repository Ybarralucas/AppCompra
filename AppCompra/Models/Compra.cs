using System;
using System.Collections.Generic;

namespace AppCompra.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? Nombre { get; set; }

    public decimal? Total { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();
}
