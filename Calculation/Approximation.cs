using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Calculation
{
    public class Approximation
    {
        public static (OutputTable[], int) Calculate(InputTable inputTable)
        {
            OutputTable linear = LinearApproximation.Calculate(inputTable);
            double linearDeviation = Utils.CalculateMidsquareDeviation(linear);
            OutputTable powered = ExoticApproximation.CalculatePowered(inputTable);
            double poweredDeviation = Utils.CalculateMidsquareDeviation(powered);
            OutputTable exponented = ExoticApproximation.CalculateExponented(inputTable);
            double exponentedDeviation = Utils.CalculateMidsquareDeviation(exponented);
            OutputTable logarithmic = ExoticApproximation.CalculateLogarithmic(inputTable);
            double logarithmicDeviation = Utils.CalculateMidsquareDeviation(logarithmic);
            OutputTable square = SquareApproximation.Calculate(inputTable);
            double squareDeviation = Utils.CalculateMidsquareDeviation(square);
            OutputTable[] outputTables = { linear, powered, exponented, logarithmic, square };
            double[] deviations = { linearDeviation, poweredDeviation, exponentedDeviation, logarithmicDeviation, squareDeviation };
            int minDeviationIndex = Array.IndexOf(deviations, deviations.Min(v => double.IsNaN(v) ? double.PositiveInfinity : v));
            return (outputTables, minDeviationIndex);
        }
    }
}
