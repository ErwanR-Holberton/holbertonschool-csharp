﻿using System;

class Obj
{
    public static void Print(object myObj)
    {
        foreach (var attribute in myObj.GetType().GetProperties())
            Console.WriteLine(attribute);
    }
}
