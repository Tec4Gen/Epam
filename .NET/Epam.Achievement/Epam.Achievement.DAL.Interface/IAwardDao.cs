using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.DAL.Interface
{
    public interface IAwardDao
    {
        Award GetById(int id);

        int Add(Award award);

        Award Delete(int id);

        Award Update(Award award);

        IEnumerable<Award> GetAll();
    }
}
