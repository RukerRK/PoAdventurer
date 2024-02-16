using System;

namespace PoAdventurer
{
    public class PotatoMC : Character, ITalk, IBattle
    {
        public int HP { get; set; }
        public int Damage { get; set; }

        public PotatoMC(){}
        public PotatoMC(string name, int hp, int damage) : base(name)
        {
            this.HP = hp;
            this.Damage = damage;
        }
        
        public override void Appear()
        {
            Console.WriteLine($"{this.Name} have spawn.");
        }

        public void Attack()
        {
            Console.WriteLine($"{this.Name} Attack enemy.");
        }

        public void Dodge()
        {
            Console.WriteLine($"{this.Name} dodge damage.");
        }

        public void Collect()
        {
            Console.WriteLine($"{this.Name} has received new gun!");
        }

        public void Talk()
        {
            Console.WriteLine($"{this.Name} talk to him.");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.Name} walk forward 1 step.");
        }

        public void Damaged()
        {
            Console.WriteLine($"{this.Name} taked damage. Hp left {this.HP}");
        }
        
        public void Dead()
        {
            Console.WriteLine($"{this.Name} has defeated....");
        }
    }
}