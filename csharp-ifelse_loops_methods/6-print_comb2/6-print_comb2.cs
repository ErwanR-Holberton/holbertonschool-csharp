using System;

class Program
{
    static void Main(string[] args)
    {
        string end = ", ";
        for (int i = 0; i < 10; i++)
        {
            for (int j = i + 1; j < 10; j++)
            {
                if (i == 8)
                    end = "\n";
                Console.Write("{0}{1}{2}", i, j, end);
            }
        }
    }
}
