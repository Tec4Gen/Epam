using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.DAL.Interface
{
    public interface IClientDao
    {
        int Add(Client client);

        bool Delete(int id);

        IEnumerable<Client> GetAll();
    }
}
