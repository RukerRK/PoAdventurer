using System;

namespace PoAdventurer
{
    public class PlantNPC : Character, ITalk
    {
        public PlantNPC(){}
        public PlantNPC(string name) : base(name){}
        
        public override void Appear()
        {
            Console.WriteLine($"{this.Name} appears in front of you!");
        }

        public void Talk()
        {
            Console.WriteLine($"{this.Name} talk to you");
        }

        public void Gift()
        {
            Console.WriteLine($"{this.Name} gift a something new.");
        }
    }
}