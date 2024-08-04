using System;
using InventoryLibrary;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace InventoryManager
{
    class Program
    {
        static JSONStorage storage = new JSONStorage();

        static void Main(string[] args)
        {
            functions f = new functions();
            storage.Load();
            Console.Write("Inventory Manager\n-------------------------\n<ClassNames> show all ClassNames of objects\n<All> show all objects\n<All [ClassName]> show all objects of a ClassName\n<Create [ClassName]> a new object\n<Show [ClassName object_id]> an object\n<Update [ClassName object_id]> an object\n<Delete [ClassName object_id]> an object\n<Exit>\n");
            string input = "";
            do
            {
                Console.Write(">>> ");
                input = Console.ReadLine();
                string[] command = input.Split();
                if (input != "Exit")
                    GetMethod(f, command, storage);
            }
            while (input != "Exit");
        }

        public static void GetMethod(functions f, string[] command, JSONStorage storage)
        {
            Type type = f.GetType();
            MethodInfo methodInfo = type.GetMethod(command[0]);

            if (methodInfo == null)
                {Console.WriteLine("Wrong command"); return; }

            object[] parameters = new object[] { storage, command };

            if (command.Length > 1)
                if (Type.GetType($"InventoryLibrary.{command[1]}, InventoryLibrary") == null)
                    { Console.WriteLine($"{command[1]} is not a valid object type"); return; }

            if (command.Length > 2 && command[0] != "Create")
                if (!storage.objects.ContainsKey($"{command[1]}.{command[2]}"))
                    { Console.WriteLine($"Object {command[2]} could not be found"); return; }

            methodInfo.Invoke(f, parameters);
        }
    }

    class functions
    {

        public void ClassNames(JSONStorage storage, string[] command)
        {
            storage.All().Values.Select(obj => obj.GetType()).Distinct().ToList().ForEach(type => Console.WriteLine(type.Name));
        }

        public void All(JSONStorage storage, string[] command)
        {
            string type = (command.Length > 1) ? command[1] : null;
            foreach (BaseClass obj in storage.All().Values)
                if (type == null || type == obj.GetType().Name)
                    Console.WriteLine($"{obj.GetType().Name} {obj.id}");
        }

        public void Create(JSONStorage storage, string[] command)
        {
            string type = (command.Length > 1) ? command[1] : null;
            var keyValuePairs = command.Skip(2).Select(arg =>
                                    {
                                        var parts = arg.Split('=', 2);
                                        if (parts.Length == 2)
                                            return new KeyValuePair<string, string>(parts[0], parts[1]);
                                        else
                                            return default(KeyValuePair<string, string>);
                                    }).Where(kv => !string.IsNullOrEmpty(kv.Key)).ToDictionary(kv => kv.Key, kv => kv.Value);;

            Type t = Type.GetType($"InventoryLibrary.{type}, InventoryLibrary");

            if (t == null)
            { Console.WriteLine($"Type '{type}' not found."); return; }

            if ((type == "Item" || type == "User") && !keyValuePairs.Any(kv => kv.Key == "name"))
                { Console.WriteLine($"Property name required."); return; }
            if (type == "Inventory")
            {
                if (!keyValuePairs.ContainsKey("user_id")) { Console.WriteLine($"Property user_id required."); return; }
                if (!keyValuePairs.ContainsKey("item_id")) { Console.WriteLine($"Property item_id required."); return; }
                if (!keyValuePairs.ContainsKey("quantity")) { Console.WriteLine($"Property quantity required."); return; }

                if (!storage.objects.ContainsKey($"User.{keyValuePairs["user_id"]}")) { Console.WriteLine($"Object {keyValuePairs["user_id"]} could not be found"); return; }
                if (!storage.objects.ContainsKey($"Item.{keyValuePairs["item_id"]}")) { Console.WriteLine($"Object {keyValuePairs["item_id"]} could not be found"); return; }
            }


            BaseClass obj = (BaseClass)Activator.CreateInstance(t);

            foreach (var kv in keyValuePairs)
            {
                PropertyInfo property = t.GetProperty(kv.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);;
                if (property != null)
                {
                    try
                    {
                        object convertedValue = Convert.ChangeType(kv.Value, property.PropertyType);
                        property.SetValue(obj, convertedValue);
                    }
                    catch (Exception ex)
                    { Console.WriteLine($"Error setting property '{kv.Key}': {ex.Message}"); return; }
                }
                else
                    { Console.WriteLine($"Property '{kv.Key}' not found."); return; }
            }

            storage.New(obj);
            storage.Save();
            Console.WriteLine("OK");
        }

        public void Show(JSONStorage storage, string[] command)
        {
            string type = (command.Length > 1) ? command[1] : null;
            string id = (command.Length > 2) ? command[2] : null;
            var obj = storage.All()[$"{type}.{id}"];
            Console.WriteLine($"{obj.GetType().Name}");
        }

        public void Update(JSONStorage storage, string[] command)
        {
            string type = (command.Length > 1) ? command[1] : null;
            string id = (command.Length > 2) ? command[2] : null;
            object obj = storage.All()[$"{type}.{id}"];
            if (obj is BaseClass base_obj)
            {
                base_obj.date_updated = DateTime.Now;
                storage.Save();
                Console.WriteLine("OK");
            }
        }

        public void Delete(JSONStorage storage, string[] command)
        {
            string type = (command.Length > 1) ? command[1] : null;
            string id = (command.Length > 2) ? command[2] : null;
            storage.All().Remove($"{type}.{id}");
            storage.Save();
        }

    }
}
