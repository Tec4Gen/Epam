using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.DAL.Interface
{
    public interface IClientAwardDao
    {
        int Add(int idClient, int idAward);

        bool Delete(int id);

        IEnumerable<ClientAward> GetAll();
    }
}
