using System;
using System.Collections.Generic;

class List
{
    public static List<int> Divide(List<int> list1, List<int> list2, int listLength)
    {
        List<int> results = new List<int>();

        for (int i = 0; i < listLength; i++)
        {
            try {
                if (list2[i] == 0)
                {
                    results.Add(0);
                    Console.WriteLine("Cannot divide by zero");
                }
                else
                    results.Add(list1[i] / list2[i]);
            }
            catch {
                Console.WriteLine("Out of range");
            }
        }
        return results;
    }
}
