using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.BLL.Interface
{
    public interface IClientAwardLogic
    {
        ClientAward GetById(int id);
        int Add(int idClient, int idAward);

        ClientAward Delete(int id);

        IEnumerable<ClientAward> GetAll();

        IEnumerable<ClientAward> DeleteByIdAward(int idAward);

        IEnumerable<ClientAward> DeleteByIdClient(int idClient);
    }
}
