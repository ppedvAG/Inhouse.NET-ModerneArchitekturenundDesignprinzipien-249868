
using DesignPatterns.Adapter;
using DesignPatterns.BuilderPattern;
using DesignPatterns.Data;
using DesignPatterns.Decorator;
using DesignPatterns.FactoryMethod;
using DesignPatterns.Strategy;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Factory Method Beispiel:\nStandard-🍕 erzeugen");

// Factory erzeugen welche die Bauplaene kennt wie eine Pizza zu erzeugen ist
PizzaShop shop = new PizzaShop();
Pizza simplePizza = shop.CreateMargheritaPizza();
Console.WriteLine(simplePizza);


Console.WriteLine("\nBuilder Pattern Beispiel:\nEigene 🍕 zusammenstellen");
PizzaBuilder builder = new();
Pizza myPizza = builder
    .AddTomatoSauce()
    .AddPepperoni(2)
    .AddCheese()
    .Build();
Console.WriteLine(myPizza);

Console.WriteLine("\nDecorator Pattern:\t🍕🍕 mit Funktionalitaet anreichern");
Pizza boxedPizza = new BoxDecorator(new CuttingDecorator(myPizza));
Console.WriteLine(boxedPizza);

Pizza pizzaWithExtraCheese = new ExtraCheeseDecorator(myPizza);
Console.WriteLine(pizzaWithExtraCheese);


Console.WriteLine("\nAdapter Pattern:\t🍕 in 🥘 backen");
Pizza panPizza = new PanPizzaAdapter(new PanPizza());
panPizza.Bake();
Console.WriteLine(panPizza);

Console.WriteLine("\nStrategy Pattern:\t🍕 zustellen mit geeignetem Fahrzeug");
var deliveryService = new Pizzariaba();
deliveryService.Order("Margheriata", 9000);