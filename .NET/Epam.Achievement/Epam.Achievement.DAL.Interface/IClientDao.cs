using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.DAL.Interface
{
    public interface IClientDao
    {
        Client GetById(int id);

        int Add(Client client);

        Client Delete(int id);

        Client Update(Client client);

        IEnumerable<Client> GetAll();
    }
}
