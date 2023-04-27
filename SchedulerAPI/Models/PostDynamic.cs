using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.Models;

public partial class PostDynamic
{
    public int Postdynamicid { get; set; }

    public DateOnly Postdynamicstartdate { get; set; }

    public int Userid { get; set; }

    public int Postid { get; set; }

    [JsonIgnore]
    public virtual Post Post { get; set; } = null!;
    [JsonIgnore]

    public virtual User User { get; set; } = null!;
}
