using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationReleaseSystem.Services
{
    public interface IUser<T> where T : class
    {
        T CheckAccount(string name, string password);
        int GetIdByName(string name);
        int GetPermissionByName(string name);

        bool IsNameExisted(string name);

        void SignUp(string name, string password, int permission);

        void ChangePassword(string password);
    }
}
