using System;
using System.Collections.Generic;

namespace Segundo_parcial_CRUD.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nombre { get; set; } 

    public string Email { get; set; } 

    public string Password { get; set; } 

    public int Edad { get; set; }

    public int IdEstatus { get; set; }

    public virtual MStatus? IdEstatusNavigation { get; set; } = null!;
}
