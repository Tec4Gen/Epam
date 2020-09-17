using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;


namespace Epam.Achievement.FakeDAL
{
    public class AwardDao: IAwardDao
    {
        private string _path = ConfigurationManager.AppSettings.Get("Awards");

        private Dictionary<int, Award> FakeDaoAward;
        private int _id;

        public int Add(Award award)
        {
            if (award == null)
                throw new ArgumentNullException();

            if (GetAll() == null)
                FakeDaoAward = new Dictionary<int, Award>();

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
               

                var pair = new KeyValuePair<int, Award>(_id, award);

                if (FakeDaoAward.Any())
                {
                    award.Id = FakeDaoAward.Select(x => x.Key).Max();
                    _id = ++award.Id;
                }
               

                FakeDaoAward.Add(_id, award);

                var json = JsonConvert.SerializeObject(FakeDaoAward);
                fileJson.WriteLine(json);

                return _id++;
            }
        }

        public Award Delete(int id)
        {
            if (GetAll() == null)
                FakeDaoAward = new Dictionary<int, Award>();

            var item = GetById(id);
            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
                if (!FakeDaoAward.Any())
                    return null;

                if (item == null)
                    return null;

                FakeDaoAward.Remove(id);
                var json = JsonConvert.SerializeObject(FakeDaoAward);
                fileJson.WriteLine(json);

                return item;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            using (StreamReader fileJson = new StreamReader(_path))
            {
                var stringJson = fileJson.ReadToEnd();
                //yield ??77?
                FakeDaoAward = JsonConvert.DeserializeObject<Dictionary<int, Award>>(stringJson);
                _id = FakeDaoAward?.Count() ?? 0;

                return FakeDaoAward?.Select(x => x.Value);
            }
        }

        public Award GetById(int id)
        {
            if (GetAll() == null)
                FakeDaoAward = new Dictionary<int, Award>();

            return FakeDaoAward.Where(x => x.Key == id).FirstOrDefault().Value;
        }

        public Award Update(Award award)
        {
            if (GetAll() == null)
                FakeDaoAward = new Dictionary<int, Award>();

            var item = GetById(award.Id);
            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
                if (!FakeDaoAward.Any())
                    return null;

                if (item == null)
                    return null;

                FakeDaoAward[award.Id] = award;
                var json = JsonConvert.SerializeObject(FakeDaoAward);
                fileJson.WriteLine(json);

                return item;
            }
        }
    }
}
