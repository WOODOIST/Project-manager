using ProjectManagerAPI.Models;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.DtoObjects.Outgoing
{
    public class FactDto
    {
        public string FactName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();

    }
}
