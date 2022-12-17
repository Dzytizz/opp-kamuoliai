using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.CompositePattern
{
	public abstract class Component
	{
		protected Player Player;

		public Component(Player player)
		{
			this.Player = player;
		}

		public abstract void Add(Component c);
		public abstract void Remove(Component c);
		public abstract void SetValues(int speed, int radius);
	}
}
