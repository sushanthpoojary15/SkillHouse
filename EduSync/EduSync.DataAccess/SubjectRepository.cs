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
    internal class SubjectRepository : ISubjectRepository
    {
        private readonly EduSyncContext _eduSyncContext;

        public SubjectRepository(EduSyncContext eduSyncContext)
        {
            this._eduSyncContext = eduSyncContext;
        }
        public void AddSubject(Subject subject)
        {
            this._eduSyncContext.Subjects.Add(subject);
        }

        public void DeleteSubject(int subjectId)
        {
            var entityToBeDeleted = this._eduSyncContext.Subjects.Where(c => c.SubjectId == subjectId).FirstOrDefault();
            if (entityToBeDeleted != null)
            {
                var entry = this._eduSyncContext.Entry(entityToBeDeleted);
                entry.State = EntityState.Deleted;
            }
        }

        public Subject GetSubject(int subjectId)
        {
            var entityToBeFetched = this._eduSyncContext.Subjects.Where(c => c.SubjectId == subjectId).FirstOrDefault();
            return entityToBeFetched;
        }

        public List<Subject> GetSubjects()
        {
            return this._eduSyncContext.Subjects.ToList();
        }

        public int SaveChanges()
        {
            return this._eduSyncContext.SaveChanges();
        }

        public void UpdateSubject(Subject subject)
        {
            var entityToUpdate = this._eduSyncContext.Subjects.Find(subject.SubjectId);
            if (entityToUpdate != null)
            {
                entityToUpdate.SubjectId = subject.SubjectId;
                entityToUpdate.Name = subject.Name;
                entityToUpdate.Description = subject.Description;

            }
        }
    }
}
