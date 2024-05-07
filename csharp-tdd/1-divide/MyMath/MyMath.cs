using System;

namespace MyMath
{
    public class Matrix
    {
        public static int[,] Divide(int[,] matrix, int num)
        {
            if (matrix == null)
                return null;

            if (num == 0)
            {
                Console.WriteLine("Num cannot be 0");
                return null;
            }

            int lenght = matrix.GetLength(0), width = matrix.GetLength(1);
            int[,] matrix_result = new int[lenght, width];

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix_result[i, j] = matrix[i, j] / num;
                }
            }
            return matrix_result;
        }
    }
}
