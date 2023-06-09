﻿using System;
using System.Collections.Generic;

namespace Segundo_parcial_CRUD.Models;

public partial class MStatus
{
    public int Idstatus { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
