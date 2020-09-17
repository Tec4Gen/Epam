using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.DAL.Interface
{
    public interface IClientAwardDao
    {
        ClientAward GetById(int id);

        int Add(int idClient, int idAward);

        ClientAward Delete(int id);

        ClientAward Update(ClientAward clientAward);

        IEnumerable<ClientAward> GetAll();

        IEnumerable<ClientAward> DeleteByIdAward(int idAward);

        IEnumerable<ClientAward> DeleteByIdClient(int idClient);
    }
}
