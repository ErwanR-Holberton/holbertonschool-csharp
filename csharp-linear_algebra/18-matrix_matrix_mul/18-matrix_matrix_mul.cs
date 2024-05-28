using System;

class MatrixMath
{
    public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        if (rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
            return new double[,] {{-1}};

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = matrix1[i, j] * matrix2[i, j];

        return result;

    }
}
