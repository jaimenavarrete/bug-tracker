﻿using Domain.Common;

namespace Domain.Entities
{
    public partial class ProjectTag : BaseEntity
    {
        public ProjectTag()
        {
            Projects = new HashSet<Project>();
        }

        public string Name { get; set; } = null!;

        public string? GroupId { get; set; }

        public string ColorHexCode { get; set; } = null!;


        public virtual Group? Group { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
