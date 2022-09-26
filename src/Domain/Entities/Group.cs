using Domain.Common;

namespace Domain.Entities
{
    public partial class Group : BaseEntity
    {
        public Group()
        {
            ProjectStates = new HashSet<ProjectState>();
            ProjectTags = new HashSet<ProjectTag>();
            Projects = new HashSet<Project>();
        }

        public string? Name { get; set; }

        public string? Description { get; set; }


        public virtual ICollection<ProjectState> ProjectStates { get; set; }

        public virtual ICollection<ProjectTag> ProjectTags { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
