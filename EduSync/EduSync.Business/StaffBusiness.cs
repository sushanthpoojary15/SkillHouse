using EduSync.Common.Model;
using EduSync.DataAccess.Contracts;
using EduSync.DataAccess.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EduSync.Business
{
    public class StaffBusiness
    {
        private readonly IStaffRepository _IstaffRepository;
        public StaffBusiness(IStaffRepository staffRepository)
        {
            this._IstaffRepository = staffRepository;
        }

        public void AddStaff(StaffModel staffModel)
        {
            Staff staff = new Staff();
            staff.StaffId = staffModel.Id;
            staff.Name = staffModel.Name;
            staff.Email = staffModel.Email ;
            staff.Department = staffModel.Department;

            this._IstaffRepository.AddStaff(staff);
            this._IstaffRepository.SaveChanges();
        }

        public void DeleteStaff(int staffId)
        {
            this._IstaffRepository.DeleteStaff(staffId);
            this._IstaffRepository.SaveChanges();
        }

        public StaffModel GetStaff(int staffId)
        {
            var staff = this._IstaffRepository.GetStaff(staffId);
            return new StaffModel
            {
                Id = staff.StaffId,
                Name = staff.Name,
                Email = staff.Email,
                Department = staff.Department


        };
        }
       
        public List<StaffModel> GetStaffs()
        {
            var staffs = this._IstaffRepository.GetStaffs();

            var staffModels = from staff in staffs
                            select new StaffModel
                            {
                                Id = staff.StaffId,
                                Name = staff.Name,
                                Email = staff.Email,
                                Department = staff.Department
                            };

            return staffModels.ToList();
        }

        public void UpdateStaff(StaffModel staffModel)
        {
            Staff staff = new Staff();
            staff.StaffId = staffModel.Id;
            staff.Name = staffModel.Name;
            staff.Email = staffModel.Email;
            staff.Department = staffModel.Department;

            this._IstaffRepository.UpdateStaff(staff);
            this._IstaffRepository.SaveChanges();
        }
    }
}

