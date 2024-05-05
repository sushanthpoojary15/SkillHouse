using System;
using System.Collections.Generic;

namespace EduSync.DataAccess.Entities;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int? EnrollmentYear { get; set; }

    public virtual ICollection<SessionAttendance> SessionAttendances { get; set; } = new List<SessionAttendance>();
}
