using EduSync.Business;
using EduSync.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduSync.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly SubjectBusiness _subjectBusiness;
        public SubjectController(SubjectBusiness subjectBusiness)
        {
            this._subjectBusiness = subjectBusiness;
        }

        [HttpPost]
        public void AddOrUpdateSubject(SubjectModel subjectModel)
        {
            if (subjectModel.SubjectId == 0)
            {
                this._subjectBusiness.AddSubject(subjectModel);
            }
            else
            {
                this._subjectBusiness.UpdateSubject(subjectModel);
            }
        }

        [HttpGet]
        public List<SubjectModel> GetSubjects()
        {
            return this._subjectBusiness.GetSubjects();
        }

        [HttpGet("{subjectId:int}")]
        public SubjectModel GetSubject(int subjectId)
        {
            return this._subjectBusiness.GetSubject(subjectId);
        }

        [HttpDelete]
        public void DeleteSubject(int subjectId)
        {
            this._subjectBusiness.DeleteSubject(subjectId);
        }
    }
}
