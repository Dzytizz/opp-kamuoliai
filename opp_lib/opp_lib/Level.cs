using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib
{
    public class Level
    {
        public Gates LeftGates { get; set; }
        public Gates RightGates { get; set; }
        public Field Field { get; set; }
        public List<Obstacle> Obstacles { get; set; }

        public Level()
        {
            this.Obstacles = new List<Obstacle>();
        }

        public void SetLevel(Gates leftGates, Gates rightGates, Field field, List<Obstacle> obstacles)
        {
            this.LeftGates = leftGates;
            this.RightGates = rightGates;
            this.Field = field;
            this.Obstacles = obstacles;
        }
    }
}
