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

        public int Add(Award Award)
        {
            if (Award == null)
                throw new ArgumentNullException();

            if (GetAll() == null)
                FakeDaoAward = new Dictionary<int, Award>();

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
               

                var pair = new KeyValuePair<int, Award>(_id, Award);
                FakeDaoAward.Add(_id++, Award);

                var json = JsonConvert.SerializeObject(FakeDaoAward);
                fileJson.WriteLine(json);

                return _id;
            }
        }

        public bool Delete(int id)
        {
            if (GetAll() == null)
                FakeDaoAward = new Dictionary<int, Award>();

            using (StreamWriter fileJson = new StreamWriter(_path, false))
            {
               

                if (!FakeDaoAward.Any() || !FakeDaoAward.Remove(id))
                    return false;

                var json = JsonConvert.SerializeObject(FakeDaoAward);
                fileJson.WriteLine(json);

                return true;
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
    }
}
