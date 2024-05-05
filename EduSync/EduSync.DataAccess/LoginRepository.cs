using EduSync.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EduSync.DataAccess
{
    public class LoginRepository
    {
        private  EduSyncContext _eduSyncContext;

        public LoginRepository(EduSyncContext eduSyncContext)
        {
            this._eduSyncContext = eduSyncContext;
        }

        public bool ValidateUser(string username, string password)
        {
            
                var user = _eduSyncContext.Users.FirstOrDefault(c => c.UserName == username && c.Password == password);

                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
           
        }
    }
}
