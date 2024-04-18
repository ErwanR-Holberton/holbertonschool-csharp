using System;
using System.Collections.Generic;

class List
{
    public static int MaxInteger(List<int> myList)
    {
        if (myList.Count == 0)
        {
            Console.WriteLine("List is empty");
            return -1;
        }
        int result = myList[0];
        int i;

        for (i = 1; i < myList.Count; i++)
        {
            if (myList[i] > result)
                result = myList[i];
        }
        return result;
    }
}
