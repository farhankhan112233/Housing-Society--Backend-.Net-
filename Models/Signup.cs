using System;
using System.Collections.Generic;

namespace Housing_Society.Models
{
    public partial class Signup
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string SPassword { get; set; } = null!;
    }
}
