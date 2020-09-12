using Epam.Achievement.BLL.Interface;
using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;

using System.Collections.Generic;


namespace Epam.Achievement.BLL
{
    public class ClientLogic : IClientLogic
    {
        private IClientDao _clientDao;

        public ClientLogic(IClientDao clientDao)
        {
            _clientDao = clientDao;
        }

        public int Add(Client client)
        {
            return _clientDao.Add(client);
        }

        public bool Delete(int id)
        {
            return _clientDao.Delete(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientDao.GetAll();
        }
    }
}
