﻿using Epam.Achievement.BLL.Interface;
using Epam.Achievement.DAL.Interface;
using Epam.Achievement.Entities;
using System.Collections.Generic;

namespace Epam.Achievement.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }

        public int Add(Award award)
        {
            return _awardDao.Add(award);
        }

        public Award Delete(int id)
        {
            return _awardDao.Delete(id);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }

        public Award GetById(int id)
        {
            return _awardDao.GetById(id);
        }

        public Award Update(Award award)
        {
            return _awardDao.Update(award);
        }
    }
}
