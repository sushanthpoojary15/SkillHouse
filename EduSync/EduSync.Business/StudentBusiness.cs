using EduSync.Common.Model;
using EduSync.DataAccess.Contracts;
using EduSync.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.Business
{
    public class StudentBusiness
    {
        private readonly IStudentRepository _studentRepository;
        public StudentBusiness(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public void AddStudent(StudentModel studentModel)
        {
            Student student = new Student();
            student.StudentId= studentModel.StudentId;
            student.Name = studentModel.Name;
            student.Email = studentModel.Email;
            student.EnrollmentYear = studentModel.EnrollmentYear;
            
            

            this._studentRepository.AddStudent(student);
            this._studentRepository.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            this._studentRepository.DeleteStudent(studentId);
            this._studentRepository.SaveChanges();
        }

        public StudentModel GetStudent(int studentId)
        {
            var student = this._studentRepository.GetStudent(studentId);
            /*return new StudentModel
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Email=student.Email,
                EnrollmentYear=student.EnrollmentYear
                
            };*/
            if(student!=null)
            {
                return new StudentModel
                {
                    StudentId = student.StudentId,
                    Name = student.Name,
                    Email = student.Email,
                    EnrollmentYear = student.EnrollmentYear

                };
            }
            else
            {
                return null;
            }
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

        public void UpdateStudent(StudentModel studentModel)
        {
            Student student = new Student();
            student.StudentId = studentModel.StudentId;
            student.Name = studentModel.Name;
            student.Email = studentModel.Email;
            student.EnrollmentYear = studentModel.EnrollmentYear;
            

            this._studentRepository.UpdateStudent(student);
            this._studentRepository.SaveChanges();
        }
    }
}
