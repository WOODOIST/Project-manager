using System;
using System.Collections.Generic;

namespace ProjectManagerAPI.Models;

public partial class Fact
{
    public int Factid { get; set; }

    public string Factname { get; set; } = null!;

    public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();
}
