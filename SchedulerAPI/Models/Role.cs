using System;
using System.Collections.Generic;

namespace SchedulerAPI.Models;

public partial class Role
{
    public string Rolename { get; set; } = null!;

    public int Roleid { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
