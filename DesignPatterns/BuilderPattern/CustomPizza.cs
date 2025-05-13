using DesignPatterns.Data;

namespace DesignPatterns.BuilderPattern
{
    internal class CustomPizza : Pizza
    {
        public CustomPizza(IEnumerable<PizzaToppings> toppings) : base("Custom Pizza") 
        { 
            Toppings.AddRange(toppings);
        }
    }
}
