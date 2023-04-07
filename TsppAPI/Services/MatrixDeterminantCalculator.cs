using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsppApi.Services
{
    public interface IMatrixDeterminantCalculator
    {
        double CalculateDeterminant(List<List<double>> matrix);
    }

    public class MatrixDeterminantCalculator : IMatrixDeterminantCalculator
    {
        public double CalculateDeterminant(List<List<double>> matrix)
        {
            int n = matrix.Count;

            if (!IsValidSquareMatrix(matrix))
            {
                throw new ArgumentException("Matrix must be square.");
            }

            if (n == 1)
            {
                return matrix.ElementAt(0).ElementAt(0);
            }
            else if (n == 2)
            {
                return matrix.ElementAt(0).ElementAt(0) * matrix.ElementAt(1).ElementAt(1) - matrix.ElementAt(0).ElementAt(1) * matrix.ElementAt(1).ElementAt(0);
            }
            else
            {
                double determinant = 0;

                for (int i = 0; i < n; i++)
                {
                    List<List<double>> subMatrix = GetSubMatrix(matrix, 0, i);
                    double subDeterminant = CalculateDeterminant(subMatrix);
                    double cofactor = matrix.ElementAt(0).ElementAt(i) * subDeterminant * (i % 2 == 0 ? 1 : -1);
                    determinant += cofactor;
                }

                return determinant;
            }
        }

        private bool IsValidSquareMatrix(List<List<double>> matrix)
        {
            int n = matrix.Count;
            foreach (var row in matrix)
            {
                if (row.Count != n)
                {
                    return false;
                }
            }

            return true;
        }

        private List<List<double>> GetSubMatrix(List<List<double>> matrix, int row, int col)
        {
            int n = matrix.Count;
            List<List<double>> subMatrix = new List<List<double>>();

            for (int i = 0; i < n; i++)
            {
                if (i == row) continue;

                List<double> subRow = new List<double>();
                for (int j = 0; j < n; j++)
                {
                    if (j == col) continue;

                    subRow.Add(matrix.ElementAt(i).ElementAt(j));
                }

                subMatrix.Add(subRow);
            }

            return subMatrix;
        }
    }

}
