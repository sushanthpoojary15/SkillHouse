using EduSync.Business;
using EduSync.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EduSync.Web.API.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleBusiness _roleBusiness;
        public RoleController(RoleBusiness roleBusiness)
        {
            this._roleBusiness = roleBusiness;
        }


        [HttpGet]
        public List<RoleModel> GetRoles()
        {
            return this._roleBusiness.GetRoles();
        }


        [HttpGet("{roleId:int}")]
        public RoleModel GetRole(int roleId)
        {
            return this._roleBusiness.GetRole(roleId);
        }

    }
}
