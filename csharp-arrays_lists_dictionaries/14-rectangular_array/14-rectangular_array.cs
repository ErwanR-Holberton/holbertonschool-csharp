﻿using System;


class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
            {
                if (i == j && j == 2)
                    Console.Write("1 ");
                else if (j == 4)
                    Console.Write("0\n");
                else
                    Console.Write("0 ");
            }
    }
}
