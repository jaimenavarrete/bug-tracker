using Domain.Common;

namespace Domain.Entities
{
    public class ProjectState : BaseEntity
    {
        public ProjectState()
        {
            Projects = new HashSet<Project>();
        }

        public string Name { get; set; } = null!;

        public string? GroupId { get; set; }

        public string ColorHexCode { get; set; } = null!;


        public Group? Group { get; set; } = null!;

        public IEnumerable<Project> Projects { get; set; }
    }
}
