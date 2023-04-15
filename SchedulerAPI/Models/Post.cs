using System;
using System.Collections.Generic;

namespace ProjectManagerAPI.Models;

public partial class Post
{
    public string Postname { get; set; } = null!;

    public int Postid { get; set; }

    public virtual ICollection<PostDynamic> PostDynamics { get; set; } = new List<PostDynamic>();
}
