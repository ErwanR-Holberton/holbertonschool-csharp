using System;
using System.Collections.Generic;

class LList
{
    public static int FindNode(LinkedList<int> myLList, int value)
    {
        int index = 0;

        foreach (int node_value in myLList)
            if (value == node_value)
                return index;
            else
                index++;

        return -1;
    }
}
