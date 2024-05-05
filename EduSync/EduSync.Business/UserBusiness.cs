using EduSync.DataAccess.Entities;
using EduSync.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduSync.DataAccess.Contracts;
using EduSync.Common.Model;


namespace EduSync.Business
{
    public class UserBusiness
    {
        private readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public void AddUser(UserModel userModel)
        {
            User user = new User();
            user.UserId = userModel.UserId;
            user.UserName = userModel.UserName;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
            user.RoleId = userModel.RoleId;
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.LastLogin = userModel.LastLogin;
            user.IsActive = userModel.IsActive;


            this._userRepository.AddUser(user);
            this._userRepository.SaveChanges();
        }

        public void Deleteuser(int userId)
        {
            this._userRepository.DeleteUser(userId);
            this._userRepository.SaveChanges();
        }

        public UserModel GetUser(int userId)
        {
            var user = this._userRepository.GetUser(userId);
            return new UserModel
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                LastLogin = user.LastLogin,
                IsActive = user.IsActive
            };
        }

        public List<UserModel> GetUsers()
        {
            var users = this._userRepository.GetUsers();

            var userModels = from user in users
                             select new UserModel
                             {
                                 UserId = user.UserId,
                                 UserName = user.UserName,
                                 Email = user.Email,
                                 Password = user.Password,
                                 RoleId = user.RoleId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 LastLogin = user.LastLogin,
                                 IsActive = user.IsActive
                             };

            return userModels.ToList();
        }

        public void UpdateUser(UserModel userModel)
        {
            User user = new User();
            user.UserId = userModel.UserId;
            user.UserName = userModel.UserName;
            user.Email = user.Email;
            user.Password = user.Password;
            user.RoleId = user.RoleId;
            user.FirstName = user.FirstName;
            user.LastName = user.LastName;
            user.LastLogin = user.LastLogin;
            user.IsActive = user.IsActive;

            this._userRepository.UpdateUser(user);
            this._userRepository.SaveChanges();
        }
    }
}





