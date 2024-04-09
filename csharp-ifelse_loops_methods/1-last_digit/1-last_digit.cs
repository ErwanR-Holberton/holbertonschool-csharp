﻿using System;

class Program
{
    static void Main(string[] args)
    {
        Random rndm = new Random();
        int number = rndm.Next(-10000, 10000);
        if (number % 10 > 5)
            Console.WriteLine("The last digit of " + number + " is " + number%10 + " and is greater than 5");
        else if (number % 10 < -5)
            Console.WriteLine("The last digit of " + number + " is " + (-number)%10 + " and is greater than 5");
        else if (number % 10 == 0)
            Console.WriteLine("The last digit of " + number + " is " + number%10 + " and is 0");
        else if (number > 0)
            Console.WriteLine("The last digit of " + number + " is " + number%10 + " and is less than 6 and not 0");
        else
            Console.WriteLine("The last digit of " + number + " is " + (-number)%10 + " and is less than 6 and not 0");
    }
}
