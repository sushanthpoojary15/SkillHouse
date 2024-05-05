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
    public class StaffRepository : IStaffRepository
    {
        private readonly EduSyncContext _eduSyncContext;

        public StaffRepository(EduSyncContext eduSyncContext)
        {
           this._eduSyncContext = eduSyncContext;
        }
        public void AddStaff(Staff staff)
        {
          
           this._eduSyncContext.Staff.Add(staff);
        }

        public void DeleteStaff(int staffId)
        {
        
            var entityToBeDeleted = _eduSyncContext.Staff.Find(staffId);
            if (entityToBeDeleted != null)
            {
                
                _eduSyncContext.Staff.Remove(entityToBeDeleted);
            }
        }

        public Staff GetStaff(int staffId)
        {
          
            return _eduSyncContext.Staff.Find(staffId);
        }

        public List<Staff> GetStaffs()
        {
            
            return _eduSyncContext.Staff.ToList();
        }

        public int SaveChanges()
        {
       
            return _eduSyncContext.SaveChanges();
        }

        public void UpdateStaff(Staff staff)
        {

            var entityToUpdate = _eduSyncContext.Staff.Find(staff.StaffId);
            if (entityToUpdate != null)
            {
           
                entityToUpdate.Name = staff.Name;
                entityToUpdate.Email = staff.Email;
                entityToUpdate.Department = staff.Department;
            }
        }
    }
}







