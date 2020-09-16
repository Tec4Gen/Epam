using Epam.Achievement.Entities;
using Epam.Achievement.DAL.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;

namespace Epam.Achievement.FakeDAL
{
    public class ClientDao : IClientDao
    {
        private string _path = ConfigurationManager.AppSettings.Get("Clients");

        private Dictionary<int, Client> FakeDaoClient;
        private int _id;

        public int Add(Client client)
        {
            if (client == null)
                throw new ArgumentNullException();

            if (GetAll() == null)
                FakeDaoClient = new Dictionary<int, Client>();

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {

                var pair = new KeyValuePair<int, Client>(_id, client);
                client.Id = _id;
                FakeDaoClient.Add(_id, client);

                var json = JsonConvert.SerializeObject(FakeDaoClient);
                fileJson.WriteLine(json);

                return _id++;
            }
        }

        public bool Delete(int id)
        {
            if (GetAll() == null)
                FakeDaoClient = new Dictionary<int, Client>();

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
                if (!FakeDaoClient.Any() || !FakeDaoClient.Remove(id))
                    return false;

                var json = JsonConvert.SerializeObject(FakeDaoClient);
                fileJson.WriteLine(json);

                return true;
            }
        }

        public IEnumerable<Client> GetAll()
        {
            using (StreamReader fileJson = new StreamReader(_path))
            {
                var stringJson = fileJson.ReadToEnd();
                //yield ??77?
                FakeDaoClient = JsonConvert.DeserializeObject<Dictionary<int, Client>>(stringJson);
                _id = FakeDaoClient?.Count() ?? 0;

                return FakeDaoClient?.Select(x=> x.Value);
            }
        }

        public Client GetById(int id)
        {
            if (GetAll() == null)
                FakeDaoClient = new Dictionary<int, Client>();

            return FakeDaoClient.Where(x => x.Key == id).FirstOrDefault().Value;
        }
    }
}
