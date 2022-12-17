using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.CompositePattern
{
	public class Leaf : Component
	{
		public Leaf(Player player) : base(player) { }

		public override void Add(Component component)
		{
			// no add in leaf
		}
		public override void Remove(Component component)
		{
			// no remove in leaf
		}
		public override void SetValues(int speed, int radius)
		{
			this.Player.Speed = speed;
			this.Player.Radius = radius;
		}
	}
}
