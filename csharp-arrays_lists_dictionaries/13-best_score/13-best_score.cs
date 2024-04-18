using System;
using System.Collections.Generic;

class Dictionary
{
    public static string BestScore(Dictionary<string, int> myList)
    {
        bool first = true;
        KeyValuePair<string, int> result = new KeyValuePair<string, int>();

        foreach (KeyValuePair<string, int> kvp in myList)
        {
            if (first)
            {
                result = kvp;
                first = false;
            }
            else if (kvp.Value > result.Value)
                result = kvp;
        }
        if (first)
            return "None";

        return result.Key;
    }
}
