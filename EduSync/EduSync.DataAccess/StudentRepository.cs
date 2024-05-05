using EduSync.DataAccess.Contracts;
using EduSync.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.DataAccess
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EduSyncContext _eduSyncContext;

        public StudentRepository(EduSyncContext eduSyncContext)
        {
            this._eduSyncContext = eduSyncContext;
        }
        public void AddStudent(Student student)
        {
            this._eduSyncContext.Students.Add(student);
        }

        public void DeleteStudent(int studentId)
        {
            var entityToBeDeleted = this._eduSyncContext.Students.Where(c => c.StudentId == studentId).FirstOrDefault();
            if (entityToBeDeleted != null)
            {
                var entry = this._eduSyncContext.Entry(entityToBeDeleted);
                entry.State = EntityState.Deleted;
            }
        }

        public Student GetStudent(int studentId)
        {
            var entityToBeFetched = this._eduSyncContext.Students.Where(c => c.StudentId == studentId).FirstOrDefault();
            return entityToBeFetched;
        }

        public List<Student> GetStudents()
        {
            return this._eduSyncContext.Students.ToList();
        }

        public int SaveChanges()
        {
            return this._eduSyncContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            var entityToUpdate = this._eduSyncContext.Students.Find(student.StudentId);
            if (entityToUpdate != null)
            {
                entityToUpdate.StudentId = student.StudentId;
                entityToUpdate.Name= student.Name;
                entityToUpdate.Email = student.Email;
                entityToUpdate.EnrollmentYear= student.EnrollmentYear;
            }
        }
    }
}
