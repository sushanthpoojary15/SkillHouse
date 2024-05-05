
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

    public class UserRepository : IUserRepository
    {
        private readonly EduSyncContext _eduSyncContext;

        public UserRepository(EduSyncContext eduSyncContext)
        {
            this._eduSyncContext = eduSyncContext;
        }
        public void AddUser(User user)
        {
            this._eduSyncContext.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            var entityToBeDeleted = this._eduSyncContext.Users.Where(c => c.UserId == userId).FirstOrDefault();
            if (entityToBeDeleted != null)
            {
                var entry = this._eduSyncContext.Entry(entityToBeDeleted);
                entry.State = EntityState.Deleted;
            }
        }

        public User GetUser(int userId)
        {
            var entityToBeFetched = this._eduSyncContext.Users.Where(c => c.UserId == userId).FirstOrDefault();
            return entityToBeFetched;
        }

        public List<User> GetUsers()
        {
            return this._eduSyncContext.Users.ToList();
        }

        public int SaveChanges()
        {
            return this._eduSyncContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var entityToUpdate = this._eduSyncContext.Users.Find(user.UserId);
            if (entityToUpdate != null)
            {
                entityToUpdate.UserId = user.UserId;
                entityToUpdate.UserName = user.UserName;
                entityToUpdate.Email = user.Email;
                entityToUpdate.Password = user.Password;
                entityToUpdate.RoleId = user.RoleId;
                entityToUpdate.FirstName = user.FirstName;
                entityToUpdate.LastName = user.LastName;
                entityToUpdate.LastLogin = user.LastLogin;
                entityToUpdate.IsActive = user.IsActive;
            }
        }
    }
}


