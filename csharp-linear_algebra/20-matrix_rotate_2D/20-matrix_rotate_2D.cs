using System;

class MatrixMath
{
    public static double[,] Rotate2D(double[,] matrix, double angle)
    {
        if ((matrix.GetLength(0) != 2 || matrix.GetLength(1) != 2))
            return new double[,] {{-1}};

        double cos = Math.Cos(angle);
        double sin = Math.Sin(angle);

        double[,] rotM = new double[,] {
            { cos, -sin },
            { sin, cos } };

        double[,] result = new double[,] {
            {rotM[0,0] * matrix[0,0] + rotM[0,1] * matrix[0,1], rotM[1,0] * matrix[0,0] + rotM[1,1] * matrix[0,1]},
            {rotM[0,0] * matrix[1,0] + rotM[0,1] * matrix[1,1], rotM[1,0] * matrix[1,0] + rotM[1,1] * matrix[1,1]}};


        return result;
    }
}



