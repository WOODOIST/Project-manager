using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.Models;

public partial class Role
{
    public string Rolename { get; set; } = null!;

    
    public int Roleid { get; set; }

    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
