using System;
using System.Collections.Generic;

namespace InventoryLibrary
{
	public class Item: BaseClass
	{
		public string name { get; set; }
		public string description { get; set; }
		public float price { get; set; }
		public List<string> Tags { get; set; }
	}
}
