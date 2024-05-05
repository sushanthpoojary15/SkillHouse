using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.Common.Model
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public int? EnrollmentYear { get; set; }

        //public virtual ICollection<SessionAttendance> SessionAttendances { get; set; } = new List<SessionAttendance>();
    }
}
