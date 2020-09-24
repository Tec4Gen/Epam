using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Achievement.BLL.Interface
{
    public interface IMyRoleLogic
    {
        bool IsUserInRole(string username, string roleName);

        string[] GetRolesForUser(string username);
    }
}
