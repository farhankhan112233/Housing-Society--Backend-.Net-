using System;
using System.Collections.Generic;

namespace Housing_Society.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public int? StateId { get; set; }

    public virtual ICollection<House> Houses { get; set; } = new List<House>();

    public virtual State? State { get; set; }
}
