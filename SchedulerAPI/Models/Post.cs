using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.Models;

public partial class Post
{
    public string Postname { get; set; } = null!;

    public int Postid { get; set; }

    [JsonIgnore]
    public virtual ICollection<PostDynamic> PostDynamics { get; set; } = new List<PostDynamic>();
}
