using System;
using System.Collections.Generic;

namespace ProjectManagerAPI.Models;

public partial class Plannedlaborcost
{
    public int Plannedlaborcostid { get; set; }

    public int? Scenarioid { get; set; }

    public int? Laborcostid { get; set; }

    public int? Factid { get; set; }

    public DateOnly? Plannedlaborcostfilldate { get; set; }

    public decimal? Plannedlaborcostpercent { get; set; }

    public int? Projectid { get; set; }

    public int? Userid { get; set; }

    public virtual Fact? Fact { get; set; }

    public virtual Laborcost? Laborcost { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Scenario? Scenario { get; set; }

    public virtual User? User { get; set; }
}
