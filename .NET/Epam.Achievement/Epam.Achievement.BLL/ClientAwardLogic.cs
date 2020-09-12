using Epam.Achievement.BLL.Interface;
using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.BLL
{
    public class ClientAwardLogic : IClientAwardLogic
    {
        private IClientAwardDao _clientAwardDao;

        public ClientAwardLogic(IClientAwardDao clientAwardDao)
        {
            _clientAwardDao = clientAwardDao;
        }

        public int Add(int idClient, int idAward)
        {
            return _clientAwardDao.Add(idClient, idAward);
        }

        public bool Delete(int id)
        {
            return _clientAwardDao.Delete(id);
        }

        public IEnumerable<ClientAward> GetAll()
        {
            return _clientAwardDao.GetAll();
        }
    }
}
