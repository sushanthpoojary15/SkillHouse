using EduSync.Common.Model;
using EduSync.DataAccess.Contracts;
using EduSync.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace EduSync.Business
{
    public class StudentBusiness
    {
        private readonly IStudentRepository _studentRepository;
        public StudentBusiness(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public Response AddStudent(StudentModel studentModel)
        {
            Response res = new Response();
            try
            {
                Student student = new Student();
                student.StudentId = studentModel.StudentId;
                student.Name = studentModel.Name;
                student.Email = studentModel.Email;
                student.EnrollmentYear = studentModel.EnrollmentYear;



                this._studentRepository.AddStudent(student);
                this._studentRepository.SaveChanges();
              
                 res.ResponseMessage = "Successfully Added Student";

         

                res.ResponseStatusCode = "200";

            }
            catch (Exception ex)
            {
                res.ResponseMessage = ex.Message;
                res.ResponseStatusCode = "500";
            }
            return res;
        }

        public Response DeleteStudent(int studentId)
        {
            Response res = new Response();
            try
            {
                this._studentRepository.DeleteStudent(studentId);
                this._studentRepository.SaveChanges();
                res.ResponseMessage = "Successfully Deleted";
                res.ResponseStatusCode="200";
                
            }
            catch(Exception ex)
            {
                res.ResponseMessage =ex.Message;
                res.ResponseStatusCode = "500";
            }
            return res;
           
        }

        public Response GetStudent(int studentId)
        {
            Response res=new Response();
            try
            {


                  var student = this._studentRepository.GetStudent(studentId);
                /*return new StudentModel
                {
                    StudentId = student.StudentId,
                    Name = student.Name,
                    Email=student.Email,
                    EnrollmentYear=student.EnrollmentYear

                };*/

                if (student != null)
                {
                    res.Result= new StudentModel
                    {
                        StudentId = student.StudentId,
                        Name = student.Name,
                        Email = student.Email,
                        EnrollmentYear = student.EnrollmentYear

                    };
                    res.ResponseMessage = "Successfully fetched the data";
                    res.ResponseStatusCode = "200";
                    return res;
                }
                res.ResponseMessage = "Unable to fetch data";
                res.ResponseStatusCode = "200";
                
                
            }
            catch(Exception ex)
            {
                res.ResponseMessage = ex.Message;
                res.ResponseStatusCode = "500";
            }
            return res;
        }

        public List<StudentModel> GetStudents()
        {
            var students = this._studentRepository.GetStudents();

            var studentModels = from student in students
                            select new StudentModel
                            {
                                StudentId = student.StudentId,
                                Name = student.Name,
                                Email = student.Email,
                                EnrollmentYear = student.EnrollmentYear
                            };

            return studentModels.ToList();
        }

        public Response UpdateStudent(StudentModel studentModel)
        {
            Response res = new Response();
            try
            {
                Student student = new Student();
                student.StudentId = studentModel.StudentId;
                student.Name = studentModel.Name;
                student.Email = studentModel.Email;
                student.EnrollmentYear = studentModel.EnrollmentYear;


                this._studentRepository.UpdateStudent(student);
                this._studentRepository.SaveChanges();
                res.ResponseMessage = "Successfully Updated Student";

                res.ResponseStatusCode = "200";
            }
            catch (Exception ex)
            {
                res.ResponseMessage = ex.Message;
                res.ResponseStatusCode = "500";
            }
            return res;
          
        }
    }
}
