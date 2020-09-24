using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Achievement.BLL.Interface
{
    public interface IAuthLogic
    {
        bool CanLogin(string user, string password);
    }
}
