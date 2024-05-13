using System;

class Obj
{
    public static void Print(object myObj)
    {
        foreach (var attribute in myObj.GetType().GetProperties())
            Console.WriteLine(attribute.Name);
        foreach (var attribute in myObj.GetType().GetMethods())
            Console.WriteLine(attribute.Name);
    }
}
