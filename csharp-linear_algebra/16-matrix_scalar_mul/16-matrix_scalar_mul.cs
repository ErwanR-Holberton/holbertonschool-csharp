using System;

class MatrixMath
{
    public static double[,] MultiplyScalar(double[,] matrix, double scalar)
    {
        if (!MatrixCheck(matrix))
            return new double[,] {{-1}};

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = matrix[i, j] * scalar;

        return result;
    }

    private static bool MatrixCheck(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        return (rows == 2 && cols == 2) || (rows == 3 && cols == 3);
    }
}
