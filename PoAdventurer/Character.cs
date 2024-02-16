namespace PoAdventurer
{
    public abstract class Character
    {
        protected string Name { get; set; }
        
        public Character(){}
        public Character(string name)
        {
            this.Name = name;
        }
        
        public abstract void Appear();

    }
}