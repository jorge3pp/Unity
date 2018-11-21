using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    [Serializable]
    public class Profile
    {
        public string Username;
        public CharacterStats Stats;
        public List<InventoryItem> Inventory;

        public Profile(string name)
        {
            Username = name;
            Stats = new CharacterStats();
            Inventory = new List<InventoryItem>();
        }
    }
}
