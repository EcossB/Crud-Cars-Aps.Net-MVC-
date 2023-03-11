using System;
using System.Collections.Generic;

namespace Segundo_parcial_CRUD.Models;

public partial class Auto
{
    public int Idauto { get; set; }

    public string? Marca { get; set; }

    public int? MiEstatus { get; set; }

    public string? ImgRuta { get; set; }

    public string? Modelo { get; set; }

    public string? Anio { get; set; }

    public virtual Vhestatus? oEstatus { get; set; }
}
