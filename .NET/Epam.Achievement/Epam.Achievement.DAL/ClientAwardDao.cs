using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Epam.Achievement.FakeDAL
{
    public class ClientAwardDao : IClientAwardDao
    {
        private string _path = ConfigurationManager.AppSettings.Get("ClientAwards");

        private Dictionary<int, ClientAward> FakeDaoClientAward;
        private int _id;

        public int Add(int idClient, int idAward)
        {
            if (GetAll() == null)
                FakeDaoClientAward = new Dictionary<int, ClientAward>();

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
               
                var award = new ClientAward
                {
                    IdClient = idClient,
                    IdAchievement = idAward
                };

                FakeDaoClientAward.Add(_id++, award);

                var json = JsonConvert.SerializeObject(FakeDaoClientAward);
                fileJson.WriteLine(json);

                return _id;
            }
        }

        public bool Delete(int id)
        {
            if (GetAll() == null)
                FakeDaoClientAward = new Dictionary<int, ClientAward>();

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {

                if (!FakeDaoClientAward.Any() || !FakeDaoClientAward.Remove(id))
                    return false;

                var json = JsonConvert.SerializeObject(FakeDaoClientAward);
                fileJson.WriteLine(json);

                return true;
            }
        }

        public IEnumerable<ClientAward> GetAll()
        {
            using (StreamReader fileJson = new StreamReader(_path))
            {
                var stringJson = fileJson.ReadToEnd();
                //yield ??77?
                FakeDaoClientAward = JsonConvert.DeserializeObject<Dictionary<int, ClientAward>>(stringJson);
                _id = FakeDaoClientAward?.Count() ?? 0;

                return FakeDaoClientAward?.Select(x => x.Value);
            }
        }
    }
}
