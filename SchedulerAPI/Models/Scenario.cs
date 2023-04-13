using System;
using System.Collections.Generic;

namespace SchedulerAPI.Models;

public partial class Scenario
{
    public int Scenarioid { get; set; }

    public string Scenarioname { get; set; } = null!;

    public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();
}
