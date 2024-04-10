using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Calculation
{
    public class Cramer
    {
        public static double[] Solve(double[,] coefficients, double[] constants)
        {
            int n = constants.Length;
            double detA = Determinant(coefficients);
            double[] solution = new double[n];
            if (Math.Abs(detA) < 1e-10)
                return solution;
            for (int i = 0; i < n; i++)
            {
                double[,] tempMatrix = (double[,])coefficients.Clone();
                for (int j = 0; j < n; j++)
                    tempMatrix[j, i] = constants[j];
                double detTemp = Determinant(tempMatrix);
                solution[i] = detTemp / detA;
            }
            return solution;
        }

        static double Determinant(double[,] matrix)
        {
            int n = (int)Math.Sqrt(matrix.Length);
            double det = 0;
            if (n == 1)
                return matrix[0, 0];
            else if (n == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            for (int j = 0; j < n; j++)
                det += Math.Pow(-1, j) * matrix[0, j] * Determinant(GetSubMatrix(matrix, 0, j));
            return det;
        }

        static double[,] GetSubMatrix(double[,] matrix, int rowToRemove, int colToRemove)
        {
            int n = (int)Math.Sqrt(matrix.Length);
            double[,] subMatrix = new double[n - 1, n - 1];
            int rowIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == rowToRemove)
                    continue;
                int colIndex = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == colToRemove)
                        continue;
                    subMatrix[rowIndex, colIndex] = matrix[i, j];
                    colIndex++;
                }
                rowIndex++;
            }
            return subMatrix;
        }
    }
}
