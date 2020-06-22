using Game.Interface;
using System.Collections.Generic;

namespace Game.Entity
{
    class Map
    {
        private List<IObstacle> Obstacles = new List<IObstacle>();
        private List<IEnemy> Enemies = new List<IEnemy>();
        private List<IBonus> Bonus = new List<IBonus>();
        private double width;
        private double height;
        public double Width
        {
            get
            {
                return width;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
        }
    }
}
