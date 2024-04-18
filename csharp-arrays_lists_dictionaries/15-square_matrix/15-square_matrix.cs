using System;
class Matrix
{
    public static int[,] Square(int[,] myMatrix)
    {
        int[,] newmat = new int[myMatrix.GetLength(0), myMatrix.GetLength(1)];


        for (int i = 0; i < newmat.GetLength(0); i++)
            for (int j = 0; j < newmat.GetLength(1); j++)
                newmat[i, j] = myMatrix[i, j] * myMatrix[i, j];

        return newmat;
    }
}
