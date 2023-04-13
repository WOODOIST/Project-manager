using System;
using System.Collections.Generic;

namespace SchedulerAPI.Models;

public partial class Laborcost
{
    public int Laborcostid { get; set; }

    public string Laborcostname { get; set; } = null!;

    public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();
}
