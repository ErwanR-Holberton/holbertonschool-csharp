using System;

class VectorMath
{
    public static double Magnitude(double[] vector)
    {
        double sum = 0;
        int count = 0;

        foreach (double value in vector)
        {
            sum += value * value;
            count += 1;
        }

        if (count != 2 && count != 3)
            return -1;

        return Math.Round(Math.Sqrt(sum), 2);
    }
}
