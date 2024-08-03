using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InventoryLibrary
{
	public class JSONStorage
	{
		private string path = "../storage/inventory_manager.json";
		public Dictionary<string, object> objects = new Dictionary<string, object>();

		public Dictionary<string, object> All()
		{
			return objects;
		}

		public void New(BaseClass obj)
		{
			objects[$"{obj.GetType().Name}.{obj.id}"] = obj;
		}

		public void Save()
		{
			File.WriteAllText(path, JsonConvert.SerializeObject(objects, Formatting.Indented));
		}

		public void Load()
		{
			if (!File.Exists(path))
				return; // If the file does not exist, there's nothing to load

			objects = new Dictionary<string, object>();
			Dictionary<string, JObject> raw_objects = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(File.ReadAllText(path));

			foreach (var kvp in raw_objects)
			{
				string key = kvp.Key;
				JObject jObject = kvp.Value;

				string typeName = key.Split('.')[0];
				Type type = Type.GetType($"InventoryLibrary.{typeName}, InventoryLibrary");

				if (type == null)
					throw new Exception($"Type '{typeName}' not found.");

				var obj = Activator.CreateInstance(type) as BaseClass;

				if (obj != null)
				{
					JsonConvert.PopulateObject(jObject.ToString(), obj);
					objects[key] = obj;
				}
			}

		}
	}
}
