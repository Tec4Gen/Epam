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

                if (FakeDaoClientAward.Any()) 
                {
                    award.Id = FakeDaoClientAward.Select(x => x.Key).Max();
                    _id = ++award.Id;
                }

                FakeDaoClientAward.Add(_id, award);

                var json = JsonConvert.SerializeObject(FakeDaoClientAward);
                fileJson.WriteLine(json);

                return _id++;
            }
        }

        public ClientAward Delete(int id)
        {
            if (GetAll() == null)
                return null;
            var item = GetById(id);

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
                if (!FakeDaoClientAward.Any())
                    return null;

                if (item == null)
                    return null;

                FakeDaoClientAward.Remove(id);
                var json = JsonConvert.SerializeObject(FakeDaoClientAward);
                fileJson.WriteLine(json);

                return item;
            }
        }

        public IEnumerable<ClientAward> DeleteByIdAward(int idAward)
        {
            if (GetAll() == null)
                return null;
            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
                var listIrems = FakeDaoClientAward.Where(x => x.Value.IdAchievement == idAward).Select(x => x).ToList(); ;

                if (!listIrems.Any())
                    return null;

                foreach (var item in listIrems)
                {
                    FakeDaoClientAward.Remove(item.Key);
                }

                var json = JsonConvert.SerializeObject(FakeDaoClientAward);
                fileJson.WriteLine(json);

                return listIrems.Select(x => x.Value);
            }
        }

        public IEnumerable<ClientAward> DeleteByIdClient(int idClient)
        {
            if (GetAll() == null)
                return null;
            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
                var listIrems = FakeDaoClientAward.Where(x => x.Value.IdClient == idClient).Select(x => x).ToList();

                if (!listIrems.Any())
                    return null;

                foreach (var item in listIrems)
                {
                    FakeDaoClientAward.Remove(item.Key);
                }
                var json = JsonConvert.SerializeObject(FakeDaoClientAward);
                fileJson.WriteLine(json);
                return listIrems.Select(x => x.Value);
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

        public ClientAward GetById(int id)
        {
            if (GetAll() == null)
                return null;

            return FakeDaoClientAward.Where(x => x.Key == id).FirstOrDefault().Value;
        }

        public ClientAward Update(ClientAward clientAward)
        {
            if (GetAll() == null)
                return null;

            var item = GetById(clientAward.Id);

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
                if (!FakeDaoClientAward.Any())
                    return null;

                if (item == null)
                    return null;

                FakeDaoClientAward[clientAward.Id] = clientAward;
                var json = JsonConvert.SerializeObject(FakeDaoClientAward);
                fileJson.WriteLine(json);

                return item;
            }
        }
    }
}
