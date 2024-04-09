﻿﻿using System;
using System.Globalization;

class Program
{
	static void Main(string[] args)
	{
		double percent = .7553;
		double currency = 98765.4321;
		Console.WriteLine("Percent: {0}\nCurrency: {1}", (percent * 100).ToString("0.00", CultureInfo.InvariantCulture) + "%", currency.ToString("C", new CultureInfo("en-US")));
	}
}
