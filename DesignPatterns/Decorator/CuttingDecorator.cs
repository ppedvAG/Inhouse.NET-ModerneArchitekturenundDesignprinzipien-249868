using DesignPatterns.Data;

namespace DesignPatterns.Decorator
{
    public class CuttingDecorator : PizzaDecorator
    {
        public CuttingDecorator(Pizza pizza) : base(pizza)
        {
        }

        public override string Description => base.Description + ", mit extra 🧀";
    }
}
