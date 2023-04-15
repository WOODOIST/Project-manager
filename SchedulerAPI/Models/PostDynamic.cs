using System;
using System.Collections.Generic;

namespace ProjectManagerAPI.Models;

public partial class PostDynamic
{
    public int Postdynamicid { get; set; }

    public DateOnly Postdynamicstartdate { get; set; }

    public int Userid { get; set; }

    public int Postid { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
