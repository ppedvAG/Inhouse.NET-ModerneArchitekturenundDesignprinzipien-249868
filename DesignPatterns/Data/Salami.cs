﻿namespace DesignPatterns.Data
{
    public class Salami : Pizza
    {
        public Salami() : base("Salami")
        {
            Toppings.Add(PizzaToppings.TomatoSauce);
            Toppings.Add(PizzaToppings.Cheese);
            Toppings.Add(PizzaToppings.Salami);
        }
    }
}
