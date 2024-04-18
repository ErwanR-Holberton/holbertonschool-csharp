using System;
using System.Collections.Generic;

class LList
{
    public static int Pop(LinkedList<int> myLList)
    {
        if (myLList.First == null)
            return 0;
        int result = myLList.First.Value;
        myLList.RemoveFirst();
        return myLList.First.Value;
    }
}
