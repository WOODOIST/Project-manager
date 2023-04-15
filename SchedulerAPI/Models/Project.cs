using System;
using System.Collections.Generic;

namespace ProjectManagerAPI.Models;

public partial class Project
{
    public int Projectid { get; set; }

    public string Projectname { get; set; } = null!;

    public DateOnly Projectcreationdate { get; set; }

    public DateOnly? Projectfinishdate { get; set; }

    public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();
}
