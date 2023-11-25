using System;
using System.Collections.Generic;

namespace AppCompra.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? NombreProducto { get; set; }

    public string? Img { get; set; }

    public decimal? PrecioProducto { get; set; }
}
