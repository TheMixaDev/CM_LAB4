using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Calculation
{
    public class Utils
    {
        public static (double, double, double, double) CalculateConstants(InputTable input)
        {
            double sx = input.Table.Keys.Sum();
            double sxx = input.Table.Keys.Sum(key => key * key);
            double sy = input.Table.Values.Sum();
            double sxy = input.Table.Sum(kvp => kvp.Key * kvp.Value);
            return (sx, sxx, sy, sxy);
        }

        public static (double, double, double, double, double, double, double) CalculateSquareConstants(InputTable input)
        {
            (double sx, double sxx, double sy, double sxy) = CalculateConstants(input);
            double sxxx = input.Table.Keys.Sum(key => Math.Pow(key, 3));
            double sxxxx = input.Table.Keys.Sum(key => Math.Pow(key, 4));
            double sxxy = input.Table.Sum(kvp => kvp.Key * kvp.Key * kvp.Value);
            return (sx, sxx, sxxx, sxxxx, sy, sxy, sxxy);
        }

        public static OutputTable CreateOutputTable(InputTable input, Equation equation, double[] coefficients)
        {
            Dictionary<double, OutputRow> table = new Dictionary<double, OutputRow>();
            foreach(double key in input.Table.Keys)
                table.Add(key, new OutputRow(input.Table[key], equation.Function(key), equation.Function(key) - input.Table[key]));
            return new OutputTable(table, equation, coefficients);
        }

        public static double CalculateDeviation(OutputTable output)
        {
            return output.Table.Sum(kvp => Math.Pow(kvp.Value.Epsilon, 2));
        }

        public static double CalculateMidsquareDeviation(OutputTable output)
        {
            return Math.Sqrt(CalculateDeviation(output) / output.Table.Keys.Count);
        }

        public static double CalculatePirson(InputTable input)
        {
            (double sx, double sxx, double sy, double sxy) = CalculateConstants(input);
            double n = input.Table.Keys.Count;
            double avgX = sx / n;
            double avgY = sy / n;
            return input.Table.Sum(kvp => (kvp.Key - avgX) * (kvp.Value - avgY)) /
                Math.Sqrt(
                    input.Table.Sum(kvp => Math.Pow(kvp.Key - avgX, 2)) *
                    input.Table.Sum(kvp => Math.Pow(kvp.Value - avgY, 2))
                );
        }

        public static double CalculateTrust(OutputTable output)
        {
            return 1 - CalculateDeviation(output) / (output.Table.Sum(kvp => Math.Pow(kvp.Value.Phi, 2)) - Math.Pow(output.Table.Sum(kvp => kvp.Value.Phi), 2) /output.Table.Count);
        }
    }
}
