using System;

namespace PoAdventurer
{
    public class Weapons
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Weapons(){}
        public Weapons(string name, int damage)
        {
            this.Name = name;
            this.Damage = damage;
        }
        
    }
}