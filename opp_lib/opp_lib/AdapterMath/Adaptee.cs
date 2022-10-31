using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace opp_lib.AdapterMath
{
    public class Adaptee
    {
        public float Calculation(char function, float f)
        {
            double number = Convert.ToDouble(f);
            decimal d = 0;
            if (function == 'S')
                d = Sqrt(number);
            else if (function == 'D')
                d = SqrtD(number);
            else if (function == 'M')
                d = SqrtM(number);
            else if (function == 'P')
                d = Pow(number);
            float answer = (float)d;
            return answer;
        }
        public decimal Sqrt(double number)
        {
            double s = Math.Sqrt(number);
            decimal d = Convert.ToDecimal(s);
            d = Decimal.Round(d, 4);
            return d;
        }

        public decimal Pow(double number)
        {
            double s = Math.Pow(number, 2);
            decimal d = Convert.ToDecimal(s);
            d = Decimal.Round(d, 2);
            return d;
        }

        public decimal SqrtD(double number)
        {
            decimal d = Sqrt(number);
            decimal answer = d / 2;
            return answer;
        }
        public decimal SqrtM(double number)
        {
            decimal d = Sqrt(number);
            decimal answer = d * 2;
            return answer;
        }
    }
}
