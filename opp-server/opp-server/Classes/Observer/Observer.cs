using opp_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Observer
{
    public abstract class Observer
    {
        protected Subject Subject { get; set; }

        public abstract void Update();
    }
}
