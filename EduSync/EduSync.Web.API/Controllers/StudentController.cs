using EduSync.Business;
using EduSync.Common.Model;
using EduSync.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduSync.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentBusiness _studentBusiness;
        public StudentController(StudentBusiness studentBusiness)
        {
            this._studentBusiness = studentBusiness;
        }

        [HttpPost]
        public Response AddOrUpdateStudent(StudentModel studentModel)
        {
            Response res = new Response();
            if (studentModel.StudentId == 0)
            {
                res= this._studentBusiness.AddStudent(studentModel);
            }
            else
            {
                res= this._studentBusiness.UpdateStudent(studentModel);
            }
            return res;
        }

        [HttpGet]
        public List<StudentModel> GetStudents()
        {
            return this._studentBusiness.GetStudents();
        }

        [HttpGet("{studentId:int}")]
        public Response GetStudent(int studentId)
        {
            return this._studentBusiness.GetStudent(studentId);
        }

        [HttpDelete]
        public Response DeleteStudent(int studentId)
        {
            var res=this._studentBusiness.DeleteStudent(studentId);
            return res;
        }
    }
}
