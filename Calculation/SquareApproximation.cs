using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Calculation
{
    public class SquareApproximation
    {
        public static OutputTable Calculate(InputTable input)
        {
            (double sx, double sxx, double sxxx, double sxxxx, double sy, double sxy, double sxxy) = Utils.CalculateSquareConstants(input);
            double n = input.Table.Keys.Count;
            double[] a = Cramer.Solve(new double[,]{
                { n, sx, sxx},
                { sx, sxx, sxxx},
                { sxx, sxxx, sxxxx}
            }, new double[] { sy, sxy, sxxy });
            Equation equation = new Equation((x) => a[2]*x*x + a[1]*x + a[0], $"{a[2]}x^2+({a[1]}x)+({a[0]})");
            return Utils.CreateOutputTable(input, equation, a);
        }
    }
}
