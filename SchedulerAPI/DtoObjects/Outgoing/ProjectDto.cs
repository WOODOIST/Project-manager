using ProjectManagerAPI.Models;
using System.Text.Json.Serialization;

namespace ProjectManagerAPI.DtoObjects.Outgoing
{
    public class ProjectDto
    {
        public string ProjectName { get; set; }

        public DateOnly ProjectCreationDate { get; set; }

        public DateOnly? ProjectFinishDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Plannedlaborcost> Plannedlaborcosts { get; set; } = new List<Plannedlaborcost>();
    }
}
