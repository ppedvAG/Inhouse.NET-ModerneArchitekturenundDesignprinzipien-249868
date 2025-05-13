using DesignPatterns.Data;

namespace DesignPatterns.Decorator
{
    /// <summary>
    /// OCP: Open for extension, closed for modification
    /// Verhalten zur Laufzeit erweitern
    /// </summary>
    public abstract class PizzaDecorator : Pizza
    {
        public PizzaDecorator(Pizza pizza) : base(pizza.Name)
        {            
        }
    }
}
