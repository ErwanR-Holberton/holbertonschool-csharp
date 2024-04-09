﻿using System;

class Program
{
    static void Main(string[] args)
    {
        Random rndm = new Random();
        int number = rndm.Next(-10000, 10000);
        int digit = number % (10);
        if (digit > 5)
            Console.WriteLine("The last digit of " + number + " is " + digit + " and is greater than 5");
        else if (digit == 0)
            Console.WriteLine("The last digit of " + number + " is 0 and is 0");
        else
            Console.WriteLine("The last digit of " + number + " is " + digit + " and is less than 6 and not 0");
    }
}
