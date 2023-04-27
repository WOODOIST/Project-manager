using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.Models;

public partial class Laborcost
{
    public int Laborcostid { get; set; }

    public string Laborcostname { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();
}
