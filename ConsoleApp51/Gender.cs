﻿using System;
using System.Collections.Generic;

namespace ConsoleApp51;

public partial class Gender
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
