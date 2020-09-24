using Epam.Achievement.BLL.Interface;
using Epam.Achievement.DAL.Interface;

namespace Epam.Achievement.BLL
{
    public class MyRoleLogic : IMyRoleLogic
    {
        private IMyRoleDao _myRoleDao;

        public MyRoleLogic(IMyRoleDao myRoleDao)
        {
            _myRoleDao = myRoleDao;
        }
  
        public string[] GetRolesForUser(string username)
        {
            return _myRoleDao.GetRolesForUser(username);
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return _myRoleDao.IsUserInRole(username,roleName);
        }
    }
}
