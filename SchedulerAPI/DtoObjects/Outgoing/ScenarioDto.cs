using ProjectManagerAPI.Models;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.DtoObjects.Outgoing
{
    public class ScenarioDto
    {
        public string ScenarioName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();

    }
}
