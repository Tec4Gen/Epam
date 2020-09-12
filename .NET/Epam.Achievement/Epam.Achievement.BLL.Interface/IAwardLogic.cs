﻿using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.BLL.Interface
{
    public interface IAwardLogic
    {
        int Add(Award award);

        bool Delete(int id);

        IEnumerable<Award> GetAll();
    }
}
