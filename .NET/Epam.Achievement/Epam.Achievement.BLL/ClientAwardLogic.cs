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

        public ClientAward Delete(int id)
        {
            return _clientAwardDao.Delete(id);
        }

        public IEnumerable<ClientAward> DeleteByIdAward(int idAward)
        {
            return _clientAwardDao.DeleteByIdAward(idAward);
        }

        public IEnumerable<ClientAward> DeleteByIdClient(int idClient)
        {
            return _clientAwardDao.DeleteByIdClient(idClient);
        }

        public IEnumerable<ClientAward> GetAll()
        {
            return _clientAwardDao.GetAll();
        }

        public ClientAward GetById(int id)
        {
            return _clientAwardDao.GetById(id);
        }
    }
}
