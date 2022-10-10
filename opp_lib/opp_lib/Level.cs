using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Level
    {
        public Gates leftGates;
        public Gates rightGates;
        public Field field;
        public List<Obstacle> obstacles;

        public Level()
        {
            this.obstacles = new List<Obstacle>();
        }

        public void SetLevel(Gates leftGates, Gates rightGates, Field field, List<Obstacle> obstacles)
        {
            this.leftGates = leftGates;
            this.rightGates = rightGates;
            this.field = field;
            this.obstacles = obstacles;
        }
    }
}
