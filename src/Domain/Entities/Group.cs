using Domain.Common;

namespace Domain.Entities
{
    public class Group : BaseEntity
    {
        public Group()
        {
            ProjectStates = new HashSet<ProjectState>();
            ProjectTags = new HashSet<ProjectTag>();
            Projects = new HashSet<Project>();
        }

        public string? Name { get; set; }

        public string? Description { get; set; }


        public IEnumerable<ProjectState> ProjectStates { get; set; }

        public IEnumerable<ProjectTag> ProjectTags { get; set; }

        public IEnumerable<Project> Projects { get; set; }
    }
}
