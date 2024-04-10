using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Calculation
{
    public class InputTable
    {
        Dictionary<double, double> table;

        public InputTable(Dictionary<double, double> table)
        {
            this.Table = table;
        }

        public Dictionary<double, double> Table { get => table; set => table = value; }
    }
}
