using System;
using System.Collections.Generic;

namespace Segundo_parcial_CRUD.Models;

public partial class Vhestatus
{
    public int Idestatus { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Auto> Autos { get; } = new List<Auto>();
}
