using DesignPatterns.Data;

namespace DesignPatterns.Adapter
{
    public class PanPizza
    {
        public string Name => "NY Style Pizza aus der 🥘";

        public void PutOilInPan()
        {
            Console.WriteLine("Öl in Pfanne geben");
        }

        public void FryInPan()
        {
            Console.WriteLine("In Pfanne braten");
        }
    }

    public class PanPizzaAdapter : Pizza
    {
        private readonly PanPizza _panPizza;

        public PanPizzaAdapter(PanPizza panPizza) : base(panPizza.Name)
        {
            _panPizza = panPizza;
        }

        // virtual macht die Methode ueberschreibbar mit override
        // bei new muss die Methode nicht virtual sein
        // new ist nicht empfohlen, sondern eher eine notloesung
        public new void Bake()
        {
            _panPizza.PutOilInPan();
            _panPizza.FryInPan();
        }
    }
}
