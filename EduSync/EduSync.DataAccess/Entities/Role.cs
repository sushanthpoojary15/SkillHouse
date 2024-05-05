using System;
using System.Collections.Generic;

namespace EduSync.DataAccess.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public string? RoleDescription { get; set; }
  
}
