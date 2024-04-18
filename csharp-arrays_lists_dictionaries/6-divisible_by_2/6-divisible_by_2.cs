using System;
using System.Collections.Generic;

class List
{
    public static List<bool> DivisibleBy2(List<int> myList)
    {
        List<bool> result = new List<bool>();

        foreach (int i in myList)
            result.Add(i%2 == 0);

        return result;
    }
}
