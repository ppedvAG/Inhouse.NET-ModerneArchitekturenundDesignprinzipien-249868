using DesignPatterns.Data;
using DesignPatterns.FactoryMethod;

namespace DesignPatterns.Strategy
{
    public class Pizzariaba
    {
        public IVehicle DeliveryStrategy { get; private set; }

        public void Order(string pizzaName, int distanceInMeter)
        {
            var pizza = new PizzaShop().CreateByName(pizzaName);
            pizza.Prepare();
            pizza.Bake();

            SelectDeliveryStrategy(distanceInMeter);

            Deliver(pizza);
        }

        private void SelectDeliveryStrategy(int distanceInMeter)
        {
            if (distanceInMeter < 1000)
            {
                DeliveryStrategy = new Drone();
            }
            else
            {
                DeliveryStrategy = new Car();
            }
        }

        private void Deliver(Pizza pizza)
        {
            Console.WriteLine($"{pizza.Name} mit {DeliveryStrategy.Name} wird ausgeliefert.");
            DeliveryStrategy.Drive();
        }
    }
}
