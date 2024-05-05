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
    public class SubjectBusiness
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectBusiness(ISubjectRepository subjectRepository)
        {
            this._subjectRepository = subjectRepository;
        }

        public void AddSubject(SubjectModel subjectModel)
        {
            Subject subject = new Subject();
            subject.SubjectId = subjectModel.SubjectId;
            subject.Name = subjectModel.Name;
            subject.Description = subjectModel.Description;


            this._subjectRepository.AddSubject(subject);
            this._subjectRepository.SaveChanges();
        }

        public void DeleteSubject(int subjectId)
        {
            this._subjectRepository.DeleteSubject(subjectId);
            this._subjectRepository.SaveChanges();
        }

        public SubjectModel GetSubject(int subjectId)
        {
            var subject = this._subjectRepository.GetSubject(subjectId);
            return new SubjectModel
            {
                SubjectId = subject.SubjectId,
                Name = subject.Name,
                Description = subject.Description
            };
        }


        public List<SubjectModel> GetSubjects()
        {
            var subjects = this._subjectRepository.GetSubjects();

            var subjectModels = from subject in subjects
                            select new SubjectModel
                            {
                                SubjectId = subject.SubjectId,
                                Name = subject.Name,
                                Description = subject.Description
                            };

            return subjectModels.ToList();
        }

        public void UpdateSubject(SubjectModel subjectModel)
        {
            Subject subject = new Subject();
            subject.SubjectId = subjectModel.SubjectId;
            subject.Name = subjectModel.Name;
            subject.Description = subjectModel.Description;

            this._subjectRepository.UpdateSubject(subject);
            this._subjectRepository.SaveChanges();
        }
    }
}
