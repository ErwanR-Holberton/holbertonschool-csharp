using System;
using System.Collections.Generic;

class List
{
    public static int Sum(List<int> myList)
    {
        int sum = 0;
        HashSet<int> mySet = new HashSet<int>(myList);

        foreach (int value in mySet)
            sum += value;

        return sum;
    }
}
