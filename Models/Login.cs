using System;
using System.Collections.Generic;

namespace Housing_Society.Models;

public partial class Login
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string LPassword { get; set; } = null!;
}
