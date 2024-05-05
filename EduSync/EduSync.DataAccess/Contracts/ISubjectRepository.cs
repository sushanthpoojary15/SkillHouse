using EduSync.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.DataAccess.Contracts
{
    public interface ISubjectRepository
    {
        List<Subject> GetSubjects();

        Subject GetSubject(int subjectId);

        void AddSubject(Subject subject);

        void UpdateSubject(Subject subject);

        void DeleteSubject(int subjectId);

        int SaveChanges();
    }
}
