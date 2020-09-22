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

                if (FakeDaoClient.Any())
                {
                    client.Id = FakeDaoClient.Select(x => x.Key).Max();
                    _id = ++client.Id;
                }

                FakeDaoClient.Add(_id, client);

                var json = JsonConvert.SerializeObject(FakeDaoClient);
                fileJson.WriteLine(json);

                return _id++;
            }
        }

        public Client Delete(int id)
        {
            if (GetAll() == null)
                FakeDaoClient = new Dictionary<int, Client>();

            var item = GetById(id);
            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
                if (!FakeDaoClient.Any())
                    return null;

                if (item == null)
                    return null;

                FakeDaoClient.Remove(id);
                var json = JsonConvert.SerializeObject(FakeDaoClient);
                fileJson.WriteLine(json);

                return item;
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

        public Client Update(Client client)
        {
            if (GetAll() == null)
                FakeDaoClient = new Dictionary<int, Client>();

            var item = GetById(client.Id);

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
                if (!FakeDaoClient.Any())
                    return null;

                if (item == null)
                    return null;

                FakeDaoClient[client.Id] = client;
                var json = JsonConvert.SerializeObject(FakeDaoClient);
                fileJson.WriteLine(json);

                return item;
            }
        }
    }
}
