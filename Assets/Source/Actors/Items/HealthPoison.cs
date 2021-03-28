using DungeonCrawl;
using DungeonCrawl.Actors.Items;

namespace Source.Actors.Items
{
    public class HealthPoison : Item
    {
        private int Healing { get; set; }
        
        
        public HealthPoison(string name, int value,int healing) : base(name, value)
        {
            Healing = healing;
            Type = ItemType.Poison;
        }
    }
}