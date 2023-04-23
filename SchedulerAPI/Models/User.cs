using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.Models;

public partial class User
{
    public int Userid { get; set; }

    public string? Usersurname { get; set; }

    public string? Username { get; set; }

    public string? Userpatronymic { get; set; }

    public string? Userlogin { get; set; }

    public string? Userpassword { get; set; }

    public string? Useremail { get; set; }

    public int Roleid { get; set; }

    [ForeignKey("Roleid")]
    public  Role Role { get; set; }

    [JsonIgnore]
    public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();

    [JsonIgnore]
    public virtual ICollection<PostDynamic> PostDynamics { get; set; } = new List<PostDynamic>();
    

    
}
