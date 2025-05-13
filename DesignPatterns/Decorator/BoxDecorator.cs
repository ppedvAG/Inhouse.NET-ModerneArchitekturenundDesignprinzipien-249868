using DesignPatterns.Data;

namespace DesignPatterns.Decorator
{
    public class BoxDecorator : PizzaDecorator
    {
        public BoxDecorator(Pizza pizza) : base(pizza)
        {
        }

        public override string Description => base.Description + ", in Schachtel verpackt";
    }
}
