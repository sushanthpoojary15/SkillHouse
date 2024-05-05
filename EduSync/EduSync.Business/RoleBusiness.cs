using EduSync.Common.Model;
using EduSync.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.Business
{
    public class RoleBusiness
    {
        private readonly IRoleRepository _roleRepository;
        public RoleBusiness(IRoleRepository roleRepository)

        {
            this._roleRepository = roleRepository;
        }

        public List<RoleModel> GetRoles()
        {
            var roles = this._roleRepository.GetRoles();

            var roleModels = from role in roles
                            select new RoleModel
                            {
                                
                                RoleId = role.RoleId,
                                RoleName = role.RoleName,
                                RoleDescription = role.RoleDescription
                            };

            return roleModels.ToList();

        }

        public RoleModel GetRole(int roleID)
        {
            var role = this._roleRepository.GetRole(roleID);
            return new RoleModel
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                RoleDescription = role.RoleDescription
            };
        }
    }
}
