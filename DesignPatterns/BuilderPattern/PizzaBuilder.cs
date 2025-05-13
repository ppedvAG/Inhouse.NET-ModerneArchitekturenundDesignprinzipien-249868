using DesignPatterns.Data;

namespace DesignPatterns.BuilderPattern
{
    public class PizzaBuilder
    {
        private readonly List<PizzaToppings> _toppings = [];

        public PizzaBuilder AddCheese()
        {
            _toppings.Add(PizzaToppings.Cheese);
            return this;
        }

        public PizzaBuilder AddTomatoSauce()
        {
            _toppings.Add(PizzaToppings.TomatoSauce);
            return this;
        }

        public PizzaBuilder AddPepperoni(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _toppings.Add(PizzaToppings.Pepperoni);
            }
            return this;
        }

        public Pizza Build()
        {
            return new CustomPizza(_toppings);
        }
    }
}
