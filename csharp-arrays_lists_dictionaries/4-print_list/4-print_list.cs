using System;
using System.Collections.Generic;

class List
{
    public static List<int> CreatePrint(int size)
    {
        if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }

        List<int> newlist = new List<int>();
        int i = 0;

        for (i = 0; i < size; i++)
        {
            newlist.Add(i);
            Console.Write(i);

            if (i != size - 1)
                Console.Write(" ");
        }
        Console.WriteLine();

        return newlist;
    }
}
