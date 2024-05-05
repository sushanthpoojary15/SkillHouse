using EduSync.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.DataAccess.Contracts
{

    public interface IUserRepository
    {
        List<User> GetUsers();

        User GetUser(int userId);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int userId);

        int SaveChanges();
    }
}


