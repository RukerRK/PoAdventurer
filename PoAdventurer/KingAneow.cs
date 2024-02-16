using System;

namespace PoAdventurer
{
    public class KingAneow : Character, IBattle
    {
        public int HP { get; set; }
        public int Damage { get; set; }

        public KingAneow(){}
        public KingAneow(string name, int hp, int damage) : base(name)
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
            Console.WriteLine($"{this.Name} take damage.");
        }

        public void Jump()
        {
            Console.WriteLine($"{this.Name} jump to dodge.");
        }

        public void Dash()
        {
            Console.WriteLine($"{this.Name} Dash to dodge.");
        }

        public void Block()
        {
            Console.WriteLine($"{this.Name} Block Your damage.");
        }
        
        public void Dead()
        {
            Console.WriteLine($"{this.Name} has defeated!");
        }
    }
}