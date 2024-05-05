using System;
using System.Collections.Generic;

namespace EduSync.DataAccess.Entities;

public partial class SessionAttendance
{
    public int AttendanceId { get; set; }

    public int? SessionId { get; set; }

    public int? StudentId { get; set; }

    public virtual Session? Session { get; set; }

    public virtual Student? Student { get; set; }
}
