using Epam.Achievement.BLL;
using Epam.Achievement.BLL.Interface;
using Epam.Achievement.DAL.Interface;
using Epam.Achievement.FakeDAL;

namespace Epam.Achievement.Ioc
{
    public static class DependenciesResolver
    {
        private static IClientDao _clientDao;
        private static IClientLogic _clientLogic;

        private static IAwardDao _awardDao;
        private static IAwardLogic _awardLogic;

        private static IClientAwardDao _clientAwardDao;
        private static IClientAwardLogic _clientAwardLogic;

        public static IClientLogic ClientLogic => _clientLogic ?? new ClientLogic(_clientDao = new ClientDao());

        public static IAwardLogic AwardLogic => _awardLogic ?? new AwardLogic(_awardDao = new AwardDao());

        public static IClientAwardLogic ClientAwaradLogic => _clientAwardLogic ?? new ClientAwardLogic(_clientAwardDao = new ClientAwardDao());

    }
}
