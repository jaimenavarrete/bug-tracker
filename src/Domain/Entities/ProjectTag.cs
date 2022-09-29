using Domain.Common;

namespace Domain.Entities
{
    public class ProjectTag : BaseEntity
    {
        public ProjectTag()
        {
            Projects = new HashSet<Project>();
        }

        public string Name { get; set; } = null!;

        public string? GroupId { get; set; }

        public string ColorHexCode { get; set; } = null!;


        public Group? Group { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}
