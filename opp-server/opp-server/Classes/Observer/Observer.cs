using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opp_server.Classes.Observer
{
    public abstract class Observer
    {        
        public abstract void Update();
        protected Subject Subject { get; set; }

     
    }
}
