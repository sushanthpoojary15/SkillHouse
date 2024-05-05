using System;
using System.Collections.Generic;

namespace EduSync.DataAccess.Entities;

public partial class Session
{
    public int SessionId { get; set; }

    public int? StaffId { get; set; }

    public int? SubjectId { get; set; }

    public DateTime? DateTime { get; set; }

    public virtual ICollection<SessionAttendance> SessionAttendances { get; set; } = new List<SessionAttendance>();

    public virtual Staff? Staff { get; set; }

    public virtual Subject? Subject { get; set; }
}
