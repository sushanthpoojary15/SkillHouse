using System;
using System.Collections.Generic;

namespace EduSync.DataAccess.Entities;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Department { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
