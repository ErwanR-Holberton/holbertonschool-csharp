using System;
using System.Collections.Generic;

class Dictionary
{
    public static int NumberOfKeys(Dictionary<string, string> myDict)
    {
        int sum = 0;
        foreach (KeyValuePair<string, string> kvp in myDict)
            sum += 1;

        return sum;
    }
}
