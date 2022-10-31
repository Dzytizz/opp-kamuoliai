using opp_lib.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lib.AdapterMath
{
    public class MathAdapter : ITarget
    {
        private Adaptee adaptee = new Adaptee();
        public float Calculate(float number, char function)
        {
            float answer = adaptee.Calculation(function, number);
            return answer;
        }
    }
}
