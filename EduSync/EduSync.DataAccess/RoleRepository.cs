using EduSync.DataAccess.Contracts;
using EduSync.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.DataAccess
{
    public class RoleRepository : IRoleRepository

    {
         private readonly EduSyncContext _eduSyncContext;

         public RoleRepository(EduSyncContext eduSyncContext)
         {
             this._eduSyncContext = eduSyncContext;
         }

        public List<Role> GetRoles()
        {
            return this._eduSyncContext.Roles.ToList();
        }

        public Role GetRole(int roleID)
        {
            var entityToBeFetched = this._eduSyncContext.Roles.Where(c => c.RoleId == roleID).FirstOrDefault();
            return entityToBeFetched;
        }


        public int SaveChanges()

        {
            return this._eduSyncContext.SaveChanges();
        }


    }
}
