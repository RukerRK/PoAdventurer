using System;

namespace PoAdventurer
{
    public class Aneow : Character, IBattle
    {
        public int HP { get; set; }
        public int Damage { get; set; }

        public Aneow(){}
        public Aneow(string name, int hp, int damage) : base(name)
        {
            this.HP = hp;
            this.Damage = damage;
        }
        
        public override void Appear()
        {
            Console.WriteLine($"{this.Name} appears in front of you!");
        }

        public void Stand()
        {
            Console.WriteLine($"{this.Name} do nothing.");
        }

        public void Attack()
        {
            Console.WriteLine($"{this.Name} attack you!");
        }

        public void Damaged()
        {
            Console.WriteLine($"{this.Name} taked damage.");
        }
        
        public void Dead()
        {
            Console.WriteLine($"{this.Name} has defeated!");
        }
    }
}