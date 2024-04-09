using System;

class Program
{
    static void Main(string[] args)
    {
        string end = ", ";
        for (int i = 0; i < 100; i++)
        {
            if (i == 99)
                end = "\n";
            Console.Write("{0:00}{1}", i, end);
        }
    }
}
