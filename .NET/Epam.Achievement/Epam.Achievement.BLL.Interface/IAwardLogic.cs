using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.BLL.Interface
{
    public interface IAwardLogic
    {
        Award GetById(int id);
        int Add(Award award);

        Award Delete(int id);

        Award Update(Award award);

        IEnumerable<Award> GetAll();
    }
}
