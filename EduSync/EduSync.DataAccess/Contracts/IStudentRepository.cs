using EduSync.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.DataAccess.Contracts
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();

        Student GetStudent(int studentId);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int studentId);

        int SaveChanges();
    }
}
