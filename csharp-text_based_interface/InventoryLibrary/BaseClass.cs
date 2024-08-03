using System;

namespace InventoryLibrary
{
    public class BaseClass
    {
        public string id;
        public DateTime date_created, date_updated;

        public BaseClass()
        {
            id = Guid.NewGuid().ToString();
            date_created = DateTime.Now;
            date_updated = DateTime.Now;
        }
    }
}
