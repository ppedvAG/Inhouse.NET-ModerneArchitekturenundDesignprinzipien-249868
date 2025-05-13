using DesignPatterns.Data;

namespace DesignPatterns.FactoryMethod
{
    /// <summary>
    /// Factory Method: Abstraktion welche lose Kopplung fördert.
    /// Konsument muss nicht wissen wie ein Objekt konkret erzeugt werden muss,
    /// weil Erzeugungslogik komplex sein kann. 
    /// Factory Method foerdert lose Kopplung weil uns die konkrete Implementierung nicht
    /// interessieren muss. Auch hohe Kohaesion weil Erzeugung von Klassen ist hier zusammen gefasst.
    /// </summary>
    public class PizzaShop
    {
        public Pizza CreateByName(string name) => name switch
        {
            "Margherita" => CreateMargheritaPizza(),
            "Salami" => CreateSalamiPizza(),
            _ => throw new ArgumentException("Unknown pizza name")
        };

        public Pizza CreateMargheritaPizza() => new Margherita();

        public Pizza CreateSalamiPizza() => new Salami();
    }
}
