using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.Models;

public partial class Scenario
{
    public int Scenarioid { get; set; }

    public string Scenarioname { get; set; } = null!;

    [JsonIgnore]

    public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();
}
