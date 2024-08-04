using System;

namespace InventoryLibrary
{
	public class Inventory: BaseClass
	{
		public string user_id { get; set; }
		public string item_id { get; set; }
		public int Quantity { get; set; }
	}
}
