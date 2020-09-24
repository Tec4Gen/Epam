using Epam.Achievement.BLL.Interface;
using Epam.Achievement.DAL.Interface;

namespace Epam.Achievement.BLL
{
    public class AuthLogic : IAuthLogic
    {
        private IAuthDao _authDao;

        public AuthLogic(IAuthDao authDao)
        {
            _authDao = authDao;
        }

        public bool CanLogin(string user, string password)
        {
            return _authDao.CanLogin(user, password);
        }
    }
}
