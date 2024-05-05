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
        public void AddOrUpdateStudent(StudentModel studentModel)
        {
            if (studentModel.StudentId == 0)
            {
                this._studentBusiness.AddStudent(studentModel);
            }
            else
            {
                this._studentBusiness.UpdateStudent(studentModel);
            }
        }

        [HttpGet]
        public List<StudentModel> GetStudents()
        {
            return this._studentBusiness.GetStudents();
        }

        [HttpGet("{studentId:int}")]
        public StudentModel GetStudent(int studentId)
        {
            return this._studentBusiness.GetStudent(studentId);
        }

        [HttpDelete]
        public void DeleteStudent(int studentId)
        {
            this._studentBusiness.DeleteStudent(studentId);
        }
    }
}
