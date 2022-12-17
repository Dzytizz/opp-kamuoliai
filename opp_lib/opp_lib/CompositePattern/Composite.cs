using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.CompositePattern
{
    public class Composite :Component
    {
		List<Component> players = new List<Component>();

		public Composite() : base(null) { }

		public override void Add(Component component)
		{
			players.Add(component);
		}

		public override void Remove(Component component)
		{
			players.Remove(component);
		}

		public override void SetValues(int speed, int radius)
		{
			foreach (Component component in players)
			{
				component.SetValues(speed,radius);
			}
		}
	}
}
