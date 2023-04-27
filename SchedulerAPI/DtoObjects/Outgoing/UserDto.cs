using ProjectManagerAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.DtoObjects.Outgoing
{
    public class UserDto
    {
        public string UserSurname { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string? UserPatronymic { get; set; }

        public string UserEmail { get; set; } = null!;

        public int Roleid { get; set; }

        public string Rolename { get; set; }
        [JsonIgnore]
        public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();



    }
}
