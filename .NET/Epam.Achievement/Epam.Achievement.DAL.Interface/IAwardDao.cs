using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.DAL.Interface
{
    public interface IAwardDao
    {
        Award GetById(int id);

        int Add(Award award);

        bool Delete(int id);

        IEnumerable<Award> GetAll();
    }
}
