using EduSync.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.DataAccess.Contracts
{
    public interface IRoleRepository
    {
            List<Role> GetRoles();

            Role GetRole(int roleId);

            int SaveChanges();
        
    }
}
