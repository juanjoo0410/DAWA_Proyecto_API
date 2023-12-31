﻿using System;
using System.Collections.Generic;

namespace TiendaMascotas_API.Models;

public partial class ProductoMascota
{
    public int IdProductoMascota { get; set; }

    public int IdProducto { get; set; }

    public int IdMascota { get; set; }

    public DateTime CreadoDate { get; set; }

    public virtual Mascota IdMascotaNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
