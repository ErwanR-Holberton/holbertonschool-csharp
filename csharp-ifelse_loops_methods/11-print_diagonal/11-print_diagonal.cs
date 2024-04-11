using System;

class Line
{
    public static void PrintDiagonal(int length)
    {
        int i, j;
        for (i = 0; i < length; i++)
        {
            for (j = length - i; j < length; j++)
                Console.Write(" ");
            Console.WriteLine("\\");
        }

        Console.WriteLine();
    }
}
