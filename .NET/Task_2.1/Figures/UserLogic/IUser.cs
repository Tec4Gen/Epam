using Figures.Abstracts;

namespace Figures.UserLogic
{
    public interface IUser
    {
        void Create(AbstractFigure item);

        void ShowAll();

        void ClearList();
    }
}
