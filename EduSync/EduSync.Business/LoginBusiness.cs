using EduSync.DataAccess;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSync.Business
{
    public class LoginBusiness
    {
        private LoginRepository loginRepository;

        public LoginBusiness(LoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public bool ValidateUser(string username, string password)
        {
            return this.loginRepository.ValidateUser(username, password);
        }
    }
}
