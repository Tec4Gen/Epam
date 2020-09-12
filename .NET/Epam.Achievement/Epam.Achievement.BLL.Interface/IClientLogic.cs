using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.BLL.Interface
{
    public interface IClientLogic
    {
        int Add(Client client);

        bool Delete(int id);

        IEnumerable<Client> GetAll();
    }
}
