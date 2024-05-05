using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.Common.Model
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public string? RoleDescription { get; set; }

        //public int Id { get; internal set; }
    }
}
