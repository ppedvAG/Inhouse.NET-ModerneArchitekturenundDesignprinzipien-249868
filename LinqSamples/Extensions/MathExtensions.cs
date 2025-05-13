namespace LinqSamples.Extensions
{
    public static class MathExtensions
    {
        public static int Factorial(this int number)
        {
            return number == 0 ? 1 : number * Factorial(number - 1);
        }

        // Extension Methods zeichnen sich durch das this keyword im ersten Parameter aus
        // und die Klasse als auch Methode muss jeweils static sein.
        public static int DigitSum(this int number)
        {
            // Ein string ist ein character array weswegen wir hier Sum() von Linq verwenden koennen
            return number.ToString().Sum(c => (int)char.GetNumericValue(c));
        }
    }
}
