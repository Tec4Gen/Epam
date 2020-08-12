using Game.Interface;
using System.Collections.Generic;

namespace Game.Entity
{
    class Map
    {
        private List<IObstacle> Obstacles = new List<IObstacle>();
        private List<IEnemy> Enemies = new List<IEnemy>();
        private List<IBonus> Bonus = new List<IBonus>();


        public double Width { get; private set; }
        public double Height { get; private set; }
    }
}
