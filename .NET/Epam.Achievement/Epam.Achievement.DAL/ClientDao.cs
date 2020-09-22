using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Achievement.DAL
{
    public class ClientDao: IClientDao
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["AchievementBase"].ConnectionString;

        public int Add(Client client)
        {
            throw new NotImplementedException();
        }

        public Client Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Client Update(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
