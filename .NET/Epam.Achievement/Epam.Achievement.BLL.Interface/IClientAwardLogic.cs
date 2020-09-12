using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.BLL.Interface
{
    public interface IClientAwardLogic
    {
        int Add(int idClient, int idAward);

        bool Delete(int id);

        IEnumerable<ClientAward> GetAll();
    }
}
