using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;

namespace Epam.Achievement.DAL
{
    public class ClientAwardDao: IClientAwardDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementBase"].ConnectionString;

        public int Add(int idClient, int idAward)
        {
            throw new NotImplementedException();
        }

        public ClientAward Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientAward> DeleteByIdAward(int idAward)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientAward> DeleteByIdClient(int idClient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientAward> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClientAward GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ClientAward Update(ClientAward clientAward)
        {
            throw new NotImplementedException();
        }
    }
}
