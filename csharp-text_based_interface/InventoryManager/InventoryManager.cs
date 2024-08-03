using System;
using InventoryLibrary;
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
                Console.WriteLine("Wrong command");

            object[] parameters = new object[] { storage };

            if (command.Length == 1 && command[0] == "All")
                parameters = new object[] { storage, "" };

            if (command.Length > 1)
                if (Type.GetType($"InventoryLibrary.{command[1]}, InventoryLibrary") == null)
                    { Console.WriteLine($"{command[1]} is not a valid object type"); return; }
                else
                    parameters = new object[] { storage, command[1] };

            if (command.Length > 2)
                if (!storage.objects.ContainsKey($"{command[1]}.{command[2]}"))
                    { Console.WriteLine($"Object {command[2]} could not be found"); return; }
                else
                    parameters = new object[] { storage, command[1], command[2] };

            if (command.Length > 3)
                parameters = new object[] { storage, command[1], command[2], command.Skip(3).ToArray() };

            methodInfo.Invoke(f, parameters);
        }
    }

    class functions
    {

        public void ClassNames(JSONStorage storage)
        {
            foreach (Object obj in storage.All().Values)
                Console.WriteLine(obj.GetType().Name);
        }

        public void All(JSONStorage storage, string type = "")
        {
            foreach (object obj in storage.All().Values)
                if (type == "" || type == obj.GetType().Name)
                    Console.WriteLine(obj.GetType().Name);
        }

        public void Create(JSONStorage storage, string type)
        {
            Type t = Type.GetType($"InventoryLibrary.{type}, InventoryLibrary");

            if (t == null)
            { Console.WriteLine($"Type '{type}' not found."); return; }

            storage.New((BaseClass)Activator.CreateInstance(t));
            storage.Save();
        }

        public void Show(JSONStorage storage, string type, string id)
        {
            var obj = storage.All()[$"{type}.{id}"];
            Console.WriteLine($"{obj.GetType().Name}");
        }

        public void Update(JSONStorage storage, string type, string id)
        {
            object obj = storage.All()[$"{type}.{id}"];
            if (obj is BaseClass base_obj)
            {
                base_obj.date_updated = DateTime.Now;
                storage.Save();
            }
        }

        public void Delete(JSONStorage storage, string type, string id)
        {
            storage.All().Remove($"{type}.{id}");
            storage.Save();
        }
    }
}
