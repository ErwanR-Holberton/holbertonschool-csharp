using System;

class MatrixMath
{
    public static double[,] Add(double[,] matrix1, double[,] matrix2)
    {
        if (!(MatrixCheck(matrix1) && MatrixCheck(matrix2)))
            return new double[,] {{-1}};

        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = matrix1[i, j] + matrix2[i, j];

        return result;
    }
    private static bool MatrixCheck(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        return (rows == 2 && cols == 2) || (rows == 3 && cols == 3);
    }
}
