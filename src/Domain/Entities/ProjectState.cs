using Domain.Common;

namespace Domain.Entities
{
    public partial class ProjectState : BaseEntity
    {
        public ProjectState()
        {
            Projects = new HashSet<Project>();
        }

        public string Name { get; set; } = null!;

        public string GroupId { get; set; } = null!;

        public string ColorHexCode { get; set; } = null!;


        public virtual Group Group { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
    }
}
