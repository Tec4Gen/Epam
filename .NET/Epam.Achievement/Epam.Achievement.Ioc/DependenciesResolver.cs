using Epam.Achievement.BLL;
using Epam.Achievement.BLL.Interface;
using Epam.Achievement.DAL;
using Epam.Achievement.DAL.Interface;
//using Epam.Achievement.FakeDAL;

namespace Epam.Achievement.Ioc
{
    public static class DependenciesResolver
    {
        private static IClientDao _clientDao = new ClientDao();
        private static IClientLogic _clientLogic;

        private static IAwardDao _awardDao = new AwardDao();
        private static IAwardLogic _awardLogic;

        private static IClientAwardDao _clientAwardDao = new ClientAwardDao();
        private static IClientAwardLogic _clientAwardLogic;

        private static IMyRoleDao _myRoleDao = new MyRoleDao();
        private static IMyRoleLogic _myRoleLogic;

        private static IAuthDao _authDao = new AuthDao();
        private static IAuthLogic _authLogic;

        public static IClientLogic ClientLogic => _clientLogic ?? new ClientLogic(_clientDao);

        public static IAwardLogic AwardLogic => _awardLogic ?? new AwardLogic(_awardDao);

        public static IClientAwardLogic ClientAwaradLogic => _clientAwardLogic ?? new ClientAwardLogic(_clientAwardDao);

        public static IMyRoleLogic MyRoleLogic => _myRoleLogic ?? new MyRoleLogic(_myRoleDao);

        public static IAuthLogic AuthDao => _authLogic ?? new AuthLogic(_authDao);

    }
}
