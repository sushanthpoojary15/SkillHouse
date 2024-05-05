using EduSync.Business;
using EduSync.Common.Model;
using EduSync.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Filters;

namespace EduSync.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StaffController : ControllerBase
    {
        private readonly StaffBusiness _staffBusiness;
        public StaffController(StaffBusiness staffBusiness)
        {
            this._staffBusiness = staffBusiness;
        }

        [HttpPost]
        public void AddOrUpdateStaff(StaffModel staffModel)
        {
            
            if (staffModel.Id == 0)
            {
                this._staffBusiness.AddStaff(staffModel);
            }
            else
            {
                this._staffBusiness.UpdateStaff(staffModel);
            }
        }

        [HttpGet]
        public List<StaffModel> GetStaffs()
        {
            return this._staffBusiness.GetStaffs();
        }

        [HttpGet("{staffId:int}")]
        public StaffModel GetStaff(int staffId)
        {
            return this._staffBusiness.GetStaff(staffId);
        }

        [HttpDelete]
        public void DeleteStaff(int staffId)
        {
            this._staffBusiness.DeleteStaff(staffId);
        }
    }
}






