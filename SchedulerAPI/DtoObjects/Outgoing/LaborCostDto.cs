using ProjectManagerAPI.Models;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.DtoObjects.Outgoing
{
    public class LaborCostDto
    {
        public string LaborCostName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();
    }
}
