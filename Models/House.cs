using System;
using System.Collections.Generic;

namespace Housing_Society.Models;

public partial class House
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CityId { get; set; }

    public int AvailableUnits { get; set; }

    public string Wifi { get; set; } = null!;

    public string Laundry { get; set; } = null!;

    public string? Description { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
}
