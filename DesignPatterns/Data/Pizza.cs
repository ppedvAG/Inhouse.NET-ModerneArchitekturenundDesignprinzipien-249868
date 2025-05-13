namespace DesignPatterns.Data
{
    public abstract class Pizza
    {

        public Pizza(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public virtual string Description => $"{nameof(Pizza)}: {Name} mit {string.Join(", ", Toppings)}";

        public List<PizzaToppings> Toppings { get; } = [];

        public void Prepare()
        {
            Console.WriteLine($"{Name} vorbereiten...");
        }

        public void Bake()
        {
            Console.WriteLine($"{Name} in Steinofen backen...");
        }

        public override string ToString() => Description;
    }
}
