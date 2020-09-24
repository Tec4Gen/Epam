using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Achievement.DAL.Interface
{
    public interface IMyRoleDao
    {
        bool IsUserInRole(string username, string roleName);

        string[] GetRolesForUser(string username);
    }
}
