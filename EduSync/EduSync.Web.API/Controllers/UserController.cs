using EduSync.Business;
using EduSync.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EduSync.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;
        public UserController(UserBusiness userBusiness)
        {
            this._userBusiness = userBusiness;
        }

        [HttpPost]
        public void AddOrUpdateUser(UserModel userModel)
        {
            if (userModel.UserId == 0)
            {
                this._userBusiness.AddUser(userModel);
            }
            else
            {
                this._userBusiness.UpdateUser(userModel);
            }
        }

        [HttpGet]
        public List<UserModel> GetUsers()
        {
            return this._userBusiness.GetUsers();
        }

        [HttpGet("{userId:int}")]
        public UserModel GetUser(int userId)
        {
            return this._userBusiness.GetUser(userId);
        }

        [HttpDelete]
        public void DeleteUser(int userId)
        {
            this._userBusiness.Deleteuser(userId);
        }
    }
}




