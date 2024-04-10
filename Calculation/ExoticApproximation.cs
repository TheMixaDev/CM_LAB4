using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Calculation
{
    public class ExoticApproximation
    {
        public delegate double Transform(double v);
        private static Transform log = (v) => Math.Log(v);
        private static Transform linear = (v) => v;
        public static InputTable TransformTable(InputTable inputTable, Transform xTransform, Transform yTransform)
        {
            Dictionary<double, double> result = new Dictionary<double, double>();
            foreach (double key in inputTable.Table.Keys)
                try
                {
                    result.Add(xTransform(key), yTransform(inputTable.Table[key]));
                } catch (Exception ex) { }
            return new InputTable(result);
        }
        public static OutputTable CalculatePowered(InputTable input)
        {
            (double b, double a) = LinearApproximation.CalculateAB(TransformTable(input, log, log));
            (a, b) = (Math.Pow(Math.E, a), b);
            Equation equation = new Equation((x) => a * Math.Pow(x, b), $"{a}x^{{\\\\left({b}\\\\right)}}");
            return Utils.CreateOutputTable(input, equation, new double[] { a, b });
        }
        public static OutputTable CalculateExponented(InputTable input)
        {
            (double b, double a) = LinearApproximation.CalculateAB(TransformTable(input, linear, log));
            (a, b) = (Math.Pow(Math.E, a), b);
            Equation equation = new Equation((x) => a * Math.Pow(Math.E, b * x), $"{a}e^{{\\\\left({b}x\\\\right)}}");
            return Utils.CreateOutputTable(input, equation, new double[] { a, b });
        }
        public static OutputTable CalculateLogarithmic(InputTable input)
        {
            (double a, double b) = LinearApproximation.CalculateAB(TransformTable(input, log, linear));
            Equation equation = new Equation((x) => a * Math.Log(x) + b, $"{a}\\\\ln\\\\left(x\\\\right)+\\\\left({b}\\\\right)");
            return Utils.CreateOutputTable(input, equation, new double[] { a, b });
        }
    }
}
