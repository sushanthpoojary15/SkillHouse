using System;
using System.Collections.Generic;

namespace EduSync.DataAccess.Entities;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
