namespace Solid.ISP
{
    public class Creature : ICanEat, ICanSleep
    {
        public string Name { get; set; }

        public string FavoriteFood { get; set; }

        public Creature()
        {
        }

        public Creature(string name)
        {
            Name = name;
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating {FavoriteFood}");
        }

        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping");
        }
    }
}
