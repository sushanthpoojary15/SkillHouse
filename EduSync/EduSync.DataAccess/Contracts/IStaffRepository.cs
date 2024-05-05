using EduSync.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.DataAccess.Contracts
{
    public interface IStaffRepository
    {
        List<Staff> GetStaffs();

        Staff GetStaff(int staffId);

        void AddStaff(Staff staff);

        void UpdateStaff(Staff staff);

        void DeleteStaff(int staffId);

        int SaveChanges();
    }
}


