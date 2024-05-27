using System;

class VectorMath
{
    public static double Magnitude(double[] vector)
    {
        if (vector.length != 2 && vector.length != 3)
            return -1;

        int sum = 0;
        
        foreach (double value in vector)
            sum += value * value;

        return Math.Sqrt(value);
    }
}
