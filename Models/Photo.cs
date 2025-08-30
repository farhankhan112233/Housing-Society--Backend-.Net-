using System;
using System.Collections.Generic;

namespace Housing_Society.Models;

public partial class Photo
{
    public int PhotoId { get; set; }

    public int? HousingId { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public virtual House? Housing { get; set; }
}
