using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Calculation
{
    public class LinearApproximation
    {
        public static (double, double) CalculateAB(InputTable input)
        {
            (double sx, double sxx, double sy, double sxy) = Utils.CalculateConstants(input);
            double n = input.Table.Keys.Count;
            double delta = sxx * n - sx * sx;
            double a = (sxy * n - sx * sy) / delta;
            double b = (sxx * sy - sx * sxy) / delta;

            return (a, b);
        }

        public static OutputTable Calculate(InputTable input)
        {
            (double a, double b) = CalculateAB(input);
            Equation equation = new Equation((x) => a * x + b, $"{a}x+({b})");
            return Utils.CreateOutputTable(input, equation, new double[] { a, b });
        }
    }
}
