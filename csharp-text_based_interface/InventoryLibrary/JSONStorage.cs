using System;

namespace InventoryLibrary
{
	public class JSONStorage
	{
		private string path = "storage/inventory_manager.json";
		public Dictionary<string, object> objects = new Dictionary<string, object>();

		public Dictionary<string, object> All()
		{
			return objects;
		}

		public void New(object obj)
		{
			objects[$"{obj.GetType().Name}.{obj.Id}"] = obj;
		}

		public void Save()
		{
			File.WriteAllText(path, JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true }));
		}

		public void Load()
		{
			if (!File.Exists(path))
				return; // If the file does not exist, there's nothing to load

			objects = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(File.ReadAllText(path));
		}
	}
}
