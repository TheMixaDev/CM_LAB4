using System.Collections.Generic;

namespace Lab2.Calculation
{
    public class OutputTable
    {
        Dictionary<double, OutputRow> table;
        Equation equation;
        double[] coefficients;

        public OutputTable(Dictionary<double, OutputRow> table, Equation equation, double[] coefficients)
        {
            Table = table;
            Equation = equation;
            Coefficients = coefficients;
        }

        public Dictionary<double, OutputRow> Table { get => table; set => table = value; }
        public Equation Equation { get => equation; set => equation = value; }
        public double[] Coefficients { get => coefficients; set => coefficients = value; }
    }
}
