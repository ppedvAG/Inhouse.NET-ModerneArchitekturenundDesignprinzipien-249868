


using Microsoft.Extensions.DependencyInjection;
using Solid.DIP.Payment;
using Solid.DIP.Shopping;
using Solid.ISP;

Console.OutputEncoding = System.Text.Encoding.UTF8;

SampleInterfaceSegregationPrinciple();

SampleDependencyInversionPrinciple();

#region DIP Dependency Inversion Principle
void SampleDependencyInversionPrinciple()
{
    // Ganz einfach: DIP in seiner Essenz
    var paymentService = new PaymentService();
    var shoppingCart = new ShoppingCart(paymentService);
    shoppingCart.PayOrder();

    // Mit Dependency Injection Package
    // Install-Package Microsoft.Extensions.DependencyInjection
    ServiceProvider serviceProvider = RegisterTypesOnInitialAppStartup();

    // Bei der Verwendung
    var shoppingCart2 = serviceProvider.GetService<IShoppingService>();
    shoppingCart2.PayOrder();

    using (var scope = serviceProvider.CreateScope())
    {
        var shoppingCart3 = scope.ServiceProvider.GetService<IShoppingService>();

        // Hat dieselbe PaymentService Instanz
        var shoppingCart4 = serviceProvider.GetService<IShoppingService>();

        // using ruft die Dispose Methoden auf
        // Typischer Weise bei Dateizugriffen, DB-Zugriffen, HttpClient
        //scope.Dispose();

        // using ist sog. Syntactic Sugar
        var scope2 = serviceProvider.CreateScope();
        try
        {
            // Do something
        }
        finally
        {
            scope2.Dispose();
        }
    }
}

static ServiceProvider RegisterTypesOnInitialAppStartup()
{
    var collection = new ServiceCollection();

    // 3 varianten Dependencies zu registrieren

    // Jedes mal wird das Objekt neu erzeugt, d. h. new()
    collection.AddTransient<IShoppingService, ShoppingCart>();

    // Jedes Objekt wird innerhalb eines Scopes nur einmal verwendet
    collection.AddScoped<IPaymentService, PaymentService>();

    // Ein Objekt wird nur ein einiges Mal erzeugt
    //collection.AddSingleton<IPaymentService, PaymentService>();

    var serviceProvider = collection.BuildServiceProvider();
    return serviceProvider;
}
#endregion

#region ISP Interface Segregation Principle
void SampleInterfaceSegregationPrinciple()
{
    var bunny = new Creature
    {
        Name = "Bunny",
        FavoriteFood = "Carrot 🥕🥕"
    };
    EatSomething(bunny);

    var oliver = new Human("Jamie Oliver")
    {
        FavoriteFood = "Pancakes 🥞🥞"
    };
    PrepareAndEat_BadExample(oliver);

    var duffy = CreateCreature<Creature>("Duffy", "Pizza 🍕🍕");
    duffy.Sleep();
}

void EatSomething(ICanEat eater)
{
    eater.Eat();
}

void PrepareAndEat_BadExample(IHuman human)
{
    human.CookFood(human.FavoriteFood);
    human.Eat();
    human.Sleep();
}

void PrepareAndEat<T>(T human)
    // Contraints fuer den generischen Typparamter T
    where T : ICanEat, ICanSleep, ICanCook
{
    human.CookFood(human.FavoriteFood);
    human.Eat();
    human.Sleep();
}

T CreateCreature<T>(string name, string food)
    where T : class, ICanEat, new()
{
    // vor new() Constraint hat man Activator verwendet
    //var instance = (T)Activator.CreateInstance(typeof(T), name);

    // moderne C# Syntax
    var creature = new T();
    creature.FavoriteFood = food;
    return creature;
}
#endregion